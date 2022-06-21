using System.Collections.ObjectModel;

namespace GroupedTabControl;

public enum Group
{
    Fiction,
    NonFiction
}

public enum Rating
{
    Three,
    Four,
    Five
}

public class Book
{
    public Rating Rating { get; }
    public Group Group { get; }
    public string Title { get; }
    
    public Book()
    {
        Rating = Rating.Four;        
        Group = Group.Fiction;
        Title = "Designer Data";
    }

    public Book(Rating rating, Group group, string title)
    {
        Rating = rating;
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

        Sources.Add(new Book(Rating.Five, Group.Fiction, "Adventures of Tom Sawyer"));
        Sources.Add(new Book(Rating.Four, Group.Fiction, "Chronicles of Narnia"));
        Sources.Add(new Book(Rating.Five, Group.Fiction, "Lord of the Rings"));
        Sources.Add(new Book(Rating.Three, Group.NonFiction, "Innocents Abroad"));
        Sources.Add(new Book(Rating.Five, Group.NonFiction, "American History")); 
    }
}