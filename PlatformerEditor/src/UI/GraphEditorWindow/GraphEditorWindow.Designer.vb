<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphEditorWindow
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
        Me.components = New System.ComponentModel.Container()
        Me.cmsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmiAddNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlNodes = New System.Windows.Forms.Panel()
        Me.cmsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsMain
        '
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmiAddNode})
        Me.cmsMain.Name = "cmsMain"
        Me.cmsMain.Size = New System.Drawing.Size(129, 26)
        '
        'cmiAddNode
        '
        Me.cmiAddNode.Name = "cmiAddNode"
        Me.cmiAddNode.Size = New System.Drawing.Size(128, 22)
        Me.cmiAddNode.Text = "Add Node"
        '
        'pnlNodes
        '
        Me.pnlNodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNodes.Location = New System.Drawing.Point(0, 0)
        Me.pnlNodes.Name = "pnlNodes"
        Me.pnlNodes.Size = New System.Drawing.Size(800, 450)
        Me.pnlNodes.TabIndex = 1
        '
        'GraphEditorWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ContextMenuStrip = Me.cmsMain
        Me.Controls.Add(Me.pnlNodes)
        Me.Name = "GraphEditorWindow"
        Me.Text = "GraphEditorWindow"
        Me.cmsMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsMain As Windows.Forms.ContextMenuStrip
    Friend WithEvents cmiAddNode As Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlNodes As Windows.Forms.Panel
End Class
