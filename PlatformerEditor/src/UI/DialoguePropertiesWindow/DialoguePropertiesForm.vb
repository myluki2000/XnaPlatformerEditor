Imports System.Collections.Generic

Public Class DialoguePropertiesForm

    Public Shared Segments As New List(Of DialogueSegment)

    Private Sub btnAddSegment_Click(sender As Object, e As EventArgs) Handles btnAddSegment.Click
        Dim frm As New EditSegmentForm(EditSegmentForm.EditTypes.Create)

        frm.ShowDialog()
        UpdateListView()
    End Sub

    Private Sub UpdateListView()
        lvSegments.Items.Clear()

        For Each seg In Segments
            With lvSegments.Items.Add(seg.FaceSpritePath)
                .SubItems.Add(seg.Text)
                .SubItems.Add(seg.ResetAfterSegment.ToString)
                .SubItems.Add(seg.DeactivateAfterSegment.ToString)
            End With
        Next
    End Sub
End Class