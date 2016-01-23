Public Class UIElementz
    Public Sub AddUserControl(ParentUI As StackPanel, ChildUI As UserControl)
        'ParentUI.Children.Clear()
        'ChildUI = New UserControl
        ParentUI.Children.Add(ChildUI)
    End Sub
End Class
