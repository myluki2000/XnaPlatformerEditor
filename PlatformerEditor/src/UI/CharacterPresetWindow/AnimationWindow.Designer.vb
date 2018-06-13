<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnimationWindow
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudFrameDuration = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudIterationCount = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudRectHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudRectWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudRectY = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudRectX = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudFrameCount = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.nudFrameDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIterationCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudRectHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRectWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRectY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRectX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFrameCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(100, 10)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(203, 20)
        Me.tbName.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudFrameDuration
        '
        Me.nudFrameDuration.Location = New System.Drawing.Point(100, 36)
        Me.nudFrameDuration.Name = "nudFrameDuration"
        Me.nudFrameDuration.Size = New System.Drawing.Size(203, 20)
        Me.nudFrameDuration.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Frame Duration:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudIterationCount
        '
        Me.nudIterationCount.Location = New System.Drawing.Point(100, 62)
        Me.nudIterationCount.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudIterationCount.Name = "nudIterationCount"
        Me.nudIterationCount.Size = New System.Drawing.Size(203, 20)
        Me.nudIterationCount.TabIndex = 11
        Me.nudIterationCount.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Iteration Count:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudRectHeight)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nudRectWidth)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.nudRectY)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.nudRectX)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 120)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 80)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frame Rectangle"
        '
        'nudRectHeight
        '
        Me.nudRectHeight.Location = New System.Drawing.Point(190, 47)
        Me.nudRectHeight.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.nudRectHeight.Name = "nudRectHeight"
        Me.nudRectHeight.Size = New System.Drawing.Size(92, 20)
        Me.nudRectHeight.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(143, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Height:"
        '
        'nudRectWidth
        '
        Me.nudRectWidth.Location = New System.Drawing.Point(190, 21)
        Me.nudRectWidth.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.nudRectWidth.Name = "nudRectWidth"
        Me.nudRectWidth.Size = New System.Drawing.Size(92, 20)
        Me.nudRectWidth.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(146, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Width:"
        '
        'nudRectY
        '
        Me.nudRectY.Location = New System.Drawing.Point(29, 47)
        Me.nudRectY.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.nudRectY.Name = "nudRectY"
        Me.nudRectY.Size = New System.Drawing.Size(92, 20)
        Me.nudRectY.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Y:"
        '
        'nudRectX
        '
        Me.nudRectX.Location = New System.Drawing.Point(29, 21)
        Me.nudRectX.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.nudRectX.Name = "nudRectX"
        Me.nudRectX.Size = New System.Drawing.Size(92, 20)
        Me.nudRectX.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "X:"
        '
        'nudFrameCount
        '
        Me.nudFrameCount.Location = New System.Drawing.Point(100, 88)
        Me.nudFrameCount.Name = "nudFrameCount"
        Me.nudFrameCount.Size = New System.Drawing.Size(203, 20)
        Me.nudFrameCount.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Frame Count:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AnimationWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 206)
        Me.Controls.Add(Me.nudFrameCount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.nudIterationCount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudFrameDuration)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AnimationWindow"
        Me.Text = "AnimationWindow"
        CType(Me.nudFrameDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIterationCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudRectHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRectWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRectY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRectX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFrameCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbName As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents nudFrameDuration As Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents nudIterationCount As Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents nudRectHeight As Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents nudRectWidth As Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents nudRectY As Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents nudRectX As Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents nudFrameCount As Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As Windows.Forms.Label
End Class
