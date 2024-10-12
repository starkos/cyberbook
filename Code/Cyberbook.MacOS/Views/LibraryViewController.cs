using Cyberbook.Common.ViewModels;

namespace Cyberbook.MacOS.Views;

public class LibraryViewController : NSViewController
{
	private readonly LibraryView _libraryView;


	public LibraryViewController(LibraryViewModel viewModel)
	{
		_libraryView = new LibraryView(CGRect.Empty, viewModel.Books)
		{
			Delegate = new LibraryViewDelegate(viewModel)
		};

		base.View = new NSScrollView(CGRect.Empty)
		{
			DocumentView = _libraryView
		};
	}


	public override void ViewDidAppear()
	{
		_libraryView.ReloadData();
	}


	public override void ViewDidDisappear()
	{
	}


	private class LibraryViewDelegate(LibraryViewModel viewModel) : CoreNsCollectionViewDelegate
	{
		public override void ItemDoubleClicked(NSCollectionView collectionView, NSIndexPath indexPath)
		{
			viewModel.BookSelected(indexPath.Item.ToInt32());
		}
	}
}
