#Region "Using Statements"
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input
#End Region

Namespace LevelEditor
    Public Class Main
        Inherits Game
        Public Shared graphics As GraphicsDeviceManager
        Private spriteBatch As SpriteBatch

        Public Editor As Screens.Editor.Editor

        Public Shared LevelName As String = ""

        Public Shared Instance As Main

        Public Sub New()
            MyBase.New()
            graphics = New GraphicsDeviceManager(Me)
            Content.RootDirectory = "Content"

            Instance = Me

            Dim mainWindow As New MainWindow(Me)
            mainWindow.Show()
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
            FontKoot = Content.Load(Of SpriteFont)("Fonts/Koot")

            Editor = New Screens.Editor.Editor
        End Sub

        Protected Overrides Sub UnloadContent()

        End Sub

        Protected Overrides Sub Update(gameTime As GameTime)
            If Me.IsActive Then
                If Keyboard.GetState().IsKeyDown(Keys.Escape) Then
                    [Exit]()
                End If

                If LevelName <> "" Then
                    Editor.Update(gameTime)
                End If

                MyBase.Update(gameTime)
            End If
        End Sub

        Protected Overrides Sub Draw(gameTime As GameTime)
            If Me.IsActive Then

                If LevelName <> "" Then
                    GraphicsDevice.Clear(Color.CornflowerBlue)
                    Editor.Draw(spriteBatch)
                Else
                    GraphicsDevice.Clear(Color.Black)
                    spriteBatch.Begin(, BlendState.NonPremultiplied,,,,,)
                    spriteBatch.DrawString(FontKoot, "Select a level in the main window to start!", New Vector2(100, 300), Color.White, 0, Nothing, 3, Nothing, Nothing)
                    spriteBatch.End()
                End If



                MouseLastState = Mouse.GetState
                MyBase.Draw(gameTime)
            End If
        End Sub
    End Class
End Namespace