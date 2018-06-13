Imports System.Collections.Generic
Imports Microsoft.Xna.Framework

Namespace LevelEditor
    Public Class ParticleSystem
        Private Particles As New List(Of Particle)
        Public TexturePaths() As String
        Public Position As Vector2
        Public ParticleVelocityLowest As Point
        Public ParticleVelocityHighest As Point
        Public ParticleLifetime As Integer = 5000
        Private Rand As New Random
        Public SpawnsPerSecond As Single = 0
        Public ParticleFadeTime As Integer = 500
    End Class
End Namespace