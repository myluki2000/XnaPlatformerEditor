Public Class PlayerSpawn
    Inherits TechnicalObject

    Sub New()
        Name = "PlayerSpawn"
    End Sub

    Public Overrides Function ValuesAreSafe() As Boolean
        If zIndex <> 0 Then
            MsgBox("A player spawn can only be placed at z-index 0")
            Return False
        End If

        Return True
    End Function
End Class
