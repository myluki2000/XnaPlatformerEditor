Public Class ScreenHandler
    Public Shared SelectedScreen As Screen

    Public Shared Sub Draw(theSpriteBatch As Microsoft.Xna.Framework.Graphics.SpriteBatch)
        SelectedScreen.Draw(theSpriteBatch)
    End Sub

    Public Shared Sub Update(gameTime As Microsoft.Xna.Framework.GameTime)
        SelectedScreen.Update(gameTime)
    End Sub
End Class
