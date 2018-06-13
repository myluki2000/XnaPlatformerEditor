Imports Microsoft.Xna.Framework

Class RectangleF
    Public X As Single
    Public Y As Single
    Public Width As Single
    Public Height As Single

    Public Sub New(x__1 As Single, y__2 As Single, width__3 As Single, height__4 As Single)
        X = x__1
        Y = y__2
        Width = width__3
        Height = height__4
    End Sub

    Public ReadOnly Property Top() As Single
        Get
            Return Y
        End Get
    End Property
    Public ReadOnly Property Bottom() As Single
        Get
            Return Y + Height
        End Get
    End Property
    Public ReadOnly Property Left() As Single
        Get
            Return X
        End Get
    End Property
    Public ReadOnly Property Right() As Single
        Get
            Return X + Width
        End Get
    End Property

    Public ReadOnly Property Position() As Vector2
        Get
            Return New Vector2(X, Y)
        End Get
    End Property
End Class