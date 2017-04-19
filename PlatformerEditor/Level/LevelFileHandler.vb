Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq

Public Class LevelFileHandler
    Public Shared Function LoadLevel() As List(Of WorldObject)
        Dim _placedObjects As New List(Of WorldObject)
        Dim dlgLoad As New Windows.Forms.OpenFileDialog
        dlgLoad.Filter = "Platformer level | *.plvl"
        dlgLoad.Multiselect = False
        dlgLoad.ShowDialog()

        If dlgLoad.FileName IsNot "" Then
            For Each xele In XElement.Load(dlgLoad.FileName).Element("WorldObjects").Elements
                Dim _placedObj As New WorldObject
                _placedObj.Name = xele.Attribute("Name").Value
                _placedObj.rect.X = CInt(xele.Element("X").Value)
                _placedObj.rect.Y = CInt(xele.Element("Y").Value)
                _placedObj.rect.Width = CInt(xele.Element("Width").Value)
                _placedObj.rect.Height = CInt(xele.Element("Height").Value)
                _placedObj.Scale = CInt(xele.Element("Scale").Value)
                _placedObj.zIndex = CInt(xele.Element("Z-Index").Value)

                _placedObjects.Add(_placedObj)
            Next

            MsgBox("Load complete")
            Return _placedObjects
        Else
            Return Nothing
        End If
    End Function

    Public Shared Sub SaveLevel(_placedObjects As List(Of WorldObject))
        Dim spriteObjs As New List(Of WorldObject)
        Dim spawnerObjs As New List(Of Spawner)
        Dim triggerObjs As New List(Of PlayerTrigger)

        For Each _wObj In _placedObjects
            Select Case _wObj.GetType
                Case GetType(WorldObject)
                    spriteObjs.Add(_wObj)

                Case GetType(Spawner)
                    spawnerObjs.Add(CType(_wObj, Spawner))

                Case GetType(PlayerTrigger)
                    triggerObjs.Add(CType(_wObj, PlayerTrigger))
            End Select
        Next


        Dim xele As New XElement("Level", New XElement("WorldObjects",
                                From obj In spriteObjs
                                Select New XElement("Object", New XAttribute("Name", obj.Name),
                                    New XElement("X", obj.rect.X),
                                    New XElement("Y", obj.rect.Y),
                                    New XElement("Width", obj.rect.Width),
                                    New XElement("Height", obj.rect.Height),
                                    New XElement("Scale", obj.Scale),
                                    New XElement("Z-Index", obj.zIndex))),
                    New XElement("Spawners",
                                 From obj In spawnerObjs
                                 Select New XElement("Spawner",
                                            New XElement("X", obj.rect.X),
                                            New XElement("Y", obj.rect.Y),
                                            New XElement("ID", obj.ID),
                                            New XElement("EnemyTypeToSpawn", obj.EnemyTypeToSpawn.ToString))),
                    New XElement("PlayerTriggers",
                                 From obj In triggerObjs
                                 Select New XElement("PlayerTrigger",
                                            New XElement("X", obj.rect.X),
                                            New XElement("Y", obj.rect.Y),
                                            New XElement("ActivationType", obj.ActivationType.ToString),
                                            New XElement("ActivationDelay", obj.ActivationDelay),
                                            New XElement("TargetID", obj.TargetID))))



        Dim dlgSave As New Windows.Forms.SaveFileDialog
        dlgSave.Filter = "Platformer level | *.plvl"
        dlgSave.ShowDialog()
        If dlgSave.FileName IsNot "" Then
            xele.Save(dlgSave.FileName)
            MsgBox("Save complete")
        End If
    End Sub
End Class
