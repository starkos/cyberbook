using ObjCRuntime;

namespace WebBooks.Library;

public class LibraryItemView : NSCollectionViewItem
{
	public LibraryItemView (NativeHandle handle)
		: base (handle)
	{}


	// slap together a simple solid color view for testing
	public override void LoadView ()
	{
		View = new NSView () {
			WantsLayer = true
		};

		if (View.Layer is not null)
			View.Layer.BackgroundColor = NSColor.Blue.CGColor;

		// React to IsSelected:
		// https://stackoverflow.com/questions/28250147/nscollectionview-selection-handling-in-swift
	}
}
