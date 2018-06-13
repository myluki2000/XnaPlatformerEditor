Imports Microsoft.Xna.Framework

Public Class AnimationWindow
    Public Overloads Function ShowDialog() As Animation
        MyBase.ShowDialog()

        Dim newAnim As New Animation
        newAnim.Name = tbName.Text
        newAnim.FrameDuration = CInt(nudFrameDuration.Value)
        newAnim.IterationCount = CInt(nudIterationCount.Value)
        newAnim.FrameRect = New Rectangle(CInt(nudRectX.Value), CInt(nudRectY.Value), CInt(nudRectWidth.Value), CInt(nudRectHeight.Value))
        newAnim.FrameCount = CInt(nudFrameCount.Value)

        Return newAnim
    End Function
End Class