Imports System.IO

Public Class Form1
    Dim Panels As New List(Of Panel)
    Public MyMovie As New Movie(1)
    Dim pIdx As Integer = 0
    Public iFileVersion As Integer = 2

    Private Sub NewPanels(ByVal iPanels As Integer)
        Dim p As Panel
        While Panels.Count > 0
            p = Panels.Item(0)
            Me.Controls.Remove(p)
            Panels.Remove(p)
        End While
        MyMovie = New Movie(iPanels)
    End Sub

    Private Sub cbPanels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPanels.SelectedIndexChanged
        If cbPanels.SelectedIndex = -1 Then Return
        Dim iPanels As Integer = CInt(cbPanels.SelectedItem.ToString)
        NewPanels(iPanels)
        Dim x As Integer = 15                             'starting x
        Dim y As Integer = 26                             'starting y
        Dim w As Integer = Me.ClientSize.Width - (x * 2)  'avaialable width
        Dim h As Integer = Me.ClientSize.Height - (y + 15) 'available height
        'If w > h Then w = h Else h = w ' Set Cell to Squar
        Dim cw As Integer = w / (iPanels * 8)              ' xWidth
        Dim cy As Integer = h / 8                          ' yHeight
        If cw > cy Then cw = cy ' Force Square
        Dim p As Panel
        For iPanel = 0 To iPanels - 1
            For iRow = 0 To 7
                For iCol = 0 To 7
                    p = New Panel
                    p.Name = "P" + LTrim(Str(iPanel)) & "R" & LTrim(Str(iRow)) & "C" & LTrim(Str(iCol))
                    p.Left = x + (iCol * cw) + (iPanel * cw * 8)
                    p.Top = y + (iRow * cw)
                    p.Height = cw
                    p.Width = cw
                    p.BorderStyle = BorderStyle.FixedSingle
                    p.BackColor = Me.BackColor
                    AddHandler p.Click, AddressOf Me.PanelClicked
                    Me.Controls.Add(p)
                    Panels.Add(p)
                Next
            Next
        Next
        DisplayStatus()
    End Sub

    Private Sub PanelClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p As Panel = CType(sender, Panel)
        If p.BackColor = Me.BackColor Then p.BackColor = Color.Black Else p.BackColor = Me.BackColor
        '
        Dim ip As Integer = p.Name.Substring(1, 1)
        StorePanel(ip)
    End Sub

    Private Sub StorePanel(ByVal iP As Integer)
        Dim pFrame As Frame = MyMovie.CurrentFrame()
        Dim sp As String = "P" + LTrim(Str(iP))
        Dim bValue As Byte = 0
        Dim bTotal As Byte = 0
        For ir = 0 To 7
            bTotal = 0
            For ic = 0 To 7
                bValue = 2 ^ (7 - ic)
                sp = "P" & LTrim(Str(iP)) & "R" & LTrim(Str(ir)) & "C" & LTrim(Str(ic))
                If Me.Controls(sp).BackColor = Me.BackColor Then bValue = 0
                bTotal += bValue
            Next
            pFrame.Cells(iP).Bytes.Item(ir) = bTotal
        Next
    End Sub

    Private Sub AddPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        MyMovie.Add()
        For i As Integer = 0 To MyMovie.pPanels - 1
            StorePanel(i)
        Next
        DisplayStatus()
    End Sub

    Private Sub DeletePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        MyMovie.DeleteCurrentFrame()
        LoadAllPanels()
        DisplayStatus()
    End Sub

    Private Sub LoadPanel(ByVal i As Integer)
        Dim f As Frame = MyMovie.CurrentFrame()
        Dim bValue As Byte
        Dim ip, ir, ic As Integer
        For Each p In Panels
            ip = p.Name.Substring(1, 1)
            ir = p.Name.Substring(3, 1)
            ic = p.Name.Substring(5, 1)
            bValue = 2 ^ (7 - ic)
            If (f.Cells(ip).Bytes(ir) And bValue) > 0 Then p.BackColor = Color.Black Else p.BackColor = Me.BackColor
        Next
    End Sub

    Private Sub LoadAllPanels()
        For Each p As Panel In Panels
            p.BackColor = Me.BackColor
        Next
        For i As Integer = 0 To MyMovie.pPanels - 1
            LoadPanel(i)
        Next
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As Frame = MyMovie.CurrentFrame()
        Dim bValue As Byte
        Dim ip, ir, ic As Integer
        For Each p In Panels
            ip = p.Name.Substring(1, 1)
            ir = p.Name.Substring(3, 1)
            ic = p.Name.Substring(5, 1)
            bValue = 2 ^ (7 - ic)
            If p.BackColor = Color.Black Then f.Cells(ip).Bytes(ir) = f.Cells(ip).Bytes(ir) Or bValue
        Next
    End Sub

    Private Sub Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim f As Frame = MyMovie.CurrentFrame()
        For c As Integer = 0 To MyMovie.pPanels - 1
            For l = 0 To 7
                f.Cells(c).Bytes(l) = 0
            Next
        Next
        For Each p As Panel In Panels
            p.BackColor = Me.BackColor
        Next
    End Sub

    Private Sub DisplayStatus()
        lblStatus.Text = MyMovie.Status()
    End Sub

    Private Sub First_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        MyMovie.Frst()
        LoadAllPanels()
        DisplayStatus()
    End Sub

    Private Sub Prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        MyMovie.Prv()
        LoadAllPanels()
        DisplayStatus()
    End Sub

    Private Sub Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        MyMovie.Nxt()
        LoadAllPanels()
        DisplayStatus()
    End Sub

    Private Sub Last_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        MyMovie.Lst()
        LoadAllPanels()
        DisplayStatus()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.DefaultExt = ".8X8"
        SaveFileDialog1.Filter = "8x8 Panel Animations (*.8x8)|*.8x8"
        Dim oResult As DialogResult = SaveFileDialog1.ShowDialog()
        If oResult = DialogResult.OK Then
            Dim oFileStream As System.IO.FileStream
            oFileStream = System.IO.File.Create(SaveFileDialog1.FileName, FileMode.Create)
            Dim oWrite As New BinaryWriter(oFileStream)
            Dim iVersion As Int16 = iFileVersion
            Dim iPanels As Int16 = MyMovie.pPanels
            Dim iCount As Int16 = MyMovie.Count
            Dim iFrameRate As Int16 = CInt(txFrameRate.Text)
            oWrite.Write(iVersion)
            oWrite.Write(iPanels)
            oWrite.Write(iCount)
            oWrite.Write(iFrameRate)
            For Each eframe As Frame In MyMovie.Frames
                ' Version 1 Code
                'For i As Integer = MyMovie.pPanels - 1 To 0 Step -1
                '    For l = 0 To 7
                '        oWrite.Write(eframe.Cells(i).Bytes(l))
                '    Next
                'Next
                '
                'Version(2 + coding)
                For i As Integer = 0 To MyMovie.pPanels - 1
                    For l = 0 To 7
                        oWrite.Write(eframe.Cells(i).Bytes(l))
                    Next
                Next
            Next
            oWrite.Close()
        End If
    End Sub

    Private Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        OpenFileDialog1.AddExtension = True
        OpenFileDialog1.DefaultExt = ".8X8"
        OpenFileDialog1.Filter = "8x8 Panel Animations (*.8x8)|*.8x8"
        Dim oResult As DialogResult = OpenFileDialog1.ShowDialog()
        If oResult = DialogResult.OK Then
            Dim oFileStream As System.IO.FileStream
            oFileStream = System.IO.File.Open(OpenFileDialog1.FileName, FileMode.Open)
            Dim oRead As New BinaryReader(oFileStream)
            Dim iVersion As Int16 = oRead.ReadInt16()
            Dim iPanels As Int16 = oRead.ReadInt16()
            Dim iCount As Int16 = oRead.ReadInt16()
            Dim iFrameRate As Int16 = oRead.ReadInt16()
            cbPanels.SelectedIndex = -1
            cbPanels.SelectedIndex = iPanels - 1
            txFrameRate.Text = LTrim(Str(iFrameRate))
            For c = 0 To iCount - 1
                If c <> 0 Then MyMovie.Add()
                If iVersion = 1 Then
                    For i As Int16 = MyMovie.pPanels - 1 To 0 Step -1
                        For l = 0 To 7
                            MyMovie.CurrentFrame.Cells(i).Bytes(l) = oRead.ReadByte()
                        Next
                    Next
                Else
                    For i As Int16 = 0 To MyMovie.pPanels - 1
                        For l = 0 To 7
                            MyMovie.CurrentFrame.Cells(i).Bytes(l) = oRead.ReadByte()
                        Next
                    Next
                End If
                LoadAllPanels()
                Application.DoEvents()
            Next
            oRead.Close()
        End If
        MyMovie.Frst()
        LoadAllPanels()
        DisplayStatus()
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        If btnPlay.Text = "STOP" Then
            Timer1.Enabled = False
            btnPlay.Text = "Play"
        Else
            btnPlay.Text = "STOP"
            MyMovie.Frst()
            LoadAllPanels()
            Timer1.Interval = CInt(txFrameRate.Text)
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MyMovie.Nxt()
        LoadAllPanels()
    End Sub

 
    Private Sub ShiftLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftLeft.Click
        Dim f As Frame = MyMovie.CurrentFrame()
        Dim Carry As Byte = 0
        Dim Hold As Byte = 0
        Dim bCell As Byte = 0
        For ir As Integer = 0 To 7
            Carry = 0
            For ic As Integer = MyMovie.pPanels - 1 To 0 Step -1
                bCell = f.Cells(ic).Bytes(ir)
                If (bCell And 128) > 0 Then Hold = 1 Else Hold = 0
                f.Cells(ic).Bytes(ir) = (bCell << 1) Or Carry
                If (ic = 0 And Hold = 1 And chkWrap.Checked) Then f.Cells(MyMovie.pPanels - 1).Bytes(ir) = f.Cells(MyMovie.pPanels - 1).Bytes(ir) Or 1
                Carry = Hold
            Next
        Next
        LoadAllPanels()
    End Sub


    Private Sub ShiftRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftRight.Click
        Dim f As Frame = MyMovie.CurrentFrame()
        Dim Carry As Byte = 0
        Dim Hold As Byte = 0
        Dim bCell As Byte = 0
        For ir As Integer = 0 To 7
            Carry = 0
            For ic As Integer = 0 To MyMovie.pPanels - 1
                bCell = f.Cells(ic).Bytes(ir)
                If (bCell And 1) > 0 Then Hold = 128 Else Hold = 0
                f.Cells(ic).Bytes(ir) = (bCell >> 1) Or Carry
                If (ic = MyMovie.pPanels - 1 And Hold = 128 And chkWrap.Checked) Then f.Cells(0).Bytes(ir) = f.Cells(0).Bytes(ir) Or 128
                Carry = Hold
            Next
        Next
        LoadAllPanels()
    End Sub

    Private Sub Insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        MyMovie.Insert()
        Update_Click(Me, e)
        DisplayStatus()
    End Sub

    Private Sub btnComm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComm.Click
        If cbPanels.SelectedIndex = -1 Then Exit Sub
        Dim dgl1 As New Dialog1
        Dialog1.Show()
    End Sub

    Private Sub Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim f As Frame = MyMovie.CurrentFrame()
        Dim Carry As Byte = 0
        Dim Hold As Byte = 0
        Dim bCell As Byte = 0
        For ic As Integer = 0 To MyMovie.pPanels - 1
            If chkWrap.Checked Then Carry = f.Cells(ic).Bytes(0) Else Carry = 0
            For ir As Integer = 1 To 7
                bCell = f.Cells(ic).Bytes(ir)
                f.Cells(ic).Bytes(ir - 1) = bCell
            Next
            f.Cells(ic).Bytes(7) = Carry
        Next
        LoadAllPanels()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim f As Frame = MyMovie.CurrentFrame()
        Dim Carry As Byte = 0
        Dim Hold As Byte = 0
        Dim bCell As Byte = 0
        For ic As Integer = 0 To MyMovie.pPanels - 1
            If chkWrap.Checked Then Carry = f.Cells(ic).Bytes(7) Else Carry = 0
            For ir As Integer = 6 To 0 Step -1
                bCell = f.Cells(ic).Bytes(ir)
                f.Cells(ic).Bytes(ir + 1) = bCell
            Next
            f.Cells(ic).Bytes(0) = Carry
        Next
        LoadAllPanels()
    End Sub
