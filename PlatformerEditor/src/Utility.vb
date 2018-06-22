Imports System.Drawing

Public Class Utility
    Public Shared Function GetRectCenter(rect As Rectangle) As Point
        Return New Point(CInt(rect.X + rect.Width / 2), CInt(rect.Y + rect.Height / 2))
    End Function
End Class
