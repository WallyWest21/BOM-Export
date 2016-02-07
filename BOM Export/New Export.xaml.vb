
Imports System.Linq
Public Class New_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Dim oCATIA As New CATIA_Lib.Cl_CATIA

    'Dim NewPartslist
    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown
        Dim Parent As String
        If oCATIA.IsCATIAOpen = True Then

            Dim NewPartslist = From part2D In oDrawing.PartsList()
                               Select part2D

            Dim ParentPartNumbers = (From ParentPartNumber In NewPartslist
                                     Select ParentPartNumber.ParentDashNo
                                     Order By ParentDashNo Ascending).Distinct


            For Each ParentPartNo In ParentPartNumbers


                Dim New2DPartsList = From part2D In NewPartslist
                                     Where part2D.ParentDashNo = ParentPartNo
                                     Select part2D


                AddNewExport(sender.Name, New2DPartsList, ParentPartNo)
            Next
        End If



    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown

        If oCATIA.IsCATIAOpen = True Then

            Dim NewPartslist = From part3D In oProduct.PartsList()
                               Select part3D
            Dim ParentPartNo As String

            AddNewExport(sender.Name, NewPartslist, ParentPartNo)
        End If
    End Sub
    Sub AddNewExport(btnName As String, NewPartslist As Object, ParentPartNo As String)

        Dim ExportedItems = New List(Of TabItem)

        Dim NewTab As New TabItem()
        NewTab.Header = ParentPartNo
        NewTab.Name = "NewName"

        'ExportedItems.Insert(0, NewTab)
        NewTab.Content = AddListBox(btnName, NewPartslist)

        'ExportedItems.Add(NewTab)
        'ExpotedTabsCtrl.DataContext = ExportedItems
        ExpotedTabsCtrl.Items.Add(NewTab)
        ExpotedTabsCtrl.SelectedIndex = 0


    End Sub
    Function AddListBox(btnName As String, NewPartslist As Object) As ListBox
        'Dim NewPartslist As New List(Of String)
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
                MyExportedListBox.ItemsSource = NewPartslist

            Case "lb_3D"

                lb_2D.Foreground = New SolidColorBrush(Colors.White)
                lb_3D.Foreground = New SolidColorBrush(Colors.Tan)

                MyExportedListBox.ItemTemplate = CType(FindResource("My3DDataTemplate"), DataTemplate)
                MyExportedListBox.ItemsSource = NewPartslist

        End Select

        Return MyExportedListBox
    End Function

End Class
