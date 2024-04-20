namespace WebBooks.Library;

public class LibraryViewController : NSViewController, INSCollectionViewDataSource
{
	private const String BookCellName = "BookCell";


	private readonly AppDelegate _appDelegate;


	public LibraryViewController (AppDelegate appDelegate)
	{
		_appDelegate = appDelegate;
	}


	public override void LoadView ()
	{
		var collectionView = new NSCollectionView (CGRect.Empty) {
			CollectionViewLayout = new NSCollectionViewFlowLayout () {
				ItemSize = new CGSize (100, 100),
				SectionInset = new NSEdgeInsets (10, 10, 10, 20),
				MinimumInteritemSpacing = 10,
				MinimumLineSpacing = 10
			},
			DataSource = this,
			Delegate = new LibraryViewDelegate (this),
			Selectable = true,
			WantsLayer = true
		};

		collectionView.RegisterClassForItem (typeof(LibraryItemView), BookCellName);
		collectionView.ReloadData ();

		View = collectionView;
	}


	public NSCollectionViewItem GetItem (NSCollectionView collectionView, NSIndexPath indexPath)
	{
		return collectionView.MakeItem (BookCellName, indexPath);
	}


	public IntPtr GetNumberofItems (NSCollectionView collectionView, IntPtr section)
	{
		return 25;
	}


	public void OnItemSelected ()
	{
		// _navigator.OpenBook (SomeBook)
		_appDelegate.OnBookSelected ();
	}
}
