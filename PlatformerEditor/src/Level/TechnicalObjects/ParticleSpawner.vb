Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class ParticleSpawner
    Inherits TechnicalObject
    Public ps As New LevelEditor.ParticleSystem
    Public InnerPosition As Vector2

    Sub New()
        Name = "ParticleSpawner"
        TexturePath = "Textures/ParticleCrosshair"
    End Sub

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
        theSpriteBatch.Draw(Texture, New Rectangle(CInt(rect.X * 30 + InnerPosition.X - 5), CInt(rect.Y * 30 + InnerPosition.Y - 5), 10, 10), Color.White)
    End Sub
End Class
