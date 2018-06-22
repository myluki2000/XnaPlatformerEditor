<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartWindow
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnNewWorld = New System.Windows.Forms.Button()
        Me.btnLoadWorld = New System.Windows.Forms.Button()
        Me.fbdWorldPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'btnNewWorld
        '
        Me.btnNewWorld.Location = New System.Drawing.Point(12, 12)
        Me.btnNewWorld.Name = "btnNewWorld"
        Me.btnNewWorld.Size = New System.Drawing.Size(98, 62)
        Me.btnNewWorld.TabIndex = 0
        Me.btnNewWorld.Text = "New World"
        Me.btnNewWorld.UseVisualStyleBackColor = True
        '
        'btnLoadWorld
        '
        Me.btnLoadWorld.Location = New System.Drawing.Point(117, 12)
        Me.btnLoadWorld.Name = "btnLoadWorld"
        Me.btnLoadWorld.Size = New System.Drawing.Size(98, 62)
        Me.btnLoadWorld.TabIndex = 1
        Me.btnLoadWorld.Text = "Load World"
        Me.btnLoadWorld.UseVisualStyleBackColor = True
        '
        'StartWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 87)
        Me.Controls.Add(Me.btnLoadWorld)
        Me.Controls.Add(Me.btnNewWorld)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "StartWindow"
        Me.Text = "StartWindow"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnNewWorld As Windows.Forms.Button
    Friend WithEvents btnLoadWorld As Windows.Forms.Button
    Friend WithEvents fbdWorldPath As Windows.Forms.FolderBrowserDialog
End Class
