<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TexturesWindow
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lvTextures = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlProperties = New System.Windows.Forms.Panel()
        Me.cbFoliage = New System.Windows.Forms.CheckBox()
        Me.cbRandomRotation = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.nudTileHeight = New System.Windows.Forms.NumericUpDown()
        Me.nudTileWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTexturePath = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbTexturePreview = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnAddTexture = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.pnlProperties.SuspendLayout()
        CType(Me.nudTileHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTileWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbTexturePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAddTexture)
        Me.SplitContainer1.Panel2MinSize = 40
        Me.SplitContainer1.Size = New System.Drawing.Size(815, 452)
        Me.SplitContainer1.SplitterDistance = 406
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lvTextures)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.pnlProperties)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Size = New System.Drawing.Size(815, 406)
        Me.SplitContainer2.SplitterDistance = 539
        Me.SplitContainer2.TabIndex = 0
        '
        'lvTextures
        '
        Me.lvTextures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chName, Me.chPath})
        Me.lvTextures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTextures.FullRowSelect = True
        Me.lvTextures.Location = New System.Drawing.Point(0, 0)
        Me.lvTextures.MultiSelect = False
        Me.lvTextures.Name = "lvTextures"
        Me.lvTextures.Size = New System.Drawing.Size(539, 406)
        Me.lvTextures.TabIndex = 2
        Me.lvTextures.UseCompatibleStateImageBehavior = False
        '
        'chID
        '
        Me.chID.Text = "ID"
        Me.chID.Width = 40
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 170
        '
        'chPath
        '
        Me.chPath.Text = "File Path"
        Me.chPath.Width = 300
        '
        'pnlProperties
        '
        Me.pnlProperties.Controls.Add(Me.cbFoliage)
        Me.pnlProperties.Controls.Add(Me.cbRandomRotation)
        Me.pnlProperties.Controls.Add(Me.btnSave)
        Me.pnlProperties.Controls.Add(Me.nudTileHeight)
        Me.pnlProperties.Controls.Add(Me.nudTileWidth)
        Me.pnlProperties.Controls.Add(Me.Label2)
        Me.pnlProperties.Controls.Add(Me.Label1)
        Me.pnlProperties.Controls.Add(Me.lblTexturePath)
        Me.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlProperties.Name = "pnlProperties"
        Me.pnlProperties.Size = New System.Drawing.Size(272, 214)
        Me.pnlProperties.TabIndex = 2
        Me.pnlProperties.Visible = False
        '
        'cbFoliage
        '
        Me.cbFoliage.Location = New System.Drawing.Point(151, 106)
        Me.cbFoliage.Name = "cbFoliage"
        Me.cbFoliage.Size = New System.Drawing.Size(109, 28)
        Me.cbFoliage.TabIndex = 9
        Me.cbFoliage.Text = "Is Foliage"
        Me.cbFoliage.UseVisualStyleBackColor = True
        '
        'cbRandomRotation
        '
        Me.cbRandomRotation.Location = New System.Drawing.Point(9, 106)
        Me.cbRandomRotation.Name = "cbRandomRotation"
        Me.cbRandomRotation.Size = New System.Drawing.Size(109, 32)
        Me.cbRandomRotation.TabIndex = 8
        Me.cbRandomRotation.Text = "Random Texture" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rotation"
        Me.cbRandomRotation.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 178)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(266, 31)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'nudTileHeight
        '
        Me.nudTileHeight.Location = New System.Drawing.Point(70, 80)
        Me.nudTileHeight.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudTileHeight.Name = "nudTileHeight"
        Me.nudTileHeight.Size = New System.Drawing.Size(190, 20)
        Me.nudTileHeight.TabIndex = 6
        '
        'nudTileWidth
        '
        Me.nudTileWidth.Location = New System.Drawing.Point(70, 54)
        Me.nudTileWidth.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudTileWidth.Name = "nudTileWidth"
        Me.nudTileWidth.Size = New System.Drawing.Size(190, 20)
        Me.nudTileWidth.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tile Height:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tile Width:"
        '
        'lblTexturePath
        '
        Me.lblTexturePath.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTexturePath.Location = New System.Drawing.Point(0, 0)
        Me.lblTexturePath.Name = "lblTexturePath"
        Me.lblTexturePath.Size = New System.Drawing.Size(272, 42)
        Me.lblTexturePath.TabIndex = 2
        Me.lblTexturePath.Text = "Path: "
        Me.lblTexturePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbTexturePreview)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 214)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(272, 192)
        Me.Panel1.TabIndex = 1
        '
        'pbTexturePreview
        '
        Me.pbTexturePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbTexturePreview.Location = New System.Drawing.Point(0, 0)
        Me.pbTexturePreview.Name = "pbTexturePreview"
        Me.pbTexturePreview.Size = New System.Drawing.Size(272, 192)
        Me.pbTexturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTexturePreview.TabIndex = 0
        Me.pbTexturePreview.TabStop = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(615, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 30)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Delete Texture"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnAddTexture
        '
        Me.btnAddTexture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTexture.Location = New System.Drawing.Point(712, 8)
        Me.btnAddTexture.Name = "btnAddTexture"
        Me.btnAddTexture.Size = New System.Drawing.Size(91, 30)
        Me.btnAddTexture.TabIndex = 0
        Me.btnAddTexture.Text = "Add Texture"
        Me.btnAddTexture.UseVisualStyleBackColor = True
        '
        'TexturesWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 452)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "TexturesWindow"
        Me.Text = "TexturesWindow"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.pnlProperties.ResumeLayout(False)
        Me.pnlProperties.PerformLayout()
        CType(Me.nudTileHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTileWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbTexturePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As Windows.Forms.SplitContainer
    Friend WithEvents lvTextures As Windows.Forms.ListView
    Friend WithEvents chID As Windows.Forms.ColumnHeader
    Friend WithEvents chName As Windows.Forms.ColumnHeader
    Friend WithEvents chPath As Windows.Forms.ColumnHeader
    Friend WithEvents pbTexturePreview As Windows.Forms.PictureBox
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents btnAddTexture As Windows.Forms.Button
    Friend WithEvents pnlProperties As Windows.Forms.Panel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents btnSave As Windows.Forms.Button
    Friend WithEvents nudTileHeight As Windows.Forms.NumericUpDown
    Friend WithEvents nudTileWidth As Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblTexturePath As Windows.Forms.Label
    Friend WithEvents cbFoliage As Windows.Forms.CheckBox
    Friend WithEvents cbRandomRotation As Windows.Forms.CheckBox
End Class
