Imports Microsoft.Xna.Framework.Graphics

Public Class UIPanel
    Inherits UIElement

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
        Misc.DrawRectangle(theSpriteBatch, rect, Microsoft.Xna.Framework.Color.LightGray)
    End Sub

    Sub New(_rect As Microsoft.Xna.Framework.Rectangle)
        rect = _rect
    End Sub
End Class
