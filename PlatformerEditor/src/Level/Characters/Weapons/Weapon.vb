Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Weapon

    Public Projectiles As New List(Of Projectile)
    Public BulletCooldown As Integer = 200
    Public BulletDamage As Integer = 5
    Public Projectilespeed As Integer = 200
    Public Position As Vector2
    Public ProjectilesInMag As Integer
    Public ProjectilesMagMax As Integer = 20
    Public ReloadTime As Integer = 2000

    Public CharacterType As Character.CharacterTypes

    Public CurrentlyReloading As Boolean = False

    Public Event ReloadStarted()
    Public Event ShotFired()

    Sub New(_cType As Character.CharacterTypes)
        ProjectilesInMag = ProjectilesMagMax

        CharacterType = _cType
    End Sub
End Class
