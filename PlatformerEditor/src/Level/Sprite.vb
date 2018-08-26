Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input


Public MustInherit Class Sprite
    Public Name As String
    Public Texture As Texture2D
    Public TexturePath As String
    Public rect As Rectangle
    Public Scale As Integer = 1
    Public ID As UInteger

    Sub New(_name As String, _texturePath As String)
        Try
            Texture = GlobalContent.Load(Of Texture2D)(_texturePath)
        Catch ex As Content.ContentLoadException
            MsgBox("Error while loading texture from path: " & _texturePath & vbNewLine & "Is there a typo or does the file not exist?")
        End Try
        TexturePath = _texturePath
        Name = _name
    End Sub

    Sub New()

    End Sub

    Public MustOverride Sub Update(gameTime As GameTime)

    Public Overridable Sub Draw(theSpriteBatch As SpriteBatch)
        If Texture IsNot Nothing Then
            theSpriteBatch.Draw(Texture, New Rectangle(CInt(rect.X * 30), CInt(rect.Y * 30), CInt(rect.Width * Scale), CInt(rect.Height * Scale)), Color.White)
        Else
            theSpriteBatch.DrawString(FontKoot, Name, getScreenRect.Location.ToVector2, Color.Red)
            LevelEditor.Misc.DrawOutline(theSpriteBatch, getScreenRect, Color.Gold, 2)
        End If
    End Sub

    Public Function getScreenRect() As Rectangle ' Old Screen rect function (to be renamed to getTrueRect)
        Return New Rectangle(rect.X * 30, rect.Y * 30, CInt(rect.Width * Scale), CInt(rect.Height * Scale))

    End Function

    Public Function getScreen1Rect() As Rectangle ' Matrix corrected screen rect function
        Return New Rectangle(CInt(rect.X * 30 + WorldMatrix.Translation.X), CInt(rect.Y * 30 + WorldMatrix.Translation.Y), CInt(rect.Width * Scale), CInt(rect.Height * Scale))

    End Function
End Class
