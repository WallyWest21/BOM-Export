Public Class BOM_Export
    Private Sub Label_MouseDown(sender As Object, e As MouseButtonEventArgs)
        Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
        MsgBox(oDrawing.PartsList)
    End Sub
End Class
