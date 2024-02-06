namespace WebBooks;

[Register ("AppDelegate")]
public class AppDelegate : NSApplicationDelegate
{
	private const String InitialPageUrl = "https://essentialcsharp.com/home";
	private const String PrefsLastUrlKey = "LastVisitedUrl";

	private readonly MainWindowController _mainWindowController = new();


	public override void DidFinishLaunching (NSNotification notification)
	{
		_mainWindowController.ShowWindow (this);

		// Figure out what page to load. Use the last visited site that we stored last
		// run, or the books first page is nothing was previously stored. Just doing the
		// simplest thing here to get something useful.

		String lastVisitedUrl = NSUserDefaults.StandardUserDefaults.StringForKey (PrefsLastUrlKey);
		String urlToVisit = String.IsNullOrEmpty (lastVisitedUrl)
			? InitialPageUrl
			: lastVisitedUrl;

		_mainWindowController.LoadUrl (urlToVisit);
	}


	public override Boolean SupportsSecureRestorableState (NSApplication application)
	{
		return true;
	}


	public override void WillTerminate (NSNotification notification)
	{
		// Remember where we left off when quitting
		var currentUrl = _mainWindowController.CurrentUrl;
		NSUserDefaults.StandardUserDefaults.SetString (currentUrl, PrefsLastUrlKey);
	}
}
