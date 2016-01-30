
Public Class New_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Dim oCATIA As New CATIA_Lib.Cl_CATIA
    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown

        If oCATIA.IsCATIAOpen = True Then
            lb_3D.Foreground = New SolidColorBrush(Colors.White)
            lb_2D.Foreground = New SolidColorBrush(Colors.Tan)

            My2DListBox.ItemsSource = oDrawing.PartsList()
            'My2DListBox.BorderThickness = New Thickness(1)
            'My2DListBox.ItemTemplate = My.Resources.datatemplate("My2DExportTemplate")
            'this.Resources["My2DExportTemplate"] As DataTemplate
            My2DListBox.ItemTemplate = CType(FindResource("My2DDataTemplate"), DataTemplate)
        End If
    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown
        lb_2D.Foreground = New SolidColorBrush(Colors.White)
        lb_3D.Foreground = New SolidColorBrush(Colors.Tan)
        'My3DListBox.ItemsSource = oProduct.PartsList()
        'My3DListBox.BorderThickness = New Thickness(1)

        'My2DListBox.BorderThickness = New Thickness(1)
        My2DListBox.ItemsSource = oProduct.PartsList()
        My2DListBox.ItemTemplate = CType(FindResource("My3DDataTemplate"), DataTemplate)

    End Sub

    Private Sub tab_SecondTab_Loaded(sender As Object, e As RoutedEventArgs) Handles tab_SecondTab.Loaded
        tab_SecondTab.Header = "B471356"
    End Sub

    Sub AddNewExport()

    End Sub

End Class
