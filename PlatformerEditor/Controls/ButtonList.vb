Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class ButtonList
    Inherits UIElement
    Public WithEvents btnList As New List(Of Button)
    Public btnWidth As Integer = 60
    Public btnHeight As Integer = 20

    Public Sub New()
        rect = New Rectangle(0, 0, 100, 50)
        Visible = False
    End Sub

    Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)


        Dim _btnPos As New Vector2(rect.X, rect.Y + 10)
        For Each btn In btnList
            btn.rect = New Rectangle(CInt(_btnPos.X), CInt(_btnPos.Y), btnWidth, btnHeight)
            If _btnPos.X + (btnWidth * 2 + 20) - rect.X < rect.Width Then
                _btnPos.X += btnWidth + 10
            Else
                _btnPos.X = rect.X
                _btnPos.Y += btnHeight + 5
            End If
        Next

        For Each btn In btnList
            btn.rect.X += CInt(((rect.Width Mod (btnWidth + 10)) + 10) / 2)
        Next

        If Visible Then
            Misc.DrawRectangle(theSpriteBatch, rect, Color.LightGray)

            For Each btn In btnList
                btn.Draw(theSpriteBatch)
            Next


        End If
    End Sub
End Class