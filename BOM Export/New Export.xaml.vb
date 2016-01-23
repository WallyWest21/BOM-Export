Imports BOM_Export
Public Class New_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown
        My2DListBox.ItemsSource = oDrawing.PartsList()
    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown
        My3DListBox.ItemsSource = oProduct.PartsList()
    End Sub
End Class
