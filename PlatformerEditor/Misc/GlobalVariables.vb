Imports Microsoft.Xna.Framework

Module GlobalVariables
    Public MouseLastState As Microsoft.Xna.Framework.Input.MouseState
    Public FontKoot As Microsoft.Xna.Framework.Graphics.SpriteFont
    Public GlobalContent As Microsoft.Xna.Framework.Content.ContentManager

    Public lastKeyboardState As KeyboardState

    Public Function SubtractColors(color1 As Color, color2 As Color) As Color
        Dim returnColor As New Color
        returnColor.B = color1.B - color2.B
        returnColor.G = color1.G - color2.G
        returnColor.R = color1.R - color2.R
        returnColor.A = color1.A
        Return returnColor
    End Function

    Public Function KeyPress(k As Keys) As Boolean
        If Keyboard.GetState.IsKeyUp(k) AndAlso lastKeyboardState.IsKeyDown(k) Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
