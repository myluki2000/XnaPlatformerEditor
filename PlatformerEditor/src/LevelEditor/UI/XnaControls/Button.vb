Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace LevelEditor
    Public Class Button
        Inherits UIElement
        Public Name As String
        Public Event Clicked(sender As Object)
        Public Text As String = "Button"
        Public BackgroundColor As Color = Color.Gray
        Public BackgroundTexture As Texture2D
        Public ClickEffect As ClickEffects = ClickEffects.None
        Public ToggleButton As Boolean = False
        Public Checked As Boolean = False
        Public Enabled As Boolean = True

        Public Enum ClickEffects
            None
            BlueBorder
        End Enum

        Sub New()
            Visible = True
        End Sub

        Public Overrides Sub Draw(theSpriteBatch As SpriteBatch)
            If Visible Then
                ' Click detection
                If rect.Contains(Mouse.GetState.Position) AndAlso Mouse.GetState.LeftButton = ButtonState.Released AndAlso MouseLastState.LeftButton = ButtonState.Pressed Then
                    Select Case ClickEffect
                        Case ClickEffects.BlueBorder
                            Misc.DrawRectangle(theSpriteBatch, New Rectangle(rect.X - 2, rect.Y - 2, rect.Width + 4, rect.Height + 4), Color.Blue)
                    End Select

                    If Checked Then
                        Checked = False
                    Else
                        Checked = True
                    End If

                    If Enabled Then
                        RaiseEvent Clicked(Me)
                    End If
                End If

                If ToggleButton = True AndAlso Checked = True Then
                    Misc.DrawRectangle(theSpriteBatch, New Rectangle(rect.X - 2, rect.Y - 2, rect.Width + 4, rect.Height + 4), Color.Blue)
                End If
                If rect.Contains(Mouse.GetState.Position) Then
                    Misc.DrawRectangle(theSpriteBatch, rect, SubtractColors(BackgroundColor, New Color(30, 30, 30)))

                    If Mouse.GetState.LeftButton = ButtonState.Pressed Then
                        Misc.DrawRectangle(theSpriteBatch, rect, SubtractColors(BackgroundColor, New Color(90, 90, 90)))
                    End If
                Else
                    Misc.DrawRectangle(theSpriteBatch, rect, BackgroundColor)
                End If
                ' Draw Background
                If BackgroundTexture IsNot Nothing Then
                    If srcRect = Nothing Then
                        theSpriteBatch.Draw(BackgroundTexture, rect, Color.White)
                    Else
                        theSpriteBatch.Draw(BackgroundTexture, rect, srcRect, Color.White)
                    End If
                End If
                ' Draw Button label
                theSpriteBatch.DrawString(FontKoot, text, New Vector2(CSng(rect.X + rect.Width / 2 - FontKoot.MeasureString(text).X / 2), CSng(rect.Y + rect.Height / 2 - FontKoot.MeasureString(text).Y / 2)), Color.Black)
            End If
        End Sub
    End Class
End Namespace