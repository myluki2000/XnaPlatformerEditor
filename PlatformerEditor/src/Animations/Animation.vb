Imports Microsoft.Xna.Framework

Public Class Animation
    Public Name As String
    Public FrameDuration As Integer
    Public IterationCount As Integer = -1 ' -1 = Repeat, other numbers = times it is played
    Public FrameCount As Integer
    Public FrameRect As Rectangle
End Class
