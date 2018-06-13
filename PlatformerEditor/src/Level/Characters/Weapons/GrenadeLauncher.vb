Imports Microsoft.Xna.Framework

Public Class GrenadeLauncher
    Inherits Weapon

    Sub New(_cType As Character.CharacterTypes)
        MyBase.New(_cType)

        Projectilespeed = 180
    End Sub
End Class
