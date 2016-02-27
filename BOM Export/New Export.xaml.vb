
Imports System.Linq
Public Class New_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Dim oCATIA As New CATIA_Lib.Cl_CATIA
    Dim MyExportedListBox As New ListBox
    'Dim NewPartslist
    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown

        If oDrawing.IsADrawingDocumentOpen = True Then

            Dim NewPartslist = From part2D In oDrawing.PartsList()
                               Select part2D

            Dim ParentPartNumbers = (From ParentPartNumber In NewPartslist
                                     Select ParentPartNumber.ParentPartNo
                                     Order By ParentPartNo Ascending).Distinct


            For Each ParentPartNo In ParentPartNumbers
                Dim New2DPartsList = From part2D In NewPartslist
                                     Where part2D.ParentPartNo = ParentPartNo
                                     Select part2D

                AddNewExport(sender.Name, New2DPartsList, ParentPartNo)
            Next
        End If



    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown

        If oProduct.IsAProductDocumentOpen = True Then

            Dim NewPartslist = From part3D In oProduct.PartsList()
                               Select part3D
            Dim ParentPartNo As String
            ParentPartNo = "B475001-501"

            AddNewExport(sender.Name, NewPartslist, ParentPartNo)
        End If
    End Sub
    Sub AddNewExport(btnName As String, NewPartslist As Object, ParentPartNo As String)

        Dim ExportedItems = New List(Of TabItem)
        Dim name As String
        name = ParentPartNo

        name = Replace(name, "-", "_")
        name = "tb_" + name

        Dim NewTab As New TabItem()
        NewTab.Header = ParentPartNo
        NewTab.Name = name

        'ExportedItems.Insert(0, NewTab)
        NewTab.Content = AddListBox(btnName, NewPartslist)

        'ExportedItems.Add(NewTab)
        'ExpotedTabsCtrl.DataContext = ExportedItems
        ExpotedTabsCtrl.Items.Add(NewTab)
        ExpotedTabsCtrl.SelectedIndex = 0


    End Sub
    Function AddListBox(btnName As String, NewPartslist As Object) As ListBox

        'Dim name As String
        'name = NewPartslist(0).ParentPartNo.ToString

        'name = Replace(name, "-", "_")
        'name = "lb_" + name

        MyExportedListBox.HorizontalAlignment = HorizontalAlignment.Stretch
        MyExportedListBox.SelectionMode = SelectionMode.Multiple
        MyExportedListBox.Background = New SolidColorBrush(Colors.Black)
        MyExportedListBox.BorderThickness = New Thickness(0)
        'MyExportedListBox.Height = Double.NaN
        MyExportedListBox.MaxHeight = 600
        MyExportedListBox.Name = name


        MyExportedListBox.ItemsSource = NewPartslist

        lb_3D.Foreground = New SolidColorBrush(Colors.White)
        lb_2D.Foreground = New SolidColorBrush(Colors.Tan)

        Select Case btnName

            Case "lb_2D"

                MyExportedListBox.ItemTemplate = CType(FindResource("My2DDataTemplate"), DataTemplate)

            Case "lb_3D"

                MyExportedListBox.ItemTemplate = CType(FindResource("My3DDataTemplate"), DataTemplate)

        End Select

        Return MyExportedListBox
    End Function

    Private Sub ComboBoxItem_MouseDown(sender As Object, e As MouseButtonEventArgs)
        Dim otherlist = MyExportedListBox.Items.Cast(Of String).ToList
        MsgBox("hi")
    End Sub

    Private Sub ComboBoxItem_Selected(sender As Object, e As RoutedEventArgs)

        Dim otherlist = (From part In MyExportedListBox.Items
                         Select part).ToList
        MsgBox("hi")
        oDrawing.ExportToDrawing(otherlist)
    End Sub
End Class
