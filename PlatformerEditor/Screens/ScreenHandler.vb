Imports Microsoft.Xna.Framework.Graphics

Public Class ScreenHandler
    Public Shared SelectedScreen As Screen

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch)
        SelectedScreen.Draw(theSpriteBatch)
    End Sub
End Class
