<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSegmentForm
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
        Me.tbPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbText = New System.Windows.Forms.TextBox()
        Me.cbReset = New System.Windows.Forms.CheckBox()
        Me.cbDeactivate = New System.Windows.Forms.CheckBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbPath
        '
        Me.tbPath.Location = New System.Drawing.Point(113, 12)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.Size = New System.Drawing.Size(330, 20)
        Me.tbPath.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Face Texture Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Text"
        '
        'tbText
        '
        Me.tbText.Location = New System.Drawing.Point(113, 38)
        Me.tbText.Multiline = True
        Me.tbText.Name = "tbText"
        Me.tbText.Size = New System.Drawing.Size(330, 120)
        Me.tbText.TabIndex = 2
        '
        'cbReset
        '
        Me.cbReset.AutoSize = True
        Me.cbReset.Location = New System.Drawing.Point(165, 164)
        Me.cbReset.Name = "cbReset"
        Me.cbReset.Size = New System.Drawing.Size(124, 17)
        Me.cbReset.TabIndex = 4
        Me.cbReset.Text = "Reset After Segment"
        Me.cbReset.UseVisualStyleBackColor = True
        '
        'cbDeactivate
        '
        Me.cbDeactivate.AutoSize = True
        Me.cbDeactivate.Location = New System.Drawing.Point(295, 164)
        Me.cbDeactivate.Name = "cbDeactivate"
        Me.cbDeactivate.Size = New System.Drawing.Size(148, 17)
        Me.cbDeactivate.TabIndex = 5
        Me.cbDeactivate.Text = "Deactivate After Segment"
        Me.cbDeactivate.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(361, 187)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(82, 23)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(273, 187)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(82, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'EditSegmentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 222)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cbDeactivate)
        Me.Controls.Add(Me.cbReset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(469, 261)
        Me.MinimumSize = New System.Drawing.Size(469, 261)
        Me.Name = "EditSegmentForm"
        Me.Text = "EditSegmentForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbPath As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents tbText As Windows.Forms.TextBox
    Friend WithEvents cbReset As Windows.Forms.CheckBox
    Friend WithEvents cbDeactivate As Windows.Forms.CheckBox
    Friend WithEvents btnOk As Windows.Forms.Button
    Friend WithEvents btnCancel As Windows.Forms.Button
End Class
