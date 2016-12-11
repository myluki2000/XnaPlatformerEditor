Imports Microsoft.Xna.Framework.Content

<Serializable>
Public Class WorldObject
    Inherits Sprite

    Public Sub New(_name As String, _texturePath As String)
        MyBase.New(_name, _texturePath)
    End Sub
End Class
