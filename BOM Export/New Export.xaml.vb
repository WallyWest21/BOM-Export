
Public Class New_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Dim oCATIA As New CATIA_Lib.Cl_CATIA

    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown

        If oCATIA.IsCATIAOpen = True Then
            lb_3D.Foreground = New SolidColorBrush(Colors.White)
            lb_2D.Foreground = New SolidColorBrush(Colors.Tan)


            'My2DListBox.BorderThickness = New Thickness(1)
            'My2DListBox.ItemTemplate = My.Resources.datatemplate("My2DExportTemplate")
            'this.Resources["My2DExportTemplate"] As DataTemplate

            'My2DListBox.ItemsSource = oDrawing.PartsList()
            'My2DListBox.ItemTemplate = CType(FindResource("My2DDataTemplate"), DataTemplate)
        End If
    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown
        lb_2D.Foreground = New SolidColorBrush(Colors.White)
        lb_3D.Foreground = New SolidColorBrush(Colors.Tan)
        'My3DListBox.ItemsSource = oProduct.PartsList()
        'My3DListBox.BorderThickness = New Thickness(1)

        'My2DListBox.BorderThickness = New Thickness(1)


        'My2DListBox.ItemsSource = oProduct.PartsList()
        'My2DListBox.ItemTemplate = CType(FindResource("My3DDataTemplate"), DataTemplate)



    End Sub
    Sub AddNewExport()

        Dim ExportedItems = New List(Of TabItem)

        Dim NewTab As New TabItem()
        NewTab.Header = "B471356"
        NewTab.Name = "NewName"

        Dim MyExportedListBox As New ListBox

        MyExportedListBox.HorizontalAlignment = HorizontalAlignment.Stretch
        MyExportedListBox.SelectionMode = SelectionMode.Multiple
        MyExportedListBox.Background = New SolidColorBrush(Colors.Black)
        MyExportedListBox.BorderThickness = New Thickness(0)


        MyExportedListBox.ItemTemplate = CType(FindResource("My2DDataTemplate"), DataTemplate)
        MyExportedListBox.ItemsSource = oDrawing.PartsList()


        'ExportedItems.Insert(0, NewTab)
        NewTab.Content = MyExportedListBox

        'ExportedItems.Add(NewTab)
        'ExpotedTabsCtrl.DataContext = ExportedItems
        ExpotedTabsCtrl.Items.Add(NewTab)
        ExpotedTabsCtrl.SelectedIndex = 0


    End Sub

    Private Sub lb_excel_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_excel.MouseDown
        AddNewExport()
    End Sub
End Class
