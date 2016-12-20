Imports Microsoft.Xna.Framework.Content

<Serializable>
Public Class WorldObject
    Inherits Sprite

    Public zIndex As Integer = 0

    Sub New(_name As String, _texturePath As String)
        MyBase.New(_name, _texturePath)
    End Sub

    Sub New()

    End Sub
End Class
