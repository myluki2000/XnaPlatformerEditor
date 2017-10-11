Imports System.Windows.Forms

Public Class PropertiesWindow

    Dim wObj As WorldObject

    Dim ObjectType As ObjectTypes
    Private Enum ObjectTypes
        Spawner
        PlayerTrigger
        ParticleSpawner
        InfoBoxDisplay
    End Enum

    Public Sub ShowProperties(_wObj As WorldObject)
        Dim DoDisplay As Boolean = True
        wObj = _wObj


        Select Case _wObj.Name
            Case "Spawner"
                ObjectType = ObjectTypes.Spawner

            Case "Player" & vbNewLine & "Trigger"
                ObjectType = ObjectTypes.PlayerTrigger

            Case "Particle" & vbNewLine & "Spawner"
                ObjectType = ObjectTypes.ParticleSpawner

            Case "InfoBoxDisplay"
                ObjectType = ObjectTypes.InfoBoxDisplay

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
                AddControl(New PanelPropertiesTB("TBID", "ID", _spawnerObj.ID))

                Dim enemyTypeNames(EnemyTypes.Count - 1) As String
                For i As Integer = 0 To EnemyTypes.Count - 1
                    enemyTypeNames(i) = EnemyTypes(i).Name
                Next
                AddControl(New PanelPropertiesCombo("ComboEnemyType", "Enemy Type", enemyTypeNames))
                CType(FlowLayoutProperties.Controls.Find("ComboEnemyType", False)(0), PanelPropertiesCombo).SetSelectedItem(_spawnerObj.EnemyTypeToSpawn.Name)

            Case ObjectTypes.PlayerTrigger
                Dim _triggerObj = CType(wObj, PlayerTrigger)
                AddControl(New PanelPropertiesTB("TBTargetID", "Target ID", _triggerObj.TargetID))

            Case ObjectTypes.ParticleSpawner
                Dim _spawnerObj = CType(wObj, ParticleSpawner)
                AddControl(New PanelPropertiesTB("TBPosX", "Inner Position X", _spawnerObj.InnerPosition.X.ToString))
                AddControl(New PanelPropertiesTB("TBPosY", "Inner Position Y", _spawnerObj.InnerPosition.Y.ToString))
                AddControl(New PanelPropertiesTB("TBPVelLowestX", "Particle Velocity Lowest X", _spawnerObj.ps.ParticleVelocityLowest.X.ToString))
                AddControl(New PanelPropertiesTB("TBPVelLowestY", "Particle Velocity Lowest Y", _spawnerObj.ps.ParticleVelocityLowest.Y.ToString))
                AddControl(New PanelPropertiesTB("TBPVelHighestX", "Particle Velocity Highest X", _spawnerObj.ps.ParticleVelocityHighest.X.ToString))
                AddControl(New PanelPropertiesTB("TBPVelHighestY", "Particle Velocity Highest Y", _spawnerObj.ps.ParticleVelocityHighest.Y.ToString))
                AddControl(New PanelPropertiesTB("TBPLifetime", "Particle Life Time", _spawnerObj.ps.ParticleLifetime.ToString))
                AddControl(New PanelPropertiesTB("TBPFadetime", "Particle Fade Time", _spawnerObj.ps.ParticleFadeTime.ToString))

            Case ObjectTypes.InfoBoxDisplay
                Dim _displayObj = CType(wObj, InfoBoxDisplay)
                AddControl(New PanelPropertiesTB("TBText", "Info Box Text", _displayObj.Text))
        End Select
    End Sub

    Private Sub AddControl(cntrl As Control)
        FlowLayoutProperties.Controls.Add(cntrl)
    End Sub

    Private Function FindControl(key As String) As Control
        Return FlowLayoutProperties.Controls.Find(key, False)(0)
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim oldObjIndex = PlacedObjects.IndexOf(wObj)
        Select Case ObjectType
            Case ObjectTypes.Spawner
                Dim newObj As Spawner = DirectCast(wObj, Spawner)

                newObj.ID = FlowLayoutProperties.Controls.Find("TBID", False)(0).Text

                Dim ComboEnemyType As PanelPropertiesCombo = CType(FlowLayoutProperties.Controls.Find("ComboEnemyType", False)(0), PanelPropertiesCombo)
                Dim newEnemyToSpawn As Enemy = EnemyTypes.Find(Function(x) x.Name = ComboEnemyType.SelectedItem)
                If newEnemyToSpawn IsNot Nothing Then ' If user input enemy doesn't exist this will be Nothing
                    newObj.EnemyTypeToSpawn = newEnemyToSpawn

                    PlacedObjects(oldObjIndex) = newObj
                Else
                    MsgBox("Please select an enemy")
                    Return
                End If

            Case ObjectTypes.PlayerTrigger
                Dim newObj As PlayerTrigger = DirectCast(wObj, PlayerTrigger)

                newObj.TargetID = FlowLayoutProperties.Controls.Find("TBTargetID", False)(0).Text

            Case ObjectTypes.ParticleSpawner
                Dim newObj As ParticleSpawner = DirectCast(wObj, ParticleSpawner)

                newObj.InnerPosition.X = CSng(FindControl("TBPosX").Text)
                newObj.InnerPosition.Y = CSng(FindControl("TBPosY").Text)
                newObj.ps.ParticleVelocityHighest.X = CInt(FindControl("TBPVelHighestX").Text)
                newObj.ps.ParticleVelocityHighest.Y = CInt(FindControl("TBPVelHighestY").Text)
                newObj.ps.ParticleVelocityLowest.X = CInt(FindControl("TBPVelLowestX").Text)
                newObj.ps.ParticleVelocityLowest.Y = CInt(FindControl("TBPVelLowestY").Text)
                newObj.ps.ParticleLifetime = CInt(FindControl("TBPLifetime").Text)

                If newObj.InnerPosition.X > 30 Then
                    newObj.InnerPosition.Y = 30
                End If

                If newObj.InnerPosition.Y > 30 Then
                    newObj.InnerPosition.Y = 30
                End If

            Case ObjectTypes.InfoBoxDisplay
                Dim newObj As InfoBoxDisplay = DirectCast(wObj, InfoBoxDisplay)
                newObj.Text = FindControl("TBText").Text
        End Select

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class