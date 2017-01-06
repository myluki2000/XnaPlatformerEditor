<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelPropertiesCombo
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.ComboValue = New System.Windows.Forms.ComboBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ComboValue
        '
        Me.ComboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboValue.FormattingEnabled = True
        Me.ComboValue.Location = New System.Drawing.Point(66, 3)
        Me.ComboValue.Name = "ComboValue"
        Me.ComboValue.Size = New System.Drawing.Size(402, 23)
        Me.ComboValue.TabIndex = 0
        '
        'LabelDescription
        '
        Me.LabelDescription.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelDescription.Location = New System.Drawing.Point(0, 0)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 29)
        Me.LabelDescription.TabIndex = 3
        Me.LabelDescription.Text = "Label1"
        Me.LabelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelPropertiesCombo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.ComboValue)
        Me.Name = "PanelPropertiesCombo"
        Me.Size = New System.Drawing.Size(468, 29)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboValue As Windows.Forms.ComboBox
    Friend WithEvents LabelDescription As Windows.Forms.Label
End Class
