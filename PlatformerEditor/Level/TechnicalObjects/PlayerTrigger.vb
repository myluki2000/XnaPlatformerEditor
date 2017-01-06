Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework

Public Class PlayerTrigger
    Inherits TechnicalObject

    Public ActivationType As ActivationTypes
    Public ActivationDelay As Integer = 0
    Public TargetID As String = ""

    Public Enum ActivationTypes
        Once
        OnEnter
        Repeat
    End Enum

    Sub New()
        Name = "Player" & vbNewLine & "Trigger"
    End Sub
End Class
