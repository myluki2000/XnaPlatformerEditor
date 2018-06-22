Imports System.Drawing
Imports System.Windows.Forms

Public Class GraphEditorWindow

    Private IsPlacingLine As boolean = False
    Private CurrentLineStart As Point = Nothing
    Private LineOriginOutput As InputOutput

    Private Sub cmiAddNode_Click(sender As Object, e As EventArgs) Handles cmiAddNode.Click
        Dim n As New Node()

        AddHandler n.InputClicked, AddressOf nodesInputClicked
        AddHandler n.OutputClicked, AddressOf nodesOutputClicked
        pnlNodes.Controls.Add(n)
    End Sub

    Private Sub nodesInputClicked(sender As Node, input As InputOutput)
        If IsPlacingLine Then
            IsPlacingLine = False

            LineOriginOutput.IsConnected = True
            LineOriginOutput.ConnectedToNode = pnlNodes.Controls.IndexOf(sender)
            LineOriginOutput.ConnectedToInput = Array.IndexOf(sender.Inputs, input)

            pnlNodes.Refresh()
        End If
    End Sub

    Private Sub nodesOutputClicked(sender As Node, output As InputOutput)
        If Not IsPlacingLine Then
            IsPlacingLine = True
            LineOriginOutput = output
            CurrentLineStart = Utility.GetRectCenter(sender.GetOutputRect(output))
        Else
            IsPlacingLine = False
            pnlNodes.Refresh()
        End If
    End Sub

    Private Sub pnlNodes_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlNodes.MouseMove
        If IsPlacingLine Then
            pnlNodes.Refresh()
        End If
    End Sub

    Private Sub pnlNodes_Paint(sender As Object, e As PaintEventArgs) Handles pnlNodes.Paint


        With e.Graphics
            For Each n As Node In pnlNodes.Controls
                For Each o As InputOutput In n.Outputs
                    If o.IsConnected Then
                        Dim conNode As Node = DirectCast(pnlNodes.Controls(o.ConnectedToNode), Node)

                        .DrawLine(Pens.Black, Utility.GetRectCenter(n.GetOutputRect(o)), Utility.GetRectCenter(conNode.GetInputRect(conNode.Inputs(o.ConnectedToInput))))
                    End If
                Next
            Next

            If IsPlacingLine Then
                Dim relMousePos = pnlNodes.PointToClient(MousePosition)

                .DrawLine(Pens.Black, CurrentLineStart, relMousePos)
            End If
        End With

    End Sub
End Class