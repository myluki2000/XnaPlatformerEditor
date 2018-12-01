Imports Microsoft.Xna.Framework

Public Class Camera
    Public Translation As New Vector3(0, 0, 0)
    Public Scale As New Vector3(1, 1, 1)

    Public Function GetMatrix() As Matrix
        Return Matrix.CreateTranslation(Translation) *
                Matrix.CreateTranslation(New Vector3(0, 150, 0)) *
                Matrix.CreateScale(Scale) *
                Matrix.CreateTranslation(New Vector3(CSng(LevelEditor.Main.graphics.GraphicsDevice.Viewport.Width / 2), CSng(LevelEditor.Main.graphics.GraphicsDevice.Viewport.Height / 2), 0))
    End Function

    Public Function GetMatrix(parallax As Vector3) As Matrix
        Return Matrix.CreateTranslation(Translation * New Vector3(1 / parallax.X, 1, 1)) *
                Matrix.CreateTranslation(New Vector3(0, 150, 0)) *
                Matrix.CreateScale(Scale) *
                Matrix.CreateTranslation(New Vector3(CSng(LevelEditor.Main.graphics.GraphicsDevice.Viewport.Width / 2), CSng(LevelEditor.Main.graphics.GraphicsDevice.Viewport.Height / 2), 0))

    End Function

    'Public Sub FocusOnObject(obj As Sprite)
    '    'ScreenHandler.SelectedScreen.ToWorld.SelectedLevel.Camera.Translation = New Vector3(-CInt(_obj.GetTrueRect.X - graphics.PreferredBackBufferWidth / 2), -CInt(_obj.GetTrueRect.Y - graphics.PreferredBackBufferHeight / 2) + 200, 0)
    '    Translation = New Vector3(-obj.Position, 0)
    'End Sub

    'Public Sub FocusOnPosition(pos As Vector2)
    '    Translation = New Vector3(-pos, 0)
    'End Sub
End Class
