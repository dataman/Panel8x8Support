<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnlTools = New System.Windows.Forms.Panel
        Me.chkWrap = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.btnInsert = New System.Windows.Forms.Button
        Me.btnComm = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.txFrameRate = New System.Windows.Forms.TextBox
        Me.btnPlay = New System.Windows.Forms.Button
        Me.btnShiftRight = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnShiftLeft = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.lblPanels = New System.Windows.Forms.Label
        Me.cbPanels = New System.Windows.Forms.ComboBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.pnlTools.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTools
        '
        Me.pnlTools.BackColor = System.Drawing.Color.White
        Me.pnlTools.Controls.Add(Me.chkWrap)
        Me.pnlTools.Controls.Add(Me.Button4)
        Me.pnlTools.Controls.Add(Me.btnInsert)
        Me.pnlTools.Controls.Add(Me.btnComm)
        Me.pnlTools.Controls.Add(Me.Button3)
        Me.pnlTools.Controls.Add(Me.txFrameRate)
        Me.pnlTools.Controls.Add(Me.btnPlay)
        Me.pnlTools.Controls.Add(Me.btnShiftRight)
        Me.pnlTools.Controls.Add(Me.btnSave)
        Me.pnlTools.Controls.Add(Me.btnShiftLeft)
        Me.pnlTools.Controls.Add(Me.btnLoad)
        Me.pnlTools.Controls.Add(Me.btnDel)
        Me.pnlTools.Controls.Add(Me.lblStatus)
        Me.pnlTools.Controls.Add(Me.btnAdd)
        Me.pnlTools.Controls.Add(Me.btnLast)
        Me.pnlTools.Controls.Add(Me.btnNext)
        Me.pnlTools.Controls.Add(Me.btnPrev)
        Me.pnlTools.Controls.Add(Me.btnFirst)
        Me.pnlTools.Controls.Add(Me.btnClear)
        Me.pnlTools.Controls.Add(Me.lblPanels)
        Me.pnlTools.Controls.Add(Me.cbPanels)
        Me.pnlTools.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTools.Location = New System.Drawing.Point(0, 0)
        Me.pnlTools.Name = "pnlTools"
        Me.pnlTools.Size = New System.Drawing.Size(872, 25)
        Me.pnlTools.TabIndex = 16
        '
        'chkWrap
        '
        Me.chkWrap.AutoSize = True
        Me.chkWrap.Location = New System.Drawing.Point(558, 1)
        Me.chkWrap.Name = "chkWrap"
        Me.chkWrap.Size = New System.Drawing.Size(49, 17)
        Me.chkWrap.TabIndex = 36
        Me.chkWrap.Text = "wrap"
        Me.chkWrap.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(524, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 21)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "dn"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(377, 1)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(34, 21)
        Me.btnInsert.TabIndex = 34
        Me.btnInsert.TabStop = False
        Me.btnInsert.Text = "ins"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnComm
        '
        Me.btnComm.Location = New System.Drawing.Point(810, 1)
        Me.btnComm.Name = "btnComm"
        Me.btnComm.Size = New System.Drawing.Size(50, 21)
        Me.btnComm.TabIndex = 35
        Me.btnComm.Text = "Comm"
        Me.btnComm.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(496, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 21)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "up"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txFrameRate
        '
        Me.txFrameRate.Location = New System.Drawing.Point(608, 1)
        Me.txFrameRate.Name = "txFrameRate"
        Me.txFrameRate.Size = New System.Drawing.Size(33, 20)
        Me.txFrameRate.TabIndex = 33
        Me.txFrameRate.Text = "100"
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(641, 1)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(50, 21)
        Me.btnPlay.TabIndex = 32
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnShiftRight
        '
        Me.btnShiftRight.Location = New System.Drawing.Point(468, 1)
        Me.btnShiftRight.Name = "btnShiftRight"
        Me.btnShiftRight.Size = New System.Drawing.Size(28, 21)
        Me.btnShiftRight.TabIndex = 22
        Me.btnShiftRight.Text = ">>"
        Me.btnShiftRight.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(741, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(50, 21)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnShiftLeft
        '
        Me.btnShiftLeft.Location = New System.Drawing.Point(440, 1)
        Me.btnShiftLeft.Name = "btnShiftLeft"
        Me.btnShiftLeft.Size = New System.Drawing.Size(28, 21)
        Me.btnShiftLeft.TabIndex = 21
        Me.btnShiftLeft.Text = "<<"
        Me.btnShiftLeft.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(691, 1)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(50, 21)
        Me.btnLoad.TabIndex = 30
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(343, 1)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(34, 21)
        Me.btnDel.TabIndex = 19
        Me.btnDel.TabStop = False
        Me.btnDel.Text = "del"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(85, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(80, 13)
        Me.lblStatus.TabIndex = 29
        Me.lblStatus.Text = "0 of 0 = 0 bytes"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(309, 1)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(34, 21)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.TabStop = False
        Me.btnAdd.Text = "add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(281, 1)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(28, 21)
        Me.btnLast.TabIndex = 27
        Me.btnLast.Text = ">|"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(253, 1)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(28, 21)
        Me.btnNext.TabIndex = 26
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(225, 1)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(28, 21)
        Me.btnPrev.TabIndex = 25
        Me.btnPrev.Text = "<"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(197, 1)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(28, 21)
        Me.btnFirst.TabIndex = 24
        Me.btnFirst.Text = "|<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(411, 1)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(28, 21)
        Me.btnClear.TabIndex = 23
        Me.btnClear.Text = "clr"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblPanels
        '
        Me.lblPanels.AutoSize = True
        Me.lblPanels.Location = New System.Drawing.Point(4, 5)
        Me.lblPanels.Name = "lblPanels"
        Me.lblPanels.Size = New System.Drawing.Size(39, 13)
        Me.lblPanels.TabIndex = 17
        Me.lblPanels.Text = "Panels"
        '
        'cbPanels
        '
        Me.cbPanels.FormattingEnabled = True
        Me.cbPanels.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cbPanels.Location = New System.Drawing.Point(47, 0)
        Me.cbPanels.Name = "cbPanels"
        Me.cbPanels.Size = New System.Drawing.Size(32, 21)
        Me.cbPanels.TabIndex = 16
        '
        'Timer1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 411)
        Me.Controls.Add(Me.pnlTools)
        Me.Name = "Form1"
        Me.Text = "8x8 Panel Animator"
        Me.pnlTools.ResumeLayout(False)
        Me.pnlTools.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTools As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnShiftRight As System.Windows.Forms.Button
    Friend WithEvents btnShiftLeft As System.Windows.Forms.Button
    Friend WithEvents lblPanels As System.Windows.Forms.Label
    Friend WithEvents cbPanels As System.Windows.Forms.ComboBox
    Friend WithEvents txFrameRate As System.Windows.Forms.TextBox
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnComm As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents chkWrap As System.Windows.Forms.CheckBox

End Class
