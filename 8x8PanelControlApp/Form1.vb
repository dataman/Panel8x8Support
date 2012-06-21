Imports System.IO.Ports
Imports System.Net
Imports System.IO
Imports System.Text

'Commands  27 00 = Clear
'          27 xx = Set Scroll Speed, where scroll speed = 01-255


Public Class Form1
    Dim iNext As Integer = 0
    Dim tw As New TwitterVB.Twitter
    Dim bIsUpdating As Boolean = True

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As New SerialPort
        Dim a() As String = SerialPort.GetPortNames()
        For Each s As String In a
            cbSerial.Items.Add(s)
        Next

        Try
            cbSerial.SelectedItem = My.Settings.CommPort
        Catch ex As Exception
            cbSerial.SelectedItem = 0
        End Try

        Try
            cbBaudRate.SelectedItem = My.Settings.BaudRate
        Catch
            cbBaudRate.SelectedItem = "9600"
        End Try

        Try
            cbInterval.SelectedItem = My.Settings.Interval
            If cbInterval.SelectedItem Is Nothing Then Throw New Exception("Set default")
        Catch ex As Exception
            cbInterval.SelectedIndex = 2
        End Try

        txtID.Text = My.Settings.UserID.ToString
        txtPass.Text = My.Settings.Password.ToString
        txtScrollSpeed.Text = My.Settings.ScrollRate.ToString
        bIsUpdating = False
        Application.DoEvents()
        chkEnable.Checked = My.Settings.Enabled
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If (txtIpAddress.Text.Trim.Length = 0) Then
            Try
                SerialPort1.PortName = cbSerial.SelectedItem.ToString
                SerialPort1.BaudRate = cbBaudRate.SelectedItem.ToString
                Dim ScrollSpeed As Integer = Val(txtScrollSpeed.Text)
                If (ScrollSpeed < 0) Then ScrollSpeed = 0
                If (ScrollSpeed > 255) Then ScrollSpeed = 255

                SerialPort1.Open()
                SerialPort1.Write(Chr(27) & Chr(0) & Chr(27) & Chr(ScrollSpeed) & txtMessage.Text)
                SerialPort1.Close()
            Catch ex As Exception
                txtMessage.Text = "Serial Port Error: " & ex.ToString
            End Try
        Else
            ' IP based request
            Dim txtResponseVars As String = "FrameDelay=" & txtScrollSpeed.Text & "&" & _
                                            "TextBox=" & txtMessage.Text
            Dim request As WebRequest = WebRequest.Create("http://" & txtIpAddress.Text & "/")
            request.Method = "POST"
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(txtResponseVars)
            request.ContentType = "applications/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Try
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                reader.Close()
                dataStream.Close()
                response.Close()
            Catch ex As Exception
                txtMessage.Text = "TCP/IP Error: " & ex.ToString
            End Try
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        iNext -= 1
        If iNext <= 0 Then
            iNext = Val(cbInterval.SelectedItem.ToString.Substring(0, 2))
            UpdateTwitter()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        iNext = Val(cbInterval.SelectedItem.ToString.Substring(0, 2))
        UpdateTwitter()
    End Sub

    Private Sub UpdateTwitter()
        Dim sMessage As String = txtMessage.Text
        Dim txtError As String = ""
        txtMessage.Text = "Logging into twitter..."
        Application.DoEvents()
        Try
            txtError = "Verify Credentials"
            If (Not TwitterVB.Twitter.VerifyCredentials(Me.txtID.Text, Me.txtPass.Text)) Then
                Throw New Exception("Twitter: unable to login.")
            End If
            tw = New TwitterVB.Twitter
            txtError = "Unable to Authenticate"
            tw.AuthenticateAs(Me.txtID.Text, Me.txtPass.Text)
            ' Get a list of TwitterStatus objects
            txtError = "Unable to get Status"
            Dim Statuses As List(Of TwitterVB.TwitterStatus) = tw.StatusMethods.FriendsTimeLine
            For Each status As TwitterVB.TwitterStatus In Statuses
                Dim tMessage As String = status.TwitterUser.ScreenName.Trim & ": " & status.Text & Space(5)
                If tMessage = txtMessage.Text Then txtMessage.Text = sMessage : Exit Sub
                txtMessage.Text = tMessage
                Exit For
            Next
        Catch ex As Exception
            txtMessage.Text = "TWITTER LOGIN ERROR: " & txtError & ": " & ex.Message
        End Try
        Button2_Click(Me, New System.EventArgs)
    End Sub

    Private Sub chkEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnable.CheckedChanged
        My.Settings.Enabled = chkEnable.Checked
        My.Settings.Save()
        If chkEnable.Checked Then
            iNext = 0
            Timer1_Tick(Me, e)
        End If
        Timer1.Enabled = chkEnable.Checked
    End Sub

    Private Sub txtScrollSpeed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScrollSpeed.TextChanged
        If Val(txtScrollSpeed.Text) < 1 Then txtScrollSpeed.Text = "1"
        If Val(txtScrollSpeed.Text) > 255 Then txtScrollSpeed.Text = "255"
        If bIsUpdating Then Return
        My.Settings.ScrollRate = Val(txtScrollSpeed.Text)
        My.Settings.Save()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtMessage.Text = ""
    End Sub

    Private Sub cbSerial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSerial.SelectedIndexChanged
        If bIsUpdating Then Return
        My.Settings.CommPort = cbSerial.SelectedItem.ToString
        My.Settings.Save()
    End Sub

    Private Sub cbBaudRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBaudRate.SelectedIndexChanged
        If bIsUpdating Then Return
        My.Settings.BaudRate = cbBaudRate.SelectedItem.ToString
        My.Settings.Save()
    End Sub

    Private Sub txtIpAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIpAddress.TextChanged
        If bIsUpdating Then Return
        My.Settings.IpAddress = txtIpAddress.Text
        My.Settings.Save()
    End Sub

    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
        If bIsUpdating Then Return
        My.Settings.UserID = txtID.Text
        My.Settings.Save()
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged
        If bIsUpdating Then Return
        My.Settings.Password = txtPass.Text
        My.Settings.Save()
    End Sub

    Private Sub cbInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInterval.SelectedIndexChanged
        If bIsUpdating Then Return
        My.Settings.Interval = cbInterval.SelectedItem.ToString
        My.Settings.Save()
    End Sub

End Class
