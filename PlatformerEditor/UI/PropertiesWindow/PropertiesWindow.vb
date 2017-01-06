Imports System.Windows.Forms

Public Class PropertiesWindow

    Dim wObj As WorldObject

    Dim ObjectType As ObjectTypes
    Private Enum ObjectTypes
        Spawner
        PlayerTrigger
    End Enum

    Public Sub ShowProperties(_wObj As WorldObject)
        Dim DoDisplay As Boolean = True
        wObj = _wObj


        Select Case _wObj.Name
            Case "Spawner"
                ObjectType = ObjectTypes.Spawner

            Case "Player" & vbNewLine & "Trigger"
                ObjectType = ObjectTypes.PlayerTrigger

            Case Else
                DoDisplay = False
        End Select

        PopulateWindow()

        If DoDisplay Then
            ShowDialog()
        End If
    End Sub

    Private Sub PopulateWindow()
        Select Case ObjectType
            Case ObjectTypes.Spawner
                Dim _spawnerObj = CType(wObj, Spawner)
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("TBID", "ID", _spawnerObj.ID))
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("TBEnemyType", "Enemy Type", _spawnerObj.EnemyTypeToSpawn.Name))

            Case ObjectTypes.PlayerTrigger
                Dim _triggerObj = CType(wObj, PlayerTrigger)
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("TBTargetID", "Target ID", _triggerObj.TargetID))
        End Select
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim oldObjIndex = PlacedObjects.IndexOf(wObj)
        Select Case ObjectType
            Case ObjectTypes.Spawner
                Dim newObj As Spawner = DirectCast(wObj, Spawner)

                newObj.ID = FlowLayoutProperties.Controls.Find("TBID", False)(0).Text

                Dim newEnemyToSpawn As Enemy = EnemyTypes.Find(Function(x) x.Name = FlowLayoutProperties.Controls.Find("TBEnemyType", False)(0).Text)
                If newEnemyToSpawn IsNot Nothing Then ' If user input enemy doesn't exist this will be Nothing
                    newObj.EnemyTypeToSpawn = newEnemyToSpawn

                    PlacedObjects(oldObjIndex) = newObj
                Else
                    MsgBox("This enemy type does not exist!")
                    Return
                End If

            Case ObjectTypes.PlayerTrigger
                Dim newObj As PlayerTrigger = DirectCast(wObj, PlayerTrigger)

                Throw New NotImplementedException
        End Select

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class