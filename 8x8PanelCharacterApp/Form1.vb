Public Class Form1

    Dim bits() As Integer = {1, 2, 4, 8, 16, 32, 64, 128}
    Dim bUpdateFlag As Boolean = False

    Private Sub Panel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    r0b7.Click, r0b6.Click, r0b5.Click, r0b4.Click, r0b3.Click, r0b2.Click, r0b1.Click, r0b0.Click, _
    r1b7.Click, r1b6.Click, r1b5.Click, r1b4.Click, r1b3.Click, r1b2.Click, r1b1.Click, r1b0.Click, _
    r2b7.Click, r2b6.Click, r2b5.Click, r2b4.Click, r2b3.Click, r2b2.Click, r2b1.Click, r2b0.Click, _
    r3b7.Click, r3b6.Click, r3b5.Click, r3b4.Click, r3b3.Click, r3b2.Click, r3b1.Click, r3b0.Click, _
    r4b7.Click, r4b6.Click, r4b5.Click, r4b4.Click, r4b3.Click, r4b2.Click, r4b1.Click, r4b0.Click, _
    r5b7.Click, r5b6.Click, r5b5.Click, r5b4.Click, r5b3.Click, r5b2.Click, r5b1.Click, r5b0.Click, _
    r6b7.Click, r6b6.Click, r6b5.Click, r6b4.Click, r6b3.Click, r6b2.Click, r6b1.Click, r6b0.Click, _
    r7b7.Click, r7b6.Click, r7b5.Click, r7b4.Click, r7b3.Click, r7b2.Click, r7b1.Click, r7b0.Click
        Dim oPanel As Panel = CType(sender, Panel)
        Dim mColor As System.Drawing.Color = oPanel.BackColor
        If oPanel.Parent.BackColor = mColor Then
            oPanel.BackColor = Color.Black
        Else
            oPanel.BackColor = oPanel.Parent.BackColor
        End If
        If bUpdateFlag Then Return
        UpdateValues()
    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtStatus.Text = ""
        Dim sPanel As String
        Dim mColor As System.Drawing.Color
        Dim oPanel As Panel
        Dim bColor As System.Drawing.Color = Me.BackColor
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                sPanel = "r" & LTrim(Str(i)) & "b" & LTrim(Str(j))
                oPanel = Me.Controls(sPanel)
                oPanel.BackColor = mColor
            Next
        Next
        If bUpdateFlag Then Return
        UpdateValues()
    End Sub


    Private Sub btn5x8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5x8.Click
        Dim sPanel As String
        Dim oPanel As Panel
        Dim bColor As System.Drawing.Color = Me.BackColor
        btnClear_Click(Me, e)
        For i = 0 To 6
            For j = 0 To 4
                sPanel = "r" & LTrim(Str(i)) & "b" & LTrim(Str(j))
                oPanel = Me.Controls(sPanel)
                oPanel.BackColor = Color.Black
            Next
        Next
        UpdateValues()
    End Sub

    Private Sub btn5x5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5x5.Click
        Dim sPanel As String
        Dim oPanel As Panel
        Dim bColor As System.Drawing.Color = Me.BackColor
        btnClear_Click(Me, e)
        For i = 2 To 6
            For j = 0 To 4
                sPanel = "r" & LTrim(Str(i)) & "b" & LTrim(Str(j))
                oPanel = Me.Controls(sPanel)
                oPanel.BackColor = Color.Black
            Next
        Next
        UpdateValues()
    End Sub

    Private Sub UpdateValues()
        txtStatus.Text = ""
        If bUpdateFlag Then Return
        Dim sPanel As String
        Dim oPanel As Panel
        Dim iVal As Integer = 0
        bUpdateFlag = True
        For i = 0 To 7
            iVal = 0
            For j = 0 To 7
                sPanel = "r" & LTrim(Str(i)) & "b" & LTrim(Str(j))
                oPanel = Me.Controls(sPanel)
                If oPanel.BackColor = Color.Black Then iVal += bits(j)
            Next
            sPanel = "tx" & LTrim(Str(i))
            Me.Controls(sPanel).Text = iVal
        Next
        bUpdateFlag = False
    End Sub

    Private Sub ToText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToText.Click
        txtStatus.Text = ""
        UpdateValues()
        txtOut.Text = ""
        For i = 0 To 7
            txtOut.Text &= Me.Controls("tx" & LTrim(Str(i))).Text.Trim & ", "
        Next
        txtStatus.Text = "Output text updated."
    End Sub

    Private Sub FromText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromText.Click
        btnClear_Click(Me, e)
        Dim cmd As String = txtOut.Text.Trim
        If cmd.Length < 15 Then txtStatus.Text = "Error: Input string must contain 8 values" : Return
        If Microsoft.VisualBasic.Right(cmd, 1) = "," Then cmd = Microsoft.VisualBasic.Left(cmd, cmd.Length - 1)
        Dim a() As String = cmd.Split(",")
        If a.Length <> 8 Then txtStatus.Text = "Error: Input must contain 8 values" : Return
        For i = 0 To 7
            Me.Controls("tx" & LTrim(Str(i))).Text = Trim(a(i))
        Next
        txtStatus.Text = ""
    End Sub

    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tx0.TextChanged, _
        tx1.TextChanged, tx2.TextChanged, tx3.TextChanged, tx4.TextChanged, tx5.TextChanged, tx6.TextChanged, tx7.TextChanged
        '   Handles txt0.TextChanged, _
        '   txt1.TextChanged, txt2.TextChanged, txt3.TextChanged, txt4.TextChanged, txt5.TextChanged, txt6.TextChanged, txt7.TextChanged
        If bUpdateFlag Then Return
        Dim oText As TextBox = CType(sender, TextBox)
        Dim iRow As Integer = CInt(Microsoft.VisualBasic.Right(oText.Name, 1))
        If oText.Text.Length = 0 Then Return
        Dim bTemp As Integer = 0
        Try
            bTemp = CInt(CType(sender, TextBox).Text)
        Catch
            oText.Text = "0"
        End Try
        bUpdateFlag = True
        Dim sPanel As String
        Dim oPanel As Panel
        Dim mColor As System.Drawing.Color
        For j = 7 To 0 Step -1
            sPanel = "r" & LTrim(Str(iRow)) & "b" & LTrim(Str(j))
            oPanel = Me.Controls(sPanel)
            mColor = Me.BackColor
            If bTemp >= bits(j) Then
                bTemp -= bits(j)
                mColor = Color.Black
            End If
            oPanel.BackColor = mColor
        Next
        bUpdateFlag = False
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdateValues()
    End Sub

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mText As TextBox
        Dim mVal As UInteger
        For i As Integer = 0 To 7
            mText = Me.Controls("tx" & LTrim(Str(i)))
            mVal = Val(mText.Text) << 1
            If mVal >= 256 Then mVal -= 256
            mText.Text = mVal
        Next
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mText As TextBox
        Dim mVal As UInteger
        For i As Integer = 0 To 7
            mText = Me.Controls("tx" & LTrim(Str(i)))
            mVal = Val(mText.Text) >> 1
            mText.Text = mVal
        Next
    End Sub


End Class

