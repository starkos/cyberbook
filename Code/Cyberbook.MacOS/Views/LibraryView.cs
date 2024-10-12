using Cyberbook.Common.Models;

namespace Cyberbook.MacOS.Views;

public class LibraryView : CoreNsCollectionView
{
	private const String BookCellName = "Book";


	public LibraryView(CGRect frame, List<Book> books)
		: base(frame)
	{
		base.CollectionViewLayout = new NSCollectionViewGridLayout
		{
			MaximumNumberOfColumns = 1,
			MaximumItemSize = new CGSize(Int32.MaxValue, 48),
			MinimumItemSize = new CGSize(100, 48)
		};
		base.DataSource = new LibraryViewDataSource(books);
		base.Selectable = true;

		RegisterClassForItem(typeof(LibraryViewItemController), BookCellName);
	}


	private class LibraryViewDataSource(List<Book> books) : NSObject, INSCollectionViewDataSource
	{
		public NSCollectionViewItem GetItem(NSCollectionView collectionView, NSIndexPath indexPath)
		{
			var item = (LibraryViewItemController)collectionView.MakeItem(BookCellName, indexPath);
			item.Book = books[indexPath.Item.ToInt32()];
			return item;
		}


		public IntPtr GetNumberofItems(NSCollectionView collectionView, IntPtr section)
		{
			return books.Count;
		}
	}
}
