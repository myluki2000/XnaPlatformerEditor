<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpLevels = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lvLevels = New System.Windows.Forms.ListView()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chObjCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAddLevel = New System.Windows.Forms.Button()
        Me.tpCharacters = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lvCharacters = New System.Windows.Forms.ListView()
        Me.chCharName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCharTexturePath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCharType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAddChar = New System.Windows.Forms.Button()
        Me.tpDialogues = New System.Windows.Forms.TabPage()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSaveWorld = New System.Windows.Forms.Button()
        Me.btnDeleteLevel = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tpLevels.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.tpCharacters.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tpDialogues.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpLevels)
        Me.TabControl1.Controls.Add(Me.tpCharacters)
        Me.TabControl1.Controls.Add(Me.tpDialogues)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(887, 414)
        Me.TabControl1.TabIndex = 0
        '
        'tpLevels
        '
        Me.tpLevels.Controls.Add(Me.Panel3)
        Me.tpLevels.Controls.Add(Me.Panel4)
        Me.tpLevels.Location = New System.Drawing.Point(4, 22)
        Me.tpLevels.Name = "tpLevels"
        Me.tpLevels.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLevels.Size = New System.Drawing.Size(879, 388)
        Me.tpLevels.TabIndex = 0
        Me.tpLevels.Text = "Levels"
        Me.tpLevels.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lvLevels)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(873, 346)
        Me.Panel3.TabIndex = 0
        '
        'lvLevels
        '
        Me.lvLevels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chObjCount})
        Me.lvLevels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvLevels.Location = New System.Drawing.Point(0, 0)
        Me.lvLevels.Name = "lvLevels"
        Me.lvLevels.Size = New System.Drawing.Size(873, 346)
        Me.lvLevels.TabIndex = 0
        Me.lvLevels.UseCompatibleStateImageBehavior = False
        Me.lvLevels.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Level Name"
        '
        'chObjCount
        '
        Me.chObjCount.Text = "WorldObject Count"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnDeleteLevel)
        Me.Panel4.Controls.Add(Me.btnAddLevel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 349)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(873, 36)
        Me.Panel4.TabIndex = 1
        '
        'btnAddLevel
        '
        Me.btnAddLevel.Location = New System.Drawing.Point(757, 6)
        Me.btnAddLevel.Name = "btnAddLevel"
        Me.btnAddLevel.Size = New System.Drawing.Size(113, 25)
        Me.btnAddLevel.TabIndex = 1
        Me.btnAddLevel.Text = "Add Level"
        Me.btnAddLevel.UseVisualStyleBackColor = True
        '
        'tpCharacters
        '
        Me.tpCharacters.Controls.Add(Me.Panel1)
        Me.tpCharacters.Controls.Add(Me.Panel2)
        Me.tpCharacters.Location = New System.Drawing.Point(4, 22)
        Me.tpCharacters.Name = "tpCharacters"
        Me.tpCharacters.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCharacters.Size = New System.Drawing.Size(879, 388)
        Me.tpCharacters.TabIndex = 1
        Me.tpCharacters.Text = "Character Presets"
        Me.tpCharacters.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lvCharacters)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 346)
        Me.Panel1.TabIndex = 1
        '
        'lvCharacters
        '
        Me.lvCharacters.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chCharName, Me.chCharTexturePath, Me.chCharType})
        Me.lvCharacters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvCharacters.Location = New System.Drawing.Point(0, 0)
        Me.lvCharacters.Name = "lvCharacters"
        Me.lvCharacters.Size = New System.Drawing.Size(873, 346)
        Me.lvCharacters.TabIndex = 1
        Me.lvCharacters.UseCompatibleStateImageBehavior = False
        Me.lvCharacters.View = System.Windows.Forms.View.Details
        '
        'chCharName
        '
        Me.chCharName.Text = "Name"
        '
        'chCharTexturePath
        '
        Me.chCharTexturePath.Text = "Texture Path"
        '
        'chCharType
        '
        Me.chCharType.Text = "Type"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAddChar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 349)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(873, 36)
        Me.Panel2.TabIndex = 2
        '
        'btnAddChar
        '
        Me.btnAddChar.Location = New System.Drawing.Point(757, 6)
        Me.btnAddChar.Name = "btnAddChar"
        Me.btnAddChar.Size = New System.Drawing.Size(113, 25)
        Me.btnAddChar.TabIndex = 0
        Me.btnAddChar.Text = "Add Character"
        Me.btnAddChar.UseVisualStyleBackColor = True
        '
        'tpDialogues
        '
        Me.tpDialogues.Controls.Add(Me.ListView1)
        Me.tpDialogues.Controls.Add(Me.Panel5)
        Me.tpDialogues.Location = New System.Drawing.Point(4, 22)
        Me.tpDialogues.Name = "tpDialogues"
        Me.tpDialogues.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDialogues.Size = New System.Drawing.Size(879, 388)
        Me.tpDialogues.TabIndex = 2
        Me.tpDialogues.Text = "Dialogues"
        Me.tpDialogues.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(873, 343)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 346)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(873, 39)
        Me.Panel5.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(775, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Add Dialogue"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnSaveWorld
        '
        Me.btnSaveWorld.Location = New System.Drawing.Point(794, 0)
        Me.btnSaveWorld.Name = "btnSaveWorld"
        Me.btnSaveWorld.Size = New System.Drawing.Size(86, 20)
        Me.btnSaveWorld.TabIndex = 1
        Me.btnSaveWorld.Text = "Save World"
        Me.btnSaveWorld.UseVisualStyleBackColor = True
        '
        'btnDeleteLevel
        '
        Me.btnDeleteLevel.Location = New System.Drawing.Point(638, 6)
        Me.btnDeleteLevel.Name = "btnDeleteLevel"
        Me.btnDeleteLevel.Size = New System.Drawing.Size(113, 25)
        Me.btnDeleteLevel.TabIndex = 2
        Me.btnDeleteLevel.Text = "Delete Level"
        Me.btnDeleteLevel.UseVisualStyleBackColor = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 414)
        Me.Controls.Add(Me.btnSaveWorld)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "MainWindow"
        Me.Text = "MainWindow"
        Me.TabControl1.ResumeLayout(False)
        Me.tpLevels.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.tpCharacters.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tpDialogues.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents tpLevels As Windows.Forms.TabPage
    Friend WithEvents tpCharacters As Windows.Forms.TabPage
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lvCharacters As Windows.Forms.ListView
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnAddChar As Windows.Forms.Button
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents btnAddLevel As Windows.Forms.Button
    Friend WithEvents lvLevels As Windows.Forms.ListView
    Friend WithEvents chName As Windows.Forms.ColumnHeader
    Friend WithEvents chObjCount As Windows.Forms.ColumnHeader
    Friend WithEvents chCharName As Windows.Forms.ColumnHeader
    Friend WithEvents chCharTexturePath As Windows.Forms.ColumnHeader
    Friend WithEvents chCharType As Windows.Forms.ColumnHeader
    Friend WithEvents btnSaveWorld As Windows.Forms.Button
    Friend WithEvents tpDialogues As Windows.Forms.TabPage
    Friend WithEvents ListView1 As Windows.Forms.ListView
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents btnDeleteLevel As Windows.Forms.Button
End Class
