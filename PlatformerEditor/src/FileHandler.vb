Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq

Public Class FileHandler

    Shared WorldPath As String = ""

#Region "Level"

    Public Shared Function LoadLevel(_path As String) As Level
        Dim _placedObjects As New List(Of WorldObject)

        Dim lvlXEle = XElement.Load(_path)

        For Each xele In lvlXEle.Element("WorldObjects").Elements
            Dim _placedObj As New WorldObject
            _placedObj.Name = xele.Attribute("Name").Value
            _placedObj.rect.X = CInt(xele.Element("X").Value)
            _placedObj.rect.Y = CInt(xele.Element("Y").Value)
            _placedObj.rect.Width = CInt(xele.Element("Width").Value)
            _placedObj.rect.Height = CInt(xele.Element("Height").Value)
            _placedObj.Scale = CInt(xele.Element("Scale").Value)
            _placedObj.zIndex = CInt(xele.Element("Z-Index").Value)
            _placedObj.ParallaxMultiplier = CSng(xele.Element("ParallaxMultiplier").Value)
            _placedObj.IsProp = CBool(xele.Element("IsProp").Value)

            _placedObjects.Add(_placedObj)
        Next

        Dim lvl As New Level With {.PlacedObjects = _placedObjects}

        lvl.BackgroundImagePath = lvlXEle.Element("Properties").Element("BackgroundImagePath").Value
        lvl.WorldObjects = LoadLevelTextures(_path)

        Return lvl
    End Function

    Public Shared Function LoadLevelTextures(_path As String) As List(Of WorldObject)
        Dim _worldObjects As New List(Of WorldObject)

        For Each xele In XElement.Load(_path).Element("Textures").Elements
            Dim _wObj As New WorldObject

            _wObj.Name = xele.Element("Name").Value
            _wObj.TexturePath = xele.Element("TexturePath").Value
            _wObj.HasRandomTextureRotation = CBool(xele.Element("RandomTextureRotation").Value)
            _wObj.IsFoliage = CBool(xele.Element("IsFoliage").Value)

            _worldObjects.Add(_wObj)
        Next

        Return _worldObjects
    End Function

    Public Shared Sub SaveLevel(_lvl As Level, Optional _path As String = "")
        ' Saves all technical objects to a xele
        Dim xeleTechObjs As New XElement("TechnicalObjects")
        For Each _wObj In PlacedObjects
            Select Case _wObj.GetType
                Case GetType(Spawner)
                    Dim obj As Spawner = CType(_wObj, Spawner)
                    xeleTechObjs.Add(New XElement("Object", New XAttribute("Name", "Spawner"),
                                                New XElement("X", obj.rect.X),
                                                New XElement("Y", obj.rect.Y),
                                                New XElement("ID", obj.ID)))

                Case GetType(PlayerTrigger)
                    MsgBox("Player Triggers have not been implemented in this version of the editor yet. Block was ignored.")

                Case GetType(PlayerSpawn)
                    Dim obj As PlayerSpawn = CType(_wObj, PlayerSpawn)
                    xeleTechObjs.Add(New XElement("Object", New XAttribute("Name", "PlayerSpawn"),
                                                  New XElement("X", obj.rect.X),
                                                  New XElement("Y", obj.rect.Y)))

                Case GetType(InfoBoxDisplay)
                    Dim obj As InfoBoxDisplay = CType(_wObj, InfoBoxDisplay)
                    xeleTechObjs.Add(New XElement("Object", New XAttribute("Name", "InfoBoxDisplay"),
                                                  New XElement("X", obj.rect.X),
                                                  New XElement("Y", obj.rect.Y),
                                                  New XElement("Text", obj.Text)))

                Case GetType(LoadingZone)
                    Dim obj As LoadingZone = CType(_wObj, LoadingZone)
                    xeleTechObjs.Add(New XElement("Object", New XAttribute("Name", "LoadingZone"),
                                                  New XElement("X", obj.rect.X),
                                                  New XElement("Y", obj.rect.Y),
                                                  New XElement("TargetLevelName", obj.TargetLevelName)))
            End Select
        Next

        ' Assign IDs to WorldObjects
        For i As Integer = 0 To _lvl.WorldObjects.Count - 1
            _lvl.WorldObjects(i).ID = CUInt(i)
        Next



        ' Saves the light polygons
        Dim xeleLightPolygons As New XElement("LightPolygons")
        For Each p In LightPolygons

            Dim xelePolygon As New XElement("Polygon")

            For Each c In p.corners
                xelePolygon.Add(New XElement("Corner",
                                             New XElement("X", c.X),
                                             New XElement("Y", c.Y)))
            Next

            xeleLightPolygons.Add(xelePolygon)
        Next



        ' Save textures and normal world objects to a xele and paste the technical objects xele
        Dim xele As New XElement("Level",
                                 New XElement("Properties",
                                              New XElement("BackgroundImagePath", _lvl.BackgroundImagePath)),
                                 New XElement("Textures",
                                    From wObj In _lvl.WorldObjects
                                    Select New XElement("Texture",
                                        New XElement("ID", wObj.ID),
                                        New XElement("Name", wObj.Name),
                                        New XElement("TexturePath", wObj.TexturePath),
                                        New XElement("RandomTextureRotation", wObj.HasRandomTextureRotation.ToString),
                                        New XElement("IsFoliage", wObj.IsFoliage.ToString))),
                                 New XElement("WorldObjects",
                                    From obj In _lvl.PlacedObjects.FindAll(Function(x) x.GetType = GetType(WorldObject))
                                    Select New XElement("Object", New XAttribute("Name", obj.Name),
                                        New XElement("ID", _lvl.WorldObjects.Find(Function(x) x.Name = obj.Name).ID.ToString),
                                        New XElement("X", obj.rect.X),
                                        New XElement("Y", obj.rect.Y),
                                        New XElement("Width", obj.rect.Width),
                                        New XElement("Height", obj.rect.Height),
                                        New XElement("Scale", obj.Scale),
                                        New XElement("Z-Index", obj.zIndex),
                                        New XElement("ParallaxMultiplier", obj.ParallaxMultiplier.ToString),
                                        New XElement("IsProp", obj.IsProp.ToString))),
                                 xeleTechObjs,
                                 xeleLightPolygons)



        If _path = "" Then
            Dim dlgSave As New Windows.Forms.SaveFileDialog
            dlgSave.Filter = "Platformer level | *.plvl"
            dlgSave.ShowDialog()
            If dlgSave.FileName IsNot "" Then
                xele.Save(dlgSave.FileName)
            End If

        Else
            xele.Save(_path)
        End If

        MsgBox("Save complete")
    End Sub

