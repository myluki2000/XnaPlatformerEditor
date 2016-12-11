Imports Microsoft.Xna.Framework.Graphics

Namespace MainMenu
    Public Class MainMenu
        Inherits Screen
        Shared btnTest As New Button

        Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
            theSpriteBatch.Begin()
            btnTest.Draw(theSpriteBatch)
            theSpriteBatch.End()
        End Sub
    End Class
End Namespace