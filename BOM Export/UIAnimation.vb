Imports System.Windows.Media.Animation


Public Class UIAnimation
    Dim BOM_Export As New BOM_Export
    Public Sub ExtendHeight(InitialHeight As Double, ItemsCount As Integer, animProperty As DependencyProperty)

        'https://zamjad.wordpress.com/2009/11/05/doing-animation-with-code-using-vb-net/> 


        Dim da As New DoubleAnimation
        'da.SetValue(win_BOMExport, HeightProperty) = 275
        da.From = InitialHeight
        da.To = InitialHeight + 45 * ItemsCount
        da.AccelerationRatio = 0.8
        da.Duration = TimeSpan.FromSeconds(1)
        BOM_Export.BeginAnimation(animProperty, da)

    End Sub

End Class
