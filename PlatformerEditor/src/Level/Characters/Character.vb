Public Class Character
    Public Name As String = ""
    Public TexturePath As String
    Public ViewDirection As ViewDirections = ViewDirections.Right

    Public CharacterType As CharacterTypes

    Public HealthPoints As Integer = 100

    Public Weapon As Weapon

    Public Enum CharacterTypes
        Friendly
        Enemy
    End Enum

    Public Enum ViewDirections
        Left
        Right
    End Enum

    Public Overridable Sub Interaction()

    End Sub
End Class
