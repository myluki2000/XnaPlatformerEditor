Public Class PropertiesWindow
    Public Sub ShowProperties(_wObj As WorldObject)
        Dim DoDisplay As Boolean = True

        Select Case _wObj.Name
            Case "Spawner"


            Case "Player" & vbNewLine & "Trigger"
                MsgBox("Object is PlayerTrigger")

            Case Else
                DoDisplay = False
        End Select


        If DoDisplay Then
            ShowDialog()
        End If
    End Sub
End Class