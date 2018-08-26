#Region "Using Statements"
Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input
Imports Microsoft.Xna.Framework.Storage
#End Region

Namespace LevelEditor
    Public Class Main
        Inherits Game
        Public Shared graphics As GraphicsDeviceManager
        Private spriteBatch As SpriteBatch

        Public Editor As Screens.Editor.Editor

        Public Shared LevelName As String = ""

        Public Sub New()
            MyBase.New()
            graphics = New GraphicsDeviceManager(Me)
            Content.RootDirectory = "Content"
        End Sub


        Protected Overrides Sub Initialize()
            IsMouseVisible = True


            graphics.PreferredBackBufferWidth = 1280
            graphics.PreferredBackBufferHeight = 720
            graphics.ApplyChanges()

            MyBase.Initialize()
        End Sub

        Protected Overrides Sub LoadContent()
            spriteBatch = New SpriteBatch(GraphicsDevice)
            GlobalContent = Content
            FontKoot = Content.Load(Of SpriteFont)("Fonts/Koot")

            Editor = New Screens.Editor.Editor
        End Sub

        Protected Overrides Sub UnloadContent()

        End Sub

        Protected Overrides Sub Update(gameTime As GameTime)
            If Keyboard.GetState().IsKeyDown(Keys.Escape) Then
                [Exit]()
            End If

            Editor.Update(gameTime)

            MyBase.Update(gameTime)
        End Sub

        Protected Overrides Sub Draw(gameTime As GameTime)
            GraphicsDevice.Clear(Color.CornflowerBlue)

            Editor.Draw(spriteBatch)



            MouseLastState = Mouse.GetState
            MyBase.Draw(gameTime)
        End Sub
    End Class
End Namespace