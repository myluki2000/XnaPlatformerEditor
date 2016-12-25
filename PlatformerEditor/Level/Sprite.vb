Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Sprite
    Public Name As String
    Public Texture As Texture2D
    Public TexturePath As String
    Public rect As Rectangle
    Public Scale As Integer = 1

    Sub New(_name As String, _texturePath As String)
        Texture = GlobalContent.Load(Of Texture2D)(_texturePath)
        TexturePath = _texturePath
        Name = _name
    End Sub

    Sub New()

    End Sub

    Public Overridable Sub Draw(theSpriteBatch As SpriteBatch)
        theSpriteBatch.Draw(Texture, New Rectangle(CInt(rect.X * 30), CInt(rect.Y * 30), CInt(rect.Width * Scale), CInt(rect.Height * Scale)), Color.White)
    End Sub

    Public Sub getTexture()
        Texture = GlobalContent.Load(Of Texture2D)(TexturePath)
    End Sub

    Public Function getScreenRect() As Rectangle
        Return New Rectangle(rect.X * 30, rect.Y * 30, CInt(rect.Width * Scale), CInt(rect.Height * Scale))

    End Function
End Class
