#Region "Using Statements"
Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input
Imports Microsoft.Xna.Framework.Storage
#End Region

Public Class Main
    Inherits Game
    Public Shared graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch

    Public Sub New()
        MyBase.New()
        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub


    Protected Overrides Sub Initialize()
        IsMouseVisible = True

        GlobalContent = Content

        ScreenHandler.SelectedScreen = New Screens.MainMenu.MainMenu

        MyBase.Initialize()
    End Sub

    Protected Overrides Sub LoadContent()
        spriteBatch = New SpriteBatch(GraphicsDevice)

        FontKoot = Content.Load(Of SpriteFont)("Fonts/Koot")

    End Sub

    Protected Overrides Sub UnloadContent()

    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        If Keyboard.GetState().IsKeyDown(Keys.Escape) Then
            [Exit]()
        End If

        ScreenHandler.update(gameTime)





        MyBase.Update(gameTime)
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.CornflowerBlue)

        ScreenHandler.Draw(spriteBatch)



        MouseLastState = Mouse.GetState
        MyBase.Draw(gameTime)
    End Sub
End Class
