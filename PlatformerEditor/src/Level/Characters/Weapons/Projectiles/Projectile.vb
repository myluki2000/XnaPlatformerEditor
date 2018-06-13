Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Projectile
    Inherits Sprite

    Public Velocity As Vector2
    Public Acceleration As New Vector2(0, 0)
    Public Damage As Integer
    Public Existing As Boolean = True
    Public Landed As Boolean = False

    Public Origin As Character.CharacterTypes

    Dim Rotation As Single

    Public Event ProjectileImpact(ByRef sender As Projectile)


    Public Overrides Sub Update(gameTime As GameTime)
    End Sub
End Class
