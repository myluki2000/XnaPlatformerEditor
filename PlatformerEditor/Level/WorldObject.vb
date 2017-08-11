Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Graphics

<Serializable>
Public Class WorldObject
    Inherits Sprite

    Public zIndex As Integer = 0

    Sub New(_name As String, _texturePath As String)
        MyBase.New(_name, _texturePath)
    End Sub

    Public Overrides Sub Update(gameTime As GameTime)

    End Sub

    Sub New()

    End Sub

    Public Function ShallowCopy() As WorldObject
        Return DirectCast(Me.MemberwiseClone, WorldObject)
    End Function
End Class
