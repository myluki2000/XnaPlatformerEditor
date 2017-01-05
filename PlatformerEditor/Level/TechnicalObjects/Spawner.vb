Public Class Spawner
    Inherits TechnicalObject

    Public ID As String

    Public EnemyTypeToSpawn As Enemy = New DebugEnemy

    Sub New()
        Name = "Spawner"
    End Sub

    Public Sub SpawnEnemy()
        Throw New NotImplementedException
    End Sub
End Class
