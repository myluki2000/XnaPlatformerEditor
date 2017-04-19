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

    Public Shared Sub DrawOutline(theSpriteBatch As SpriteBatch, destRect As Rectangle, colorOutline As Color, thicknessOutline As Integer)
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X, destRect.Y, destRect.Width, thicknessOutline), colorOutline) ' Outline Top
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X, destRect.Y + destRect.Height - thicknessOutline, destRect.Width, thicknessOutline), colorOutline) ' Outline Bottom
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X, destRect.Y, thicknessOutline, destRect.Height), colorOutline) ' Outline Left
        DrawRectangle(theSpriteBatch, New Rectangle(destRect.X + destRect.Width - thicknessOutline, destRect.Y, thicknessOutline, destRect.Height), colorOutline) ' Outline Right
    End Sub

    Public Shared Sub DrawLine(theSpriteBatch As SpriteBatch, _start As Vector2, _end As Vector2)
        Dim edge As Vector2 = _end - _start
        ' calculate angle to rotate line
        Dim angle As Single = CSng(Math.Atan2(edge.Y, edge.X))


        ' rectangle defines shape of line and position of start of line
        'sb will strech the texture to fill this rectangle
        'width of line, change this to make thicker line
        'colour of line
        'angle of line (calulated above)
        ' point in line about which to rotate
        theSpriteBatch.Draw(dummyTexture, New Rectangle(CInt(_start.X), CInt(_start.Y), CInt(edge.Length()), 1), Nothing, Color.Red, angle, New Vector2(0, 0),
        SpriteEffects.None, 0)

    End Sub

    Public Shared Function ConvertToRbg(ByVal HexColor As String) As Color
        Dim Red As Integer
        Dim Green As Integer
        Dim Blue As Integer
        HexColor = Replace(HexColor, "#", "")
        Red = CInt("&H" & Mid(HexColor, 1, 2))
        Green = CInt("&H" & Mid(HexColor, 3, 2))
        Blue = CInt("&H" & Mid(HexColor, 5, 2))
        Return New Color(Red, Green, Blue, 255)
    End Function

    Public Shared Function ToPositiveOnly(n As Integer) As Integer
        If n > 0 Then
            Return n
        Else
            Return 0
        End If
    End Function

    Public Shared Function TextureTo2DArray(texture As Texture2D) As Color(,)
        Dim colors1D As Color() = New Color(texture.Width * texture.Height - 1) {}
        texture.GetData(colors1D)


        Dim colors2D As Color(,) = New Color(texture.Width - 1, texture.Height - 1) {}
        For x As Integer = 0 To texture.Width - 1
            For y As Integer = 0 To texture.Height - 1
                colors2D(x, y) = colors1D(x + y * texture.Width)
            Next
        Next

        Return colors2D
    End Function
End Class
