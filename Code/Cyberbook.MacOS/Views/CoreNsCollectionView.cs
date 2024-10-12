namespace Cyberbook.MacOS.Views;

public class CoreNsCollectionView(CGRect frame) : NSCollectionView(frame)
{
	public override void MouseDown(NSEvent theEvent)
	{
		base.MouseDown(theEvent);

		// Detect pointer double clicks
		if (theEvent.ClickCount == 2)
		{
			var pointInWindow = theEvent.LocationInWindow;
			var pointInView = ConvertPointFromView(pointInWindow, NSApplication.SharedApplication.MainWindow?.ContentView);

			if (IsFlipped)
				pointInView.Y = this.Frame.Height - pointInView.Y;

			var clickedItem = GetIndexPath(pointInView);
			if (clickedItem != null)
				((CoreNsCollectionViewDelegate?)Delegate)?.ItemDoubleClicked(this, clickedItem);
		}
	}
}
