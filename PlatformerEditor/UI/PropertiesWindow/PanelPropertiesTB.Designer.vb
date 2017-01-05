<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelPropertiesTB
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
        Me.TBValue = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TBValue
        '
        Me.TBValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBValue.Location = New System.Drawing.Point(60, 3)
        Me.TBValue.Name = "TBValue"
        Me.TBValue.Size = New System.Drawing.Size(408, 21)
        Me.TBValue.TabIndex = 3
        '
        'LabelDescription
        '
        Me.LabelDescription.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelDescription.Location = New System.Drawing.Point(0, 0)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 27)
        Me.LabelDescription.TabIndex = 2
        Me.LabelDescription.Text = "Label1"
        Me.LabelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelPropertiesTB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TBValue)
        Me.Controls.Add(Me.LabelDescription)
        Me.Name = "PanelPropertiesTB"
        Me.Size = New System.Drawing.Size(468, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TBValue As Windows.Forms.TextBox
    Friend WithEvents LabelDescription As Windows.Forms.Label
End Class
