<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                If SerialPort1.IsOpen() Then SerialPort1.Close()
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
        Me.btnUpload = New System.Windows.Forms.Button
        Me.txtIpAddress = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbBaudRate = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbSerial = New System.Windows.Forms.ComboBox
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnStream = New System.Windows.Forms.Button
        Me.btnCommRefresh = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnPlay = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnUpload
        '
        Me.btnUpload.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpload.Location = New System.Drawing.Point(219, 12)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(121, 23)
        Me.btnUpload.TabIndex = 0
        Me.btnUpload.Text = "Upload to Board"
        '
        'txtIpAddress
        '
        Me.txtIpAddress.Location = New System.Drawing.Point(76, 74)
        Me.txtIpAddress.Name = "txtIpAddress"
        Me.txtIpAddress.Size = New System.Drawing.Size(123, 20)
        Me.txtIpAddress.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "IP Address"
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"300", "1200", "2400", "9600", "14400", "19200", "28800", "38400", "57600", "115200"})
        Me.cbBaudRate.Location = New System.Drawing.Point(76, 44)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(87, 21)
        Me.cbBaudRate.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Baud Rate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Serial Port"
        '
        'cbSerial
        '
        Me.cbSerial.FormattingEnabled = True
        Me.cbSerial.Location = New System.Drawing.Point(76, 13)
        Me.cbSerial.Name = "cbSerial"
        Me.cbSerial.Size = New System.Drawing.Size(87, 21)
        Me.cbSerial.Sorted = True
        Me.cbSerial.TabIndex = 14
        '
        'btnQuit
        '
        Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnQuit.Location = New System.Drawing.Point(219, 100)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(121, 23)
        Me.btnQuit.TabIndex = 20
        Me.btnQuit.Text = "Quit"
        '
        'btnStream
        '
        Me.btnStream.Location = New System.Drawing.Point(219, 43)
        Me.btnStream.Name = "btnStream"
        Me.btnStream.Size = New System.Drawing.Size(121, 23)
        Me.btnStream.TabIndex = 1
        Me.btnStream.Text = "Stream to Board"
        '
        'btnCommRefresh
        '
        Me.btnCommRefresh.Location = New System.Drawing.Point(170, 11)
        Me.btnCommRefresh.Name = "btnCommRefresh"
        Me.btnCommRefresh.Size = New System.Drawing.Size(29, 23)
        Me.btnCommRefresh.TabIndex = 21
        Me.btnCommRefresh.Text = "..."
        Me.btnCommRefresh.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 105)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 22
        Me.lblStatus.Text = "Status:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(18, 133)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(321, 64)
        Me.TextBox1.TabIndex = 23
        Me.TextBox1.Visible = False
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(21, 203)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(68, 23)
        Me.btnPlay.TabIndex = 24
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        Me.btnPlay.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(95, 203)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 23)
        Me.btnClear.TabIndex = 25
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'Timer1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(218, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "TEST"
        Me.Button1.Visible = False
        '
        'Dialog1
        '
        Me.AcceptButton = Me.btnUpload
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnQuit
        Me.ClientSize = New System.Drawing.Size(359, 129)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnCommRefresh)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnStream)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.txtIpAddress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbBaudRate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbSerial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "8x8 Communications"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtIpAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbSerial As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnStream As System.Windows.Forms.Button
    Friend WithEvents btnCommRefresh As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
