Imports Microsoft.Xna.Framework

Public Class Utility
    Public Shared Function GetRectCenter(rect As Drawing.Rectangle) As Drawing.Point
        Return New Drawing.Point(CInt(rect.X + rect.Width / 2), CInt(rect.Y + rect.Height / 2))
    End Function

    Public Shared Function ScreenPosToWorldPos(screenPos As Point) As Vector2
        Dim camera = LevelEditor.Main.Instance.Editor.Camera
        Dim viewport = LevelEditor.Main.graphics.GraphicsDevice.Viewport

        Return New Vector2(CSng((screenPos.X - viewport.Width / 2) / camera.Scale.X - camera.Translation.X),
                           CSng((screenPos.Y - viewport.Height / 2) / camera.Scale.Y - 150 - camera.Translation.Y))
    End Function
End Class
