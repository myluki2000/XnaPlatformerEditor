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
        Me.lblLastWorldPath = New System.Windows.Forms.Label()
        Me.btnLoadLast = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnNewWorld
        '
        Me.btnNewWorld.Location = New System.Drawing.Point(15, 12)
        Me.btnNewWorld.Name = "btnNewWorld"
        Me.btnNewWorld.Size = New System.Drawing.Size(126, 62)
        Me.btnNewWorld.TabIndex = 0
        Me.btnNewWorld.Text = "New World"
        Me.btnNewWorld.UseVisualStyleBackColor = True
        '
        'btnLoadWorld
        '
        Me.btnLoadWorld.Location = New System.Drawing.Point(169, 12)
        Me.btnLoadWorld.Name = "btnLoadWorld"
        Me.btnLoadWorld.Size = New System.Drawing.Size(127, 62)
        Me.btnLoadWorld.TabIndex = 1
        Me.btnLoadWorld.Text = "Load World"
        Me.btnLoadWorld.UseVisualStyleBackColor = True
        '
        'lblLastWorldPath
        '
        Me.lblLastWorldPath.Location = New System.Drawing.Point(12, 77)
        Me.lblLastWorldPath.Name = "lblLastWorldPath"
        Me.lblLastWorldPath.Size = New System.Drawing.Size(284, 42)
        Me.lblLastWorldPath.TabIndex = 2
        Me.lblLastWorldPath.Text = "Last World:"
        Me.lblLastWorldPath.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnLoadLast
        '
        Me.btnLoadLast.Enabled = False
        Me.btnLoadLast.Location = New System.Drawing.Point(12, 122)
        Me.btnLoadLast.Name = "btnLoadLast"
        Me.btnLoadLast.Size = New System.Drawing.Size(284, 23)
        Me.btnLoadLast.TabIndex = 3
        Me.btnLoadLast.Text = "Load Last World"
        Me.btnLoadLast.UseVisualStyleBackColor = True
        '
        'StartWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 155)
        Me.Controls.Add(Me.btnLoadLast)
        Me.Controls.Add(Me.lblLastWorldPath)
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
    Friend WithEvents lblLastWorldPath As Windows.Forms.Label
    Friend WithEvents btnLoadLast As Windows.Forms.Button
End Class
