Imports System.Collections.Generic
Imports Microsoft.Xna.Framework

Module GlobalVariables
    Public MouseLastState As Input.MouseState
    Public FontKoot As Graphics.SpriteFont
    Public GlobalContent As Content.ContentManager

    Public WorldMatrix As New Matrix()

#Region "Declare lists to hold world objects"
    Public WorldObjects As New Collections.Generic.List(Of WorldObject)
    Public TechnicalObjects As New Collections.Generic.List(Of TechnicalObject)
    Public _PlacedObjects As New Collections.Generic.List(Of WorldObject)
    Public EnemyTypes As New Collections.Generic.List(Of Enemy)

    Public Property PlacedObjects As List(Of WorldObject)
        Get
            Return _PlacedObjects
        End Get
        Set(value As List(Of WorldObject))
            _PlacedObjects = value

            For Each _placedObj In PlacedObjects
                For Each _wObj In WorldObjects
                    If _wObj.Name = _placedObj.Name Then
                        _placedObj.Texture = _wObj.Texture
                    End If
                Next
            Next
        End Set
    End Property
#End Region

    Public lastKeyboardState As Input.KeyboardState

    Public Function SubtractColors(color1 As Color, color2 As Color) As Color
        Dim returnColor As New Color
        returnColor.B = color1.B - color2.B
        returnColor.G = color1.G - color2.G
        returnColor.R = color1.R - color2.R
        returnColor.A = color1.A
        Return returnColor
    End Function

    Public Function KeyPress(k As Input.Keys) As Boolean
        If Input.Keyboard.GetState.IsKeyUp(k) AndAlso lastKeyboardState.IsKeyDown(k) Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
