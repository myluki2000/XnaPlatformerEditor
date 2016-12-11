Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Button
    Public Label As String = "Button"
    Public rect As New Rectangle(0, 0, 100, 50)

    Public Sub Update(gameTime As GameTime)

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        If Misc.PointInRect(Mouse.GetState.Position, rect) Then
            Misc.DrawRectangle(theSpriteBatch, rect, Color.Black)
        Else
            Misc.DrawRectangle(theSpriteBatch, rect, Color.White)
        End If
    End Sub
End Class
