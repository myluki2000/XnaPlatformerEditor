Imports System.Drawing
Imports System.Windows.Forms

Public Class Node

    Public Inputs() As InputOutput = {New InputOutput(), New InputOutput(), New InputOutput()}
    Public Outputs() As InputOutput = {New InputOutput(), New InputOutput()}

    Public Event InputClicked(sender As Node, input As InputOutput)
    Public Event OutputClicked(sender As Node, output As InputOutput)

    Public IsDragging As Boolean = False

    Private Sub Node_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        With e.Graphics

            .FillRectangle(Brushes.White, New Rectangle(5, 5, Width - 11, Height - 11))
            .DrawRectangle(Pens.Black, New Rectangle(5, 5, Width - 11, Height - 11))

            Dim spacing As Integer = CInt(Height / (Inputs.Length + 1))
            For i As Integer = 0 To Inputs.Length - 1
                .FillEllipse(Brushes.Red, New Rectangle(0, (i + 1) * spacing - 5, 10, 10))
            Next

            spacing = CInt(Height / (Outputs.Length + 1))
            For i As Integer = 0 To Outputs.Length - 1
                .FillEllipse(Brushes.Blue, New Rectangle(Width - 11, (i + 1) * spacing - 5, 10, 10))
            Next
        End With
    End Sub

    Private Sub Node_Click(sender As Object, e As EventArgs) Handles Me.Click
        Dim spacing As Integer = CInt(Height / (Inputs.Length + 1))
        For i As Integer = 0 To Inputs.Length - 1
            Dim rect = New Rectangle(0, (i + 1) * spacing - 5, 10, 10)

            If rect.Contains(PointToClient(MousePosition)) Then
                RaiseEvent InputClicked(Me, Inputs(i))
            End If
        Next

        spacing = CInt(Height / (Outputs.Length + 1))
        For i As Integer = 0 To Outputs.Length - 1
            Dim rect = New Rectangle(Width - 11, (i + 1) * spacing - 5, 10, 10)

            If rect.Contains(PointToClient(MousePosition)) Then
                RaiseEvent OutputClicked(Me, Outputs(i))
            End If
        Next
    End Sub

    Private Sub Node_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        IsDragging = True
    End Sub

    Dim oldMousePosition As Point
    Private Sub Node_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If IsDragging Then
            Location += New Size(MousePosition.X - oldMousePosition.X, MousePosition.Y - oldMousePosition.Y)
        End If

        oldMousePosition = MousePosition
    End Sub

    Private Sub Node_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        IsDragging = False
        Parent.Refresh()
    End Sub

    Public Function GetInputRect(i As InputOutput) As Rectangle
        Dim spacing As Integer = CInt(Height / (Inputs.Length + 1))
        Return New Rectangle(Location.X, Location.Y + (Array.IndexOf(Inputs, i) + 1) * spacing - 5, 10, 10)
    End Function

    Public Function GetOutputRect(o As InputOutput) As Rectangle
        Dim spacing As Integer = CInt(Height / (Outputs.Length + 1))
        Return New Rectangle(Location.X + Width - 11, Location.Y + (Array.IndexOf(Outputs, o) + 1) * spacing - 5, 10, 10)
    End Function
End Class
