<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialoguePropertiesForm
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
        Me.lvSegments = New System.Windows.Forms.ListView()
        Me.cTexPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cReset = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cDeactivate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAddSegment = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvSegments
        '
        Me.lvSegments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cTexPath, Me.cText, Me.cReset, Me.cDeactivate})
        Me.lvSegments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSegments.Location = New System.Drawing.Point(0, 0)
        Me.lvSegments.Name = "lvSegments"
        Me.lvSegments.Size = New System.Drawing.Size(1070, 428)
        Me.lvSegments.TabIndex = 0
        Me.lvSegments.UseCompatibleStateImageBehavior = False
        '
        'cTexPath
        '
        Me.cTexPath.Text = "Face Texture Path"
        '
        'cText
        '
        Me.cText.Text = "Text"
        '
        'cReset
        '
        Me.cReset.Text = "Reset after Segment"
        '
        'cDeactivate
        '
        Me.cDeactivate.Text = "Deactivate after Segment"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lvSegments)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1070, 428)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAddSegment)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 427)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1070, 52)
        Me.Panel2.TabIndex = 2
        '
        'btnAddSegment
        '
        Me.btnAddSegment.Location = New System.Drawing.Point(971, 7)
        Me.btnAddSegment.Name = "btnAddSegment"
        Me.btnAddSegment.Size = New System.Drawing.Size(87, 33)
        Me.btnAddSegment.TabIndex = 0
        Me.btnAddSegment.Text = "Add Segment"
        Me.btnAddSegment.UseVisualStyleBackColor = True
        '
        'DialoguePropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 479)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DialoguePropertiesForm"
        Me.Text = "DialogueProperties"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvSegments As Windows.Forms.ListView
    Friend WithEvents cTexPath As Windows.Forms.ColumnHeader
    Friend WithEvents cText As Windows.Forms.ColumnHeader
    Friend WithEvents cReset As Windows.Forms.ColumnHeader
    Friend WithEvents cDeactivate As Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnAddSegment As Windows.Forms.Button
End Class
