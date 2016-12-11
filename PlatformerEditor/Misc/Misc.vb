Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Misc

    Shared dummyTexture As Texture2D = New Texture2D(Main.graphics.GraphicsDevice, 1, 1)

    Shared Sub New()
        dummyTexture.SetData(New Color() {Color.White})
    End Sub

    Public Shared Sub DrawRectangle(theSpriteBatch As SpriteBatch, destRect As Rectangle, color As Color)
        theSpriteBatch.Draw(dummyTexture, destRect, color)
    End Sub

    Public Shared Sub DrawRectangle(theSpriteBatch As SpriteBatch, destRect As Rectangle, color As Color, colorOutline As Color, thicknessOutline As Integer)
        DrawRectangle(theSpriteBatch, destRect, color) ' Main Rect
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X, destRect.Y, destRect.Width, thicknessOutline), colorOutline) ' Outline Top
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X, destRect.Y + destRect.Height - thicknessOutline, destRect.Width, thicknessOutline), colorOutline) ' Outline Bottom
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X, destRect.Y, thicknessOutline, destRect.Height), colorOutline) ' Outline Left
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X + destRect.Width - thicknessOutline, destRect.Y, thicknessOutline, destRect.Height), colorOutline) ' Outline Right
    End Sub

    Public Shared Sub DrawRectangle(theSpriteBatch As SpriteBatch, destRect As Rectangle, sourceRect As Rectangle, origin As Vector2, Rotation As Single, Color As Color)
        theSpriteBatch.Draw(dummyTexture, destRect, sourceRect, Color, Rotation, origin, Nothing, 0)
    End Sub


    Public Shared Function PointInRect(_point As Point, _rect As Rectangle) As Boolean
        If _rect.Left < _point.X AndAlso _point.X < _rect.Right AndAlso
            _rect.Top < _point.Y AndAlso _point.Y < _rect.Bottom Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
