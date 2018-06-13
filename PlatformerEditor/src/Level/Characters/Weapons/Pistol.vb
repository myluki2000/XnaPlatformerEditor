Imports Microsoft.Xna.Framework

Public Class Pistol
    Inherits Weapon

    Sub New(_cType As Character.CharacterTypes)
        MyBase.New(_cType)

        BulletCooldown = 500
        BulletDamage = 5
    End Sub
End Class
