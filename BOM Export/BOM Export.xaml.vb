Imports System.Windows.Media.Animation
Imports BOM_Export

Public Class BOM_Export
    Dim oDrawing As New CATIA_Lib.Cl_CATIA.Drawing
    Dim oProduct As New CATIA_Lib.Cl_CATIA._3D.oProduct
    Dim WindowHeight As Double
    Dim WindowWidth As Double


    Private Sub lb_2D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_2D.MouseDown
        'MsgBox(oDrawing.PartsList.Item(1).PartNo)
        Dim UIAnimation As New UIAnimation

        My2DListBox.ItemsSource = oDrawing.PartsList()

        'https://zamjad.wordpress.com/2009/11/05/doing-animation-with-code-using-vb-net/> 



        Dim da As New DoubleAnimation
        'da.SetValue(win_BOMExport, HeightProperty) = 275
        da.From = WindowHeight
        da.To = WindowHeight + 45 * My2DListBox.Items.Count
        da.AccelerationRatio = 0.8
        da.Duration = TimeSpan.FromSeconds(1)
        win_BOMExport.BeginAnimation(HeightProperty, da)


        win_BOMExport.Width = win_BOMExport.Width + 275

        'Dim da1 As New DoubleAnimation
        ''da.SetValue(win_BOMExport, HeightProperty) = 275
        'da1.From = WindowWidth
        'da1.To = WindowWidth + 45
        'da1.AccelerationRatio = 0.8
        'da1.Duration = TimeSpan.FromSeconds(1)
        'win_BOMExport.BeginAnimation(WidthProperty, da1)

        ''http://stackoverflow.com/questions/11503894/how-to-animate-height-And-width-simultaneously-in-wpf-from-code-behind
        'Dim aniHeight As New DoubleAnimation
        'Dim aniWidth As New DoubleAnimation
        ''story board to handle 2 animations
        'Dim sb As New Storyboard()
        'aniWidth.From = win_BOMExport.Width
        'aniHeight.From = win_BOMExport.Height
        'aniHeight.To = 400
        'aniWidth.To = 500
        'aniHeight.Duration = TimeSpan.FromSeconds(1)
        'aniWidth.Duration = TimeSpan.FromSeconds(1)

        'sb.Children.Add(aniHeight)
        'sb.Children.Add(aniWidth)
        'Storyboard.SetTarget(aniHeight, win_BOMExport)
        'Storyboard.SetTarget(aniWidth, win_BOMExport)
        'Storyboard.SetTargetProperty(aniWidth, New PropertyPath("(Width)"))
        'Storyboard.SetTargetProperty(aniHeight, New PropertyPath("(Height)"))
        'sb.Begin()



        'Dim Duration As New Duration(TimeSpan.FromSeconds(1))

        ''// Create two DoubleAnimations And set their properties.
        'Dim myDoubleAnimation1 As New DoubleAnimation


        'myDoubleAnimation1.Duration = Duration


        'Dim sb As New Storyboard()
        'sb.Duration = Duration

        'sb.Children.Add(myDoubleAnimation1)

        'Storyboard.SetTarget(myDoubleAnimation1, win_BOMExport)

        ''// Set the attached properties of Canvas.Left And Canvas.Top
        ''// to be the target properties of the two respective DoubleAnimations
        'Storyboard.SetTargetProperty(myDoubleAnimation1, New PropertyPath(HeightProperty))

        'myDoubleAnimation1.To = 400


        ''// Make the Storyboard a resource.
        ''LayoutRoot.Resources.Add(sb);

        ''// Begin the animation.
        'sb.Begin()


        'My2DListBox.ItemsSource = oDrawing.PartsList()


    End Sub

    Private Sub lb_3D_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_3D.MouseDown
        'MsgBox(oProduct.SelectSingle3DProduct.product.partnumber)
        My3DListBox.ItemsSource = oProduct.PartsList()
        'MsgBox(oProduct.PartsList.Item(0).PartNo)
        'MsgBox(oProduct.PartsList.Item(0).Nomenclature)
    End Sub

    Private Sub win_BOMExport_Loaded(sender As Object, e As RoutedEventArgs) Handles win_BOMExport.Loaded
        WindowHeight = win_BOMExport.Height
        WindowWidth = win_BOMExport.Width
    End Sub

    Private Sub lb_excel_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles lb_excel.MouseDown
        Dim da1 As New DoubleAnimation
        'da.SetValue(win_BOMExport, HeightProperty) = 275
        da1.From = WindowWidth
        da1.To = WindowWidth + 45
        da1.AccelerationRatio = 0.8
        da1.Duration = TimeSpan.FromSeconds(1)
        win_BOMExport.BeginAnimation(WidthProperty, da1)
    End Sub


End Class
