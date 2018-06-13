Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Input

Public Class ClickHandler
    Shared ClickTimer As Integer

    Public Shared Function CheckForDoubleClick(gameTime As GameTime) As Boolean
        ClickTimer += CInt(gameTime.ElapsedGameTime.TotalMilliseconds)

        If Mouse.GetState.LeftButton = ButtonState.Released AndAlso MouseLastState.LeftButton = ButtonState.Pressed Then
            If ClickTimer < 300 Then
                ' Click is double click
                Return True
            Else
                ClickTimer = 0
            End If
        End If

        Return False
    End Function
End Class
