namespace WebBooks;

public sealed class MainWindowController : NSWindowController
{
	public MainWindowController (NSViewController initialViewController)
	{
		_contentViewController = initialViewController;

		const NSWindowStyle style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

		Window = new NSWindow (new CGRect (100, 100, 920, 780), style, NSBackingStore.Buffered, true)
		{
			Title = "WebBooks",
			TabbingMode = NSWindowTabbingMode.Disallowed,
			ContentView = initialViewController.View,
			InitialFirstResponder = initialViewController.View
		};
	}


	// I should have to do this, but if I try to set `ContentViewController` directly the
	// window disappears and the application stops responding? Work around it.
	public override NSViewController ContentViewController
	{
		get => _contentViewController;
		set {
			Window.ContentView = value.View;
			Window.MakeFirstResponder (value.View);
			_contentViewController = value;
		}
	}

	private NSViewController _contentViewController;
}
