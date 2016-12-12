Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Sprite
    Public Name As String
    Public Texture As Texture2D
    Public TexturePath As String
    Public rect As Rectangle

    Sub New(_name As String, _texturePath As String)
        Texture = GlobalContent.Load(Of Texture2D)(_texturePath)
        TexturePath = _texturePath
        Name = _name
    End Sub

    Sub New()

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        theSpriteBatch.Draw(Texture, New Vector2(CInt(rect.X * 30), CInt(rect.Y * 30)), Color.White)
    End Sub

    Public Sub getTexture()
        Texture = GlobalContent.Load(Of Texture2D)(TexturePath)
    End Sub

    Public Function getScreenRect() As Rectangle
        Return New Rectangle(rect.X * 30, rect.Y * 30, rect.Width, rect.Height)

    End Function
End Class
