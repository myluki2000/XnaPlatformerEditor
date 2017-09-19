Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class TechnicalObject
    Inherits WorldObject
    Public Activated As Boolean = True

    Public Overridable Function ValuesAreSafe() As Boolean
        Return True
    End Function
End Class
