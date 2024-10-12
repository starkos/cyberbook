using Cyberbook.Common.Models;

namespace Cyberbook.Common.ViewModels;

public class LibraryViewModel
{
	public List<Book> Books { get; } =
	[
		new Book
		{
			Title = "A Strange Penance"
		},
		new Book
		{
			Title = "Dead Winter"
		},
		new Book
		{
			Title = "Doonesbury"
		},
		new Book
		{
			Title = "Dr. Dobbs Journal"
		},
		new Book
		{
			Title = "Essential C#"
		}
	];


	public void BookSelected(Int32 indexOfBook)
	{
		var book = Books[indexOfBook];
		Console.WriteLine($"Book selected: {book.Title}");
	}
}
