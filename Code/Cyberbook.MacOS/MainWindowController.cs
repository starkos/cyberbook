namespace Cyberbook.MacOS;

public sealed class MainWindowController : NSWindowController
{
	private const NSWindowStyle MainWindowStyle = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;


	private MainWindowController ()
	{}


	public static MainWindowController New(NSViewController initialViewController)
	{
		return new MainWindowController
		{
			Window = new NSWindow (new CGRect (100, 100, 800, 600), MainWindowStyle, NSBackingStore.Buffered, true)
			{
				ContentView = initialViewController.View,
				Title = "Cyberbook"
			},
			WindowFrameAutosaveName = "MainWindow"
		};
	}
}
