Imports CATIA_Lib

Class MainWindow
    Dim CATIA As New Cl_CATIA
    Dim oProduct As New Cl_CATIA._3D.oProduct
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        'textBlock.Text = oProduct.SelectSingle3DProduct
        'oProduct.test()
    End Sub
End Class
