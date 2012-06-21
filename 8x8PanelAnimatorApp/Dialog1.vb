Imports System.Windows.Forms
Imports System.IO.Ports
Imports System.Net
Imports System.IO
Imports System.Text

Public Class Dialog1

    Dim bStatus As Integer = -1
    Dim buffer(8) As Byte

    Private Sub Upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If (Form1.MyMovie.pPanels * Form1.MyMovie.Frames.Count() * 8) + 8 > 1016 Then
            lblStatus.Text = "Error: Upload too large for board!"
            Exit Sub
        End If
        lblStatus.Text = "Upload to board"
        Repaint()
        Dim iVersion As UInt16 = Form1.iFileVersion
        Dim iPanels As UInt16 = Form1.MyMovie.pPanels
        Dim iFrames As UInt16 = Form1.MyMovie.Frames.Count()
        Dim iFrameRate As UInt16 = Form1.txFrameRate.Text
        Dim bByteRec As Integer
        Dim dTimeIn As DateTime
        Dim iCount As Integer = 1
        Dim iMax As Integer = Form1.MyMovie.Frames.Count
        Try
            ClearBuffer()
            SerialPort1.Write(Chr(27) & "F") ' Dumping Frames
            SerialWriteLoHi(iVersion)
            SerialWriteLoHi(iPanels)
            SerialWriteLoHi(iFrames)
            SerialWriteLoHi(iFrameRate)
            For Each f As Frame In Form1.MyMovie.Frames
                lblStatus.Text = "Upload panel " & LTrim(Str(iCount)) & " of " & LTrim(Str(iMax))
                Application.DoEvents()
                iCount += 1
                For c As Integer = 0 To Form1.MyMovie.pPanels - 1
                    For b As Integer = 0 To 7
                        buffer(b) = f.Cells(c).Bytes(b)
                        'If btnPlay.Text = "Pause" Then TextBox1.Text &= "[" & f.Cells(c).Bytes(b) & "]"
                    Next
                    SerialPort1.Write(buffer, 0, 8)
                Next
            Next
            dTimeIn = Now()
            bByteRec = -1
            While bByteRec = -1
                If DateDiff(DateInterval.Second, dTimeIn, Now()) > 30 Then
                    Throw New Exception("No response from board.")
                End If
                bByteRec = GetStatus()
                Application.DoEvents()
            End While
            If bByteRec <> 0 Then
                Throw (New Exception("Board response error"))
            End If
            lblStatus.Text = "Animation upload complete."
        Catch ex As Exception
            lblStatus.Text = "Serial Port Error: " & ex.Message()
            Try
                'SerialPort1.Close()
            Catch ex
            End Try
        End Try

    End Sub

    Private Sub Stream_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStream.Click
        If btnStream.Text = "Stop Streaming" Then btnStream.Text = "Stream to Board" : Exit Sub
        btnStream.Text = "Stop Streaming"
        lblStatus.Text = "Streaming to board"
        Repaint()
        Dim iVersion As UInt16 = Form1.iFileVersion
        Dim iPanels As UInt16 = Form1.MyMovie.pPanels
        Dim iFrames As UInt16 = Form1.MyMovie.Frames.Count()
        Dim iFrameRate As UInt16 = Form1.txFrameRate.Text
        Dim bByteRec As Integer
        Dim dTimeIn As DateTime
        Dim iCount As Integer = 1
        Dim iMax As Integer = Form1.MyMovie.Frames.Count
        Try
            ClearBuffer()
            Do While btnStream.Text = "Stop Streaming"
                For Each f As Frame In Form1.MyMovie.Frames
                    If btnStream.Text <> "Stop Streaming" Then Exit For
                    lblStatus.Text = "Stream panel " & LTrim(Str(iCount)) & " of " & LTrim(Str(iMax))
                    Application.DoEvents()
                    iCount += 1
                    SerialPort1.Write(Chr(27) & "L") ' Dumping Frames
                    SerialWriteLoHi(iVersion)
                    SerialWriteLoHi(iPanels)
                    SerialWriteLoHi(iFrameRate)
                    For c As Integer = 0 To Form1.MyMovie.pPanels - 1
                        For b As Integer = 0 To 7
                            buffer(b) = f.Cells(c).Bytes(b)
                            'If btnPlay.Text = "Pause" Then TextBox1.Text &= "[" & f.Cells(c).Bytes(b) & "]"
                        Next
                        SerialPort1.Write(buffer, 0, 8)
                    Next
                    dTimeIn = Now()
                    bByteRec = -1
                    While bByteRec = -1
                        If DateDiff(DateInterval.Second, dTimeIn, Now()) > 30 Then
                            Throw New Exception("No response from board.")
                        End If
                        bByteRec = GetStatus()
                        Application.DoEvents()
                    End While
                    If bByteRec <> 0 Then
                        Throw (New Exception("Board response error"))
                    End If
                    bStatus = -1
                Next
                iCount = 0
                Application.DoEvents()
            Loop
            ' SerialPort1.Close()
            lblStatus.Text = "Streaming terminated."
        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
            Try
                'SerialPort1.Close()
            Catch ex
            End Try
        End Try
    End Sub


    Private Sub StreamTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ClearBuffer()
        Dim Buffer(256) As Byte
        For i As Integer = 0 To 255
            Buffer(i) = i
        Next
        SerialPort1.Write(Buffer, 0, 256)
    End Sub

    Private Sub SerialWriteLoHi(ByVal uValue As UInt16)
        SerialPort1.Write(Chr(uValue And 255))
        SerialPort1.Write(Chr(Int(uValue / 256)))
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddComm()

        Try
            cbBaudRate.SelectedItem = My.Settings.BaudRate
        Catch
            cbBaudRate.SelectedItem = "57600"
        End Try


    End Sub



    Private Sub AddComm()
        Dim x As New SerialPort
        Dim a() As String = SerialPort.GetPortNames()
        cbSerial.Items.Clear()
        For Each s As String In a
            cbSerial.Items.Add(s)
        Next
        Try
            cbSerial.SelectedItem = My.Settings.CommPort
        Catch ex As Exception
            cbSerial.SelectedItem = 0
        End Try
    End Sub

    Private Sub btnCommRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommRefresh.Click
        AddComm()
    End Sub


    Private Sub cbSerial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSerial.SelectedIndexChanged
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            btnPlay.Text = "Play"
        End If
        My.Settings.CommPort = cbSerial.SelectedItem.ToString
        My.Settings.Save()

    End Sub


    Private Sub cbBaudRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBaudRate.SelectedIndexChanged
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            btnPlay.Text = "Play"
        End If
        My.Settings.BaudRate = cbBaudRate.SelectedItem.ToString
        My.Settings.Save()
    End Sub


    Private Sub txtIpAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIpAddress.TextChanged
        My.Settings.IPAddress = txtIpAddress.Text
        My.Settings.Save()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Function GetChar() As Integer
        ' Look for char(1) or char(0) otherwise display
        Dim bByteRec As Byte
        Static buff(8) As Byte
        While SerialPort1.BytesToRead() > 0
            SerialPort1.Read(buff, 0, 1)
            bByteRec = buff(0)
            If bByteRec < 32 Then
                If btnPlay.Text = "Pause" Then TextBox1.Text &= "<" & Format(bByteRec, "000") & ">"
                If bByteRec < 2 Then
                    bStatus = bByteRec
                End If
            Else
                If btnPlay.Text = "Pause" Then TextBox1.Text &= Chr(bByteRec)
            End If
            Repaint()
        End While
    End Function

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        If btnPlay.Text = "Play" Then
            btnPlay.Text = "Pause"
            If Not Timer1.Enabled Then
                SerialPort1.PortName = cbSerial.SelectedItem.ToString
                SerialPort1.BaudRate = cbBaudRate.SelectedItem.ToString
                SerialPort1.Open()
                Timer1.Enabled = True
            End If
        Else
            btnPlay.Text = "Play"
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        GetChar()
        Repaint()
    End Sub

    Private Sub ClearBuffer()
        If Not Timer1.Enabled Then
            SerialPort1.PortName = cbSerial.SelectedItem.ToString
            SerialPort1.BaudRate = cbBaudRate.SelectedItem.ToString
            SerialPort1.Open()
            Timer1.Enabled = True
        End If
        While SerialPort1.BytesToRead() > 0
            GetChar()
        End While
        bStatus = -1
    End Sub

    Private Function GetStatus() As Integer
        Dim rStatus As Integer = bStatus
        Return rStatus
    End Function

    Private Sub Repaint()
        'TextBox1.Refresh()
        Application.DoEvents()
    End Sub

   
End Class
