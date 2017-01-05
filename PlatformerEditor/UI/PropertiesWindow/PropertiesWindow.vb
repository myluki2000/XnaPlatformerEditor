Imports System.Windows.Forms

Public Class PropertiesWindow

    Dim ObjectType As ObjectTypes
    Private Enum ObjectTypes
        Spawner
        PlayerTrigger
    End Enum

    Public Sub ShowProperties(_wObj As WorldObject)
        Dim DoDisplay As Boolean = True

        Select Case _wObj.Name
            Case "Spawner"
                ObjectType = ObjectTypes.Spawner

            Case "Player" & vbNewLine & "Trigger"
                ObjectType = ObjectTypes.PlayerTrigger

            Case Else
                DoDisplay = False
        End Select

        PopulateWindow(_wObj)

        If DoDisplay Then
            ShowDialog()
        End If
    End Sub

    Private Sub PopulateWindow(_wObj As WorldObject)
        Select Case ObjectType
            Case ObjectTypes.Spawner
                Dim _spawnerObj = CType(_wObj, Spawner)
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("ID", _spawnerObj.ID))
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("Enemy Type", _spawnerObj.EnemyTypeToSpawn.Name))
        End Select
    End Sub
End Class