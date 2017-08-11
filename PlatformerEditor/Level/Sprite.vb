Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public MustInherit Class Sprite
    Public Name As String
    Public Texture As Texture2D
    Public TexturePath As String
    Public rect As Rectangle
    Public Scale As Integer = 1
    Public Hitbox As Polygon

    Sub New(_name As String, _texturePath As String)
        Texture = GlobalContent.Load(Of Texture2D)(_texturePath)
        TexturePath = _texturePath
        Name = _name
    End Sub

    Sub New()

    End Sub

    Public MustOverride Sub Update(gameTime As GameTime)

    Public Sub InitHitbox()
        Hitbox = New Polygon(getScreenRect)
    End Sub

    Dim DraggingCorner As Integer = -1
    Public Sub EditHitbox()
        Throw New NotImplementedException("Change to new martix corrected ScreenRect function")

        For Each _corner In Hitbox.corners
            If New Rectangle(_corner.ToPoint - New Point(3, 3), New Point(6, 6)).Contains(Mouse.GetState.Position) AndAlso Mouse.GetState.LeftButton = ButtonState.Pressed AndAlso
                    MouseLastState.LeftButton = ButtonState.Released Then
                ' If mouse cursor is in the displayed corner rectangle and the left button is now pressed
                DraggingCorner = Hitbox.corners.IndexOf(_corner)
            ElseIf Mouse.GetState.LeftButton = ButtonState.Released Then
                DraggingCorner = -1
            End If

            If DraggingCorner <> -1 Then
                Hitbox.corners(DraggingCorner) = Mouse.GetState.Position.ToVector2
                Diagnostics.Debug.WriteLine(Hitbox.corners(DraggingCorner).ToString)
                Exit For
            End If
        Next
    End Sub

    Public Sub DrawHitbox(theSpriteBatch As SpriteBatch)
        Hitbox.DrawOutline(theSpriteBatch, True)
    End Sub

    Public Overridable Sub Draw(theSpriteBatch As SpriteBatch)
        If Texture IsNot Nothing Then
            theSpriteBatch.Draw(Texture, New Rectangle(CInt(rect.X * 30), CInt(rect.Y * 30), CInt(rect.Width * Scale), CInt(rect.Height * Scale)), Color.White)
        Else
            theSpriteBatch.DrawString(FontKoot, Name, getScreenRect.Location.ToVector2, Color.Red)
            Misc.DrawOutline(theSpriteBatch, getScreenRect, Color.Gold, 2)
        End If
    End Sub

    Public Sub getTexture()
        Texture = GlobalContent.Load(Of Texture2D)(TexturePath)
    End Sub

    Public Function getScreenRect() As Rectangle ' Old Screen rect function (to be renamed to getTrueRect)
        Return New Rectangle(rect.X * 30, rect.Y * 30, CInt(rect.Width * Scale), CInt(rect.Height * Scale))

    End Function

    Public Function getScreen1Rect() As Rectangle ' Matrix corrected screen rect function
        Return New Rectangle(CInt(rect.X * 30 + WorldMatrix.Translation.X), CInt(rect.Y * 30 + WorldMatrix.Translation.Y), CInt(rect.Width * Scale), CInt(rect.Height * Scale))

    End Function
End Class
