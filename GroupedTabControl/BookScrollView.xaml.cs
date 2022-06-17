using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GroupedTabControl;

public partial class BookScrollView
{
    public BookScrollView()
    {
        InitializeComponent();
    }

    private void RefreshSearch() =>
        (ItemsControl.ItemsSource as ListCollectionView)?.Refresh();

    private void Items_OnFilter(object sender, FilterEventArgs e) =>
        e.Accepted = string.IsNullOrEmpty(SearchTextBox.Text) ||
                     (e.Item as dynamic).Title.Contains(SearchTextBox.Text,
                         StringComparison.InvariantCultureIgnoreCase);

    private void ItemsControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) =>
        RefreshSearch();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) =>
        RefreshSearch();
}