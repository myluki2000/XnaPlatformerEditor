<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CharacterPresetWindow
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
        Me.pbTexture = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudHP = New System.Windows.Forms.NumericUpDown()
        Me.lvAnimations = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAddAnim = New System.Windows.Forms.Button()
        Me.btnDelAnim = New System.Windows.Forms.Button()
        Me.btnTextureSelect = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbCharType = New System.Windows.Forms.ComboBox()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFrameDuration = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chIterationCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFrameRect = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFrameCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.pbTexture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbTexture
        '
        Me.pbTexture.Location = New System.Drawing.Point(12, 12)
        Me.pbTexture.Name = "pbTexture"
        Me.pbTexture.Size = New System.Drawing.Size(224, 304)
        Me.pbTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTexture.TabIndex = 2
        Me.pbTexture.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(242, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(330, 9)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(260, 20)
        Me.tbName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(242, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Health Points:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudHP
        '
        Me.nudHP.Location = New System.Drawing.Point(330, 34)
        Me.nudHP.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.nudHP.Name = "nudHP"
        Me.nudHP.Size = New System.Drawing.Size(260, 20)
        Me.nudHP.TabIndex = 6
        '
        'lvAnimations
        '
        Me.lvAnimations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chFrameDuration, Me.chIterationCount, Me.chFrameCount, Me.chFrameRect})
        Me.lvAnimations.Location = New System.Drawing.Point(245, 104)
        Me.lvAnimations.Name = "lvAnimations"
        Me.lvAnimations.Size = New System.Drawing.Size(345, 183)
        Me.lvAnimations.TabIndex = 7
        Me.lvAnimations.UseCompatibleStateImageBehavior = False
        Me.lvAnimations.View = System.Windows.Forms.View.Details
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Animations:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAddAnim
        '
        Me.btnAddAnim.Location = New System.Drawing.Point(245, 293)
        Me.btnAddAnim.Name = "btnAddAnim"
        Me.btnAddAnim.Size = New System.Drawing.Size(103, 23)
        Me.btnAddAnim.TabIndex = 9
        Me.btnAddAnim.Text = "Add Animation"
        Me.btnAddAnim.UseVisualStyleBackColor = True
        '
        'btnDelAnim
        '
        Me.btnDelAnim.Location = New System.Drawing.Point(354, 293)
        Me.btnDelAnim.Name = "btnDelAnim"
        Me.btnDelAnim.Size = New System.Drawing.Size(103, 23)
        Me.btnDelAnim.TabIndex = 10
        Me.btnDelAnim.Text = "Delete Animation"
        Me.btnDelAnim.UseVisualStyleBackColor = True
        '
        'btnTextureSelect
        '
        Me.btnTextureSelect.Location = New System.Drawing.Point(161, 282)
        Me.btnTextureSelect.Name = "btnTextureSelect"
        Me.btnTextureSelect.Size = New System.Drawing.Size(75, 34)
        Me.btnTextureSelect.TabIndex = 11
        Me.btnTextureSelect.Text = "Select Texture"
        Me.btnTextureSelect.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(242, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "CharacterType:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbCharType
        '
        Me.cbCharType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCharType.FormattingEnabled = True
        Me.cbCharType.Items.AddRange(New Object() {"Friendly", "Enemy"})
        Me.cbCharType.Location = New System.Drawing.Point(330, 60)
        Me.cbCharType.Name = "cbCharType"
        Me.cbCharType.Size = New System.Drawing.Size(260, 21)
        Me.cbCharType.TabIndex = 13
        '
        'chName
        '
        Me.chName.Text = "Name"
        '
        'chFrameDuration
        '
        Me.chFrameDuration.Text = "Frame Duration"
        '
        'chIterationCount
        '
        Me.chIterationCount.Text = "Iteration Count"
        '
        'chFrameRect
        '
        Me.chFrameRect.DisplayIndex = 3
        Me.chFrameRect.Text = "Frame Rectangle"
        '
        'chFrameCount
        '
        Me.chFrameCount.Text = "Frame Count"
        '
        'CharacterPresetWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 325)
        Me.Controls.Add(Me.cbCharType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnTextureSelect)
        Me.Controls.Add(Me.btnDelAnim)
        Me.Controls.Add(Me.btnAddAnim)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvAnimations)
        Me.Controls.Add(Me.nudHP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbTexture)
        Me.Name = "CharacterPresetWindow"
        Me.Text = "CharacterPresetWindow"
        CType(Me.pbTexture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbTexture As Windows.Forms.PictureBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents tbName As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents nudHP As Windows.Forms.NumericUpDown
    Friend WithEvents lvAnimations As Windows.Forms.ListView
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btnAddAnim As Windows.Forms.Button
    Friend WithEvents btnDelAnim As Windows.Forms.Button
    Friend WithEvents btnTextureSelect As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbCharType As Windows.Forms.ComboBox
    Friend WithEvents chName As Windows.Forms.ColumnHeader
    Friend WithEvents chFrameDuration As Windows.Forms.ColumnHeader
    Friend WithEvents chIterationCount As Windows.Forms.ColumnHeader
    Friend WithEvents chFrameRect As Windows.Forms.ColumnHeader
    Friend WithEvents chFrameCount As Windows.Forms.ColumnHeader
End Class
