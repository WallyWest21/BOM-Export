Public Class BOM_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Private Sub Label_MouseDown(sender As Object, e As MouseButtonEventArgs)



    End Sub

    Private Sub Label_MouseDown_1(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown
        'MsgBox(oDrawing.PartsList.Item(1).PartNo)
        My2DListBox.ItemsSource = oDrawing.PartsList()
    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown
        'MsgBox(oProduct.SelectSingle3DProduct.product.partnumber)
        My3DListBox.ItemsSource = oProduct.PartsList()
        'MsgBox(oProduct.PartsList.Item(0).PartNo)
        'MsgBox(oProduct.PartsList.Item(0).Nomenclature)
    End Sub
End Class
