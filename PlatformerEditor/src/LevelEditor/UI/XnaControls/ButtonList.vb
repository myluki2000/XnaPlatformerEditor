Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Namespace LevelEditor
    Public Class ButtonList
        Inherits UIElement
        Public WithEvents btnList As New List(Of Button)
        Public btnWidth As Integer = 60
        Public btnHeight As Integer = 20
        Dim WithEvents VerticalScroll As New VerticalScroll With {.Visible = True}
        Dim buttonShift As Integer = 0
        Dim firstDraw As Boolean = True

        Public Sub New()
            Visible = False

        End Sub

        Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
            VerticalScroll.rect = New Rectangle(rect.Right - 20, rect.Y, 20, rect.Height)
            Dim _btnPos As New Vector2(rect.X, rect.Y + 10)
            For Each btn In btnList
                If buttonShift = 0 Then
                    VerticalScroll.Visible = False
                Else
                    VerticalScroll.Visible = True
                End If

                btn.rect = New Rectangle(CInt(_btnPos.X), CInt(_btnPos.Y - VerticalScroll.Value * buttonShift), btnWidth, btnHeight)



                If _btnPos.X + (btnWidth * 2 + 20) - rect.X < rect.Width Then
                    _btnPos.X += btnWidth + 10
                Else
                    _btnPos.X = rect.X
                    _btnPos.Y += btnHeight + 5
                End If

                If btn.rect.Bottom > rect.Bottom Then
                    If btn.BackgroundTexture IsNot Nothing Then
                        btn.srcRect = New Rectangle(0, 0, btn.BackgroundTexture.Width, btn.BackgroundTexture.Height - (btn.rect.Bottom - rect.Bottom))
                    End If

                    btn.rect.Height = btn.rect.Height - (btn.rect.Bottom - rect.Bottom)
                    End If

                If btn.rect.Y < rect.Y Then
                    If btn.BackgroundTexture IsNot Nothing Then
                        btn.srcRect = New Rectangle(0, rect.Y - btn.rect.Y, btn.BackgroundTexture.Width, btn.BackgroundTexture.Height - (rect.Y - btn.rect.Y))
                    End If

                    btn.rect.Height = btn.rect.Height + (btn.rect.Y - rect.Y)
                        btn.rect.Y = btn.rect.Y - (btn.rect.Y - rect.Y)
                    End If
            Next

            If firstDraw Then
                Try
                    buttonShift = CInt(_btnPos.Y + btnHeight) - rect.Bottom
                    firstDraw = False
                Catch
                End Try
            End If

            For Each btn In btnList
                btn.rect.X += CInt(((rect.Width Mod (btnWidth + 10)) + 10) / 2)
            Next

            If Visible Then
                Misc.DrawRectangle(theSpriteBatch, rect, Color.LightGray)

                For Each btn In btnList
                    btn.Draw(theSpriteBatch)
                Next

                VerticalScroll.Draw(theSpriteBatch)
            End If
        End Sub
    End Class
End Namespace