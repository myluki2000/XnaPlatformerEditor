Public Class AR
    Inherits Weapon

    Sub New(_cType As Character.CharacterTypes)
        MyBase.New(_cType)

        BulletCooldown = 85
        BulletDamage = 10
        Projectilespeed = 400


    End Sub
End Class
