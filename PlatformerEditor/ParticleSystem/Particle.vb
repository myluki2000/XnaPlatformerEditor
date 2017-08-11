Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Particle
    Inherits Sprite

    Public Position As Vector2
    Public Velocity As Vector2
    Public LifetimeCounter As Integer
    Public Lifetime As Integer
    Public Alive As Boolean = True
    Public Opacity As Single = 1
    Public FadeTime As Integer

    Sub New(_tex As Texture2D, _pos As Vector2, _vel As Vector2, _ltime As Integer, _fTime As Integer)
        Texture = _tex
        Position = _pos
        Velocity = _vel
        Lifetime = _ltime
        FadeTime = _fTime
    End Sub

    Public Overrides Sub Update(gameTime As GameTime)
        LifetimeCounter += CInt(gameTime.ElapsedGameTime.TotalMilliseconds)
        Position += Velocity * CSng(gameTime.ElapsedGameTime.TotalSeconds)

        If LifetimeCounter > Lifetime Then
            Alive = False
        End If

        If LifetimeCounter > Lifetime - FadeTime AndAlso FadeTime <> 0 Then
            Opacity += -CSng(1 / FadeTime * gameTime.ElapsedGameTime.TotalMilliseconds)
        End If
    End Sub

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
        theSpriteBatch.Draw(Texture, New Rectangle(Position.ToPoint, New Point(Texture.Width * Scale, Texture.Height * Scale)), Color.White * Opacity)
    End Sub
End Class
