using System.Collections.ObjectModel;

namespace GroupedTabControl;

public enum Group
{
    Fiction,
    NonFiction
}

public class Book
{
    public Group Group { get; }
    public string Title { get; }
    
    public Book()
    {
        Group = Group.Fiction;
        Title = "Designer Data";
    }

    public Book(Group group, string title)
    {
        Group = group;
        Title = title;
    }

}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public ObservableCollection<Book> Sources { get; } = new(); 

    public MainWindow()
    {
        InitializeComponent();

        Sources.Add(new Book(Group.Fiction, "Adventures of Tom Sawyer"));
        Sources.Add(new Book(Group.Fiction, "Chronicles of Narnia"));
        Sources.Add(new Book(Group.Fiction, "Lord of the Rings"));
        Sources.Add(new Book(Group.NonFiction, "Innocents Abroad"));
        Sources.Add(new Book(Group.NonFiction, "American History")); 
    }
}