#End Region

#Region "CharacterPreset"

    Public Shared Sub SaveCharacterPresets()
        Dim xele As New XElement("CharacterPresets",
                    From character In MainWindow.CharacterPresets
                    Select New XElement("Preset", New XAttribute("Name", character.Name),
                                        New XAttribute("Index", MainWindow.CharacterPresets.IndexOf(character)),
                        New XElement("TexturePath", character.TexturePath),
                        New XElement("HP", character.HealthPoints),
                        New XElement("Type", character.CharacterType)))

        xele.Save(Path.Combine(WorldPath, "CharacterPresets.pchar"))
    End Sub

    Public Shared Sub LoadCharacterPresets()
        Dim rootEle As XElement = XElement.Load(Path.Combine(WorldPath, "CharacterPresets.pchar"))

        If Not IsNothing(rootEle) Then

            For Each xele In rootEle.Elements
                MainWindow.CharacterPresets.Insert(CInt(xele.Attribute("Index").Value), New Character() With {
                    .Name = xele.Attribute("Name").Value,
                    .TexturePath = xele.Element("TexturePath").Value,
                    .HealthPoints = CInt(xele.Element("HP").Value),
                    .CharacterType = DirectCast([Enum].Parse(GetType(Character.CharacterTypes), xele.Element("Type").Value), Character.CharacterTypes)})

            Next
        End If

        MainWindow.f.CharactersListChanged()
    End Sub

#End Region

#Region "World"

    Public Shared Sub LoadWorld(_path As String)
        WorldPath = _path

        Dim file As XElement = XElement.Load(Path.Combine(WorldPath, "world.pwrld"))

        For Each xele In file.Element("Levels").Elements
            Dim lvl = LoadLevel(Path.Combine(_path, "Levels", xele.Element("Name").Value & ".plvl"))
            lvl.Name = xele.Element("Name").Value

            MainWindow.Levels.Add(lvl)

        Next

        MainWindow.f.LevelsListChanged()

        LoadCharacterPresets()
        MainWindow.f.CharactersListChanged()
    End Sub

    Public Shared Sub SaveWorld()
        If WorldPath = "" Then
            Dim sfd As New Windows.Forms.SaveFileDialog

            sfd.ShowDialog()

            If sfd.FileName <> "" Then
                WorldPath = sfd.FileName
                My.Computer.FileSystem.CreateDirectory(sfd.FileName)
            Else
                Return
            End If
        End If

        Directory.CreateDirectory(Path.Combine(WorldPath, "Levels"))
        For Each lvl In MainWindow.Levels
            SaveLevel(lvl, Path.Combine(WorldPath, "Levels", lvl.Name + ".plvl"))
        Next


        Dim xele As New XElement("World", New XElement("Levels",
                        From lvl In MainWindow.Levels
                        Select New XElement("Level",
                            New XElement("Name", lvl.Name))))

        xele.Save(Path.Combine(WorldPath, "world.pwrld"))

        SaveCharacterPresets()
    End Sub

#End Region
End Class
