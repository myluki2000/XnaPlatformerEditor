Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Button
    Public Label As String = "Button"
    Public rect As New Rectangle(0, 0, 100, 50)
    Event Clicked()

    Public Sub Update(gameTime As GameTime)

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        If Misc.PointInRect(Mouse.GetState.Position, rect) Then
            If Mouse.GetState.LeftButton = ButtonState.Pressed Then
                Misc.DrawRectangle(theSpriteBatch, rect, Misc.ConvertToRbg("5C2626"))
            Else
                Misc.DrawRectangle(theSpriteBatch, rect, Misc.ConvertToRbg("B74242"))
                If MouseLastState.LeftButton = ButtonState.Pressed Then
                    RaiseEvent Clicked()
                End If
            End If
        Else
            Misc.DrawRectangle(theSpriteBatch, rect, Misc.ConvertToRbg("EA7362"))
        End If
    End Sub
End Class
