Public MustInherit Class UIElement
    Public rect As New Microsoft.Xna.Framework.Rectangle(0, 0, 0, 0)
    Public Visible As Boolean
    Public srcRect As Microsoft.Xna.Framework.Rectangle

    Public MustOverride Sub Draw(theSpriteBatch As Microsoft.Xna.Framework.Graphics.SpriteBatch)
End Class
