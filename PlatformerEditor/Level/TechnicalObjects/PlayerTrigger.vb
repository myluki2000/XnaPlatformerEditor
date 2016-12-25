Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework

Public Class PlayerTrigger
    Inherits TechnicalObject

    Public ActivationType As ActivationTypes

    Public Enum ActivationTypes
        Once
        OnEnter
        Repeat
    End Enum

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
        Misc.DrawOutline(theSpriteBatch, rect, Color.Pink, 1)
    End Sub
End Class
