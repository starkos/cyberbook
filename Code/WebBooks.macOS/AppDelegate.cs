using WebBooks.Library;
using WebBooks.Reader;

namespace WebBooks;

// ReSharper disable once ClassNeverInstantiated.Global
[Register ("AppDelegate")]
public class AppDelegate : NSApplicationDelegate
{
	private const String InitialPageUrl = "https://deadwinter.cc/page/1";

	// maybe move this to a preferences wrapper class?
	private const String LastUrlVisitedKey = "LastVisitedUrl";

	private readonly List<MainWindowController> _windowControllers = new ();


	public override void DidFinishLaunching (NSNotification notification)
	{
		// Open an initial window to the library view. This should read the window
		// state out of storage and restore it, eventually
		var viewController = new LibraryViewController (this);
		var windowController = new MainWindowController (viewController);
		_windowControllers.Add (windowController);

		// TODO encapsulate this logic if it works (could end up in a MacOS utility library)
		windowController.ShowWindow (this);
		windowController.Window.MakeKeyAndOrderFront (this);
	}


	public void OnBookSelected ()
	{
		// Figure out what page to load. Use the last visited site that we stored last
		// run, or the books first page is nothing was previously stored. Just doing the
		// simplest thing her to get something useful.
		var lastVisitedUrl = NSUserDefaults.StandardUserDefaults.StringForKey (LastUrlVisitedKey);
		var urlToVisit = String.IsNullOrEmpty (lastVisitedUrl)
			? InitialPageUrl
			: lastVisitedUrl;

		var viewController = new ReaderViewController (this, urlToVisit);

		// TODO: which window controller fired this event? For now just grab the one and only in the list
		var windowController = _windowControllers[0];
		windowController.ContentViewController = viewController;
	}


	public void ShowLibraryView ()
	{
		// TODO: which window controller fired this event? For now just grab the one and only in the list
		var windowController = _windowControllers[0];
		windowController.ContentViewController = new LibraryViewController (this);
	}


	public override Boolean SupportsSecureRestorableState (NSApplication application)
	{
		return true;
	}


	public override void WillTerminate (NSNotification notification)
	{
		// Remember where we left off when quitting
		// I think I should do this on page navigation instead

		// var currentUrl = _mainWindowController.CurrentUrl;
		// NSUserDefaults.StandardUserDefaults.SetString (currentUrl, LastUrlVisitedKey);
	}
}
