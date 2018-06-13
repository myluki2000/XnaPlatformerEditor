<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelPropertiesCB
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
        Me.CBProperty = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CBProperty
        '
        Me.CBProperty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBProperty.Location = New System.Drawing.Point(5, 5)
        Me.CBProperty.Margin = New System.Windows.Forms.Padding(5)
        Me.CBProperty.Name = "CBProperty"
        Me.CBProperty.Size = New System.Drawing.Size(458, 29)
        Me.CBProperty.TabIndex = 0
        Me.CBProperty.Text = "CheckBox1"
        Me.CBProperty.UseVisualStyleBackColor = True
        '
        'PanelPropertiesCB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CBProperty)
        Me.Name = "PanelPropertiesCB"
        Me.Size = New System.Drawing.Size(468, 39)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CBProperty As Windows.Forms.CheckBox
End Class
