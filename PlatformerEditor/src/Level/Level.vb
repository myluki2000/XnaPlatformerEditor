Imports System.Collections.Generic
Imports Microsoft.Xna.Framework.Graphics
Imports PlatformerEditor.LevelEditor

Public Class Level
    Public Name As String = ""
    Public PlacedObjects As New List(Of WorldObject)
    Public WorldObjects As New List(Of WorldObject)
    Public LightPolygons As New List(Of Polygon)
    Public BackgroundImagePath As String
End Class