End Class

Public Class Cell
    Public Bytes As List(Of Byte)

    Public Sub New()
        SetBytes(0, 0, 0, 0, 0, 0, 0, 0)
    End Sub

    Public Sub New(ByVal l0 As Byte, ByVal l1 As Byte, ByVal l2 As Byte, ByVal l3 As Byte, ByVal l4 As Byte, ByVal l5 As Byte, ByVal l6 As Byte, ByVal l7 As Byte)
        SetBytes(l0, l1, l2, l3, l4, l5, l6, l7)
    End Sub

    Public Sub Update(ByVal l0 As Byte, ByVal l1 As Byte, ByVal l2 As Byte, ByVal l3 As Byte, ByVal l4 As Byte, ByVal l5 As Byte, ByVal l6 As Byte, ByVal l7 As Byte)
        SetBytes(l0, l1, l2, l3, l4, l5, l6, l7)
    End Sub

    Private Sub SetBytes(ByVal l0 As Byte, ByVal l1 As Byte, ByVal l2 As Byte, ByVal l3 As Byte, ByVal l4 As Byte, ByVal l5 As Byte, ByVal l6 As Byte, ByVal l7 As Byte)
        Bytes = New List(Of Byte)
        Bytes.Add(l0)
        Bytes.Add(l2)
        Bytes.Add(l2)
        Bytes.Add(l3)
        Bytes.Add(l4)
        Bytes.Add(l5)
        Bytes.Add(l6)
        Bytes.Add(l7)
    End Sub
