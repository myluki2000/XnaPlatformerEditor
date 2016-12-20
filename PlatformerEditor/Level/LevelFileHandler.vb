Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq

Public Class LevelFileHandler
    Public Shared Function LoadLevel() As List(Of WorldObject)
        Dim _placedObjects As New List(Of WorldObject)
        For Each xele In XElement.Load("E:\level.xml").Element("WorldObjects").Elements
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

        Return _placedObjects
    End Function

    Public Shared Sub SaveLevel(_placedObjects As List(Of WorldObject))
        Dim xele As New XElement("Level", New XElement("WorldObjects",
                    From obj In _placedObjects
                    Select New XElement("Object", New XAttribute("Name", obj.Name),
                            New XElement("X", obj.rect.X),
                            New XElement("Y", obj.rect.Y),
                            New XElement("Width", obj.rect.Width),
                            New XElement("Height", obj.rect.Height),
                            New XElement("Scale", obj.Scale),
                            New XElement("Z-Index", obj.zIndex))))
        xele.Save("E:\level.xml")
    End Sub
End Class
