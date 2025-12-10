# How to Expand or Collapse WPF PivotGrid?

This session describes how to expand or collapse [WPF PivotGrid](https://www.syncfusion.com/wpf-controls/pivot-grid).

You can expand or collapse all nodes in both rows and columns of the PivotGrid control by using [ExpandAllGroup](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_ExpandAllGroup) or [CollapseAllGroup](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.PivotGrid.PivotGridControl.html#Syncfusion_Windows_Controls_PivotGrid_PivotGridControl_CollapseAllGroup) method.

Refer the below code for your reference.

#### XAML

``` xml
<syncfusion:PivotGridControl Name="pivotGrid" 
                             HorizontalAlignment="Center" 
                             Margin="0,0,0,40" 
                             VerticalAlignment="Center" 
                             skin:SfSkinManager.VisualStyle="Office2016Colorful" />

<Button Content="Expand" Name="Expand" 
                         HorizontalAlignment="Center" 
                         Margin="201,379,0,0" Click="Expand_Click" 
                         VerticalAlignment="Center" Width="75" 
                         skin:SfSkinManager.VisualStyle="Office2016Colorful"/>

<Button Content="Collapse" Name="Collapse" 
                           HorizontalAlignment="Center" 
                           Margin="10,379,110,0" 
                           Click="Collapse_Click" 
                           VerticalAlignment="Center" 
                           Width="75" 
                           skin:SfSkinManager.VisualStyle="Office2016Colorful"/>
```

#### C#

``` csharp
private void Expand_Click(object sender, RoutedEventArgs e)
{
    //Expand all nodes in rows and columns
    pivotGrid.ExpandAllGroup();
}

private void Collapse_Click(object sender, RoutedEventArgs e)
{
    //Collapse all nodes in rows and columns
    pivotGrid.CollapseAllGroup();
}
```

![Expanding and collapsing Pivot using Button click](CollapseAndExpandingPivotGrid.png)