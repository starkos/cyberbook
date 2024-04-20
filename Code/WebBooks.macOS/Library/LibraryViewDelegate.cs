namespace WebBooks.Library;

public class LibraryViewDelegate : NSCollectionViewDelegateFlowLayout
{
	private readonly LibraryViewController _viewController;


	public LibraryViewDelegate (LibraryViewController viewController)
	{
		_viewController = viewController;
	}


	public override void ItemsSelected (NSCollectionView collectionView, NSSet indexPaths)
	{
		_viewController.OnItemSelected ();
	}
}
