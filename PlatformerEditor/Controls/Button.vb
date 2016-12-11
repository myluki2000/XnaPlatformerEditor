Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Button
    Public Label As String = "Button"
    Public rect As New Rectangle(0, 0, 100, 50)

    Public Sub Update(gameTime As GameTime)

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        DrawRectangle.Draw(theSpriteBatch, rect, Color.White)
    End Sub
End Class
