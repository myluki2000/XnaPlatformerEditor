Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Namespace Screens
    Namespace MainMenu
        Public Class MainMenu
            Inherits Screen
            Dim WithEvents btnNew As New Button With {.text = "New Level", .rect = New Rectangle(100, 100, 100, 50)}

            Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
                theSpriteBatch.Begin()
                btnNew.Draw(theSpriteBatch)
                theSpriteBatch.End()
            End Sub

            Private Sub btnNew_Click() Handles btnNew.Clicked
                ScreenHandler.SelectedScreen = New Screens.Editor.Editor
            End Sub
        End Class
    End Namespace
End Namespace