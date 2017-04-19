Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Polygon
    Public corners As New List(Of Vector2)

    Sub New()

    End Sub

    Sub New(_rect As Rectangle)
        corners.Add(_rect.Location.ToVector2)
        corners.Add(New Vector2(_rect.Right, _rect.Top))
        corners.Add(New Vector2(_rect.Right, _rect.Bottom))
        corners.Add(New Vector2(_rect.Left, _rect.Bottom))
    End Sub

    Public Sub DrawOutline(theSpriteBatch As SpriteBatch, _drawCorners As Boolean)
        For i As Integer = 0 To corners.Count - 1
            If i < corners.Count - 1 Then
                Misc.DrawLine(theSpriteBatch, corners(i), corners(i + 1))
            Else
                Misc.DrawLine(theSpriteBatch, corners(i), corners(0))
            End If
        Next

        If _drawCorners Then
            For Each _corner In corners
                Misc.DrawRectangle(theSpriteBatch, New Rectangle(_corner.ToPoint - New Point(3, 3), New Point(6, 6)), Color.Red)
            Next
        End If
    End Sub

    Public Sub MovePolygon(_shift As Vector2)
        For i As Integer = 0 To corners.Count - 1
            corners(i) += _shift
        Next
    End Sub
End Class