End Class

Public Class Frame
    Public Cells As List(Of Cell)
    Public Sub New(ByVal Count As Integer)
        Cells = New List(Of Cell)
        For i = 0 To Count
            Cells.Add(New Cell())
        Next
    End Sub
End Class

Public Class Movie
    Public pPanels As Integer = 0
    Public idx As Integer = 0
    Public Count As Integer = 0
    Public Frames As New List(Of Frame)
    Public Sub New(ByVal Panels As Integer)
        pPanels = Panels
        Add()
    End Sub
    Public Sub Add()
        Frames.Add(New Frame(pPanels))
        Count += 1
        idx = Count - 1
    End Sub
    Public Sub Insert()
        Frames.Insert(idx + 1, New Frame(pPanels))
        Count += 1
        idx += 1
    End Sub
    Public Function Status() As String
        Return LTrim(Str(idx + 1)) & " of " & LTrim(Str(Count)) & " = " & LTrim(Str(((8 * pPanels) * Count) + 8)) & " bytes"
    End Function
    Public Function CurrentFrame() As Frame
        Return Frames(idx)
    End Function
    Public Function DeleteCurrentFrame()
        Frames.RemoveAt(idx)
        idx -= 1
        If idx < 0 Then idx = 0
        Count -= 1
        If Count < 0 Then Count = 0
    End Function
    Public Function Nxt() As Integer
        idx += 1
        If idx > Count - 1 Then idx = 0
        If idx < 0 Then idx = 0
    End Function
    Public Function Prv() As Integer
        idx -= 1
        If idx < 0 Then idx = Count - 1
        If idx < 0 Then idx = 0
    End Function
    Public Function Lst() As Integer
        idx = Count - 1
        If idx < 0 Then idx = 0
    End Function
    Public Function Frst() As Integer
        idx = 0
    End Function


End Class