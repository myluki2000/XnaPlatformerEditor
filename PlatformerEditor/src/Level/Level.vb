Imports System.Collections.Generic
Imports PlatformerEditor.LevelEditor

Public Class Level
    Public Name As String = ""
    Public PlacedObjects As New List(Of WorldObject)
    Public WorldObjects As New List(Of WorldObject)
    Public LightPolygons As New List(Of Polygon)
End Class
