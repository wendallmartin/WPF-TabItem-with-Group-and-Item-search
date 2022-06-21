﻿using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GroupedTabControl;

public partial class GroupTabControl
{
    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(GroupTabControl),
            new PropertyMetadata(null));

    public static readonly DependencyProperty ScrollPanelTemplateProperty = DependencyProperty.Register(
        "ScrollPanelTemplate", typeof(DataTemplate), typeof(GroupTabControl), new PropertyMetadata(null));

    public DataTemplate ScrollPanelTemplate
    {
        get => (DataTemplate)GetValue(ScrollPanelTemplateProperty);
        set => SetValue(ScrollPanelTemplateProperty, value);
    }

    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
        "SelectedItems", typeof(IEnumerable), typeof(GroupTabControl), new PropertyMetadata(null));

    public IEnumerable SelectedItems
    {
        get => (IEnumerable)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }

    public GroupTabControl()
    {
        InitializeComponent();
    }

    private void Group_OnFilter(object sender, FilterEventArgs e) =>
        e.Accepted = string.IsNullOrWhiteSpace(SearchTextBox.Text) ||
                     (e.Item as dynamic).Title.Contains(SearchTextBox.Text,
                         StringComparison.InvariantCultureIgnoreCase);

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var collectionViewSource = (CollectionViewSource)FindResource("GroupSource");
        collectionViewSource.View.Refresh();
        var groups = collectionViewSource.View.Groups.Cast<CollectionViewGroup>().ToList();
        TabControl.SelectedItem = groups.Any() ? groups.GroupBy(cvg => cvg.ItemCount).First().First() : null;
    }
    
    private void Group_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var collectionViewGroup = (CollectionViewGroup)button.DataContext;
        SelectedItems = collectionViewGroup.Items.Cast<CollectionViewGroup>().SelectMany(x => x.Items);
    }

    private void SubGroup_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var collectionViewGroup = (CollectionViewGroup)button.DataContext;
        SelectedItems = collectionViewGroup.Items;
    }
}