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
        If Misc.PointInRect(Mouse.GetState.Position, rect) Then ' If mouse on button
            If Mouse.GetState.LeftButton = ButtonState.Pressed Then ' If mouse pressed
                Misc.DrawRectangle(theSpriteBatch, rect, Misc.ConvertToRbg("5C2626")) ' pressed effect
            Else
                Misc.DrawRectangle(theSpriteBatch, rect, Misc.ConvertToRbg("B74242")) ' if not, hover effect
                If MouseLastState.LeftButton = ButtonState.Pressed Then ' if mouse was pressed last frame,
                    RaiseEvent Clicked() ' raise clicked event
                End If
            End If
        Else
            Misc.DrawRectangle(theSpriteBatch, rect, Misc.ConvertToRbg("EA7362")) ' default color
        End If

        ' text draw
        Dim TextPos As Vector2
        TextPos.X = CSng(rect.X + rect.Width / 2 - FontKoot.MeasureString(Label).X / 2)
        TextPos.Y = CSng(rect.Y + rect.Height / 2 - FontKoot.MeasureString(Label).Y / 2)
        theSpriteBatch.DrawString(FontKoot, Label, TextPos, Color.Black)
    End Sub
End Class
