Imports System.Windows.Forms

Public Class PropertiesWindow

    Dim ObjectType As ObjectTypes
    Private Enum ObjectTypes
        Spawner
        PlayerTrigger
    End Enum

    Public Sub ShowProperties(_wObj As WorldObject)
        Dim DoDisplay As Boolean = True

        Select Case _wObj.Name
            Case "Spawner"
                ObjectType = ObjectTypes.Spawner

            Case "Player" & vbNewLine & "Trigger"
                ObjectType = ObjectTypes.PlayerTrigger

            Case Else
                DoDisplay = False
        End Select

        PopulateWindow()

        If DoDisplay Then
            ShowDialog()
        End If
    End Sub

    Private Sub PopulateWindow()
        Select Case ObjectType
            Case ObjectTypes.Spawner
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("ID"))
                FlowLayoutProperties.Controls.Add(New PanelPropertiesTB("Enemy Type"))
        End Select
    End Sub
End Class