
Public Class New_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Dim oCATIA As New CATIA_Lib.Cl_CATIA

    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown

        If oCATIA.IsCATIAOpen = True Then
            AddNewExport(sender.Name)
        End If


    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown

        If oCATIA.IsCATIAOpen = True Then
            AddNewExport(sender.Name)
        End If
    End Sub
    Sub AddNewExport(btnName As String)

        Dim ExportedItems = New List(Of TabItem)

        Dim NewTab As New TabItem()
        NewTab.Header = "B471356"
        NewTab.Name = "NewName"

        Dim MyExportedListBox As New ListBox

        MyExportedListBox.HorizontalAlignment = HorizontalAlignment.Stretch
        MyExportedListBox.SelectionMode = SelectionMode.Multiple
        MyExportedListBox.Background = New SolidColorBrush(Colors.Black)
        MyExportedListBox.BorderThickness = New Thickness(0)
        'MyExportedListBox.Height = Double.NaN

        Select Case btnName
            Case "lb_2D"

                lb_3D.Foreground = New SolidColorBrush(Colors.White)
                lb_2D.Foreground = New SolidColorBrush(Colors.Tan)

                MyExportedListBox.ItemTemplate = CType(FindResource("My2DDataTemplate"), DataTemplate)
                MyExportedListBox.ItemsSource = oDrawing.PartsList()

            Case "lb_3D"

                lb_2D.Foreground = New SolidColorBrush(Colors.White)
                lb_3D.Foreground = New SolidColorBrush(Colors.Tan)

                MyExportedListBox.ItemTemplate = CType(FindResource("My3DDataTemplate"), DataTemplate)
                MyExportedListBox.ItemsSource = oProduct.PartsList()
        End Select

        'ExportedItems.Insert(0, NewTab)
        NewTab.Content = MyExportedListBox

        'ExportedItems.Add(NewTab)
        'ExpotedTabsCtrl.DataContext = ExportedItems
        ExpotedTabsCtrl.Items.Add(NewTab)
        ExpotedTabsCtrl.SelectedIndex = 0


    End Sub

    Private Sub lb_excel_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_excel.MouseDown
        'AddNewExport()
    End Sub
End Class
