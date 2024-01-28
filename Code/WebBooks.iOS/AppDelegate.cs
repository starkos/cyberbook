using WebKit;

namespace WebBooks;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
	private const String InitialPageUrl = "https://essentialcsharp.com/home";
	private const String PrefsLastUrlKey = "LastVisitedUrl";

	private WKWebView? _webView;


	public override UIWindow? Window
	{
		get;
		set;
	}


	public override Boolean FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// Create a web view to show the content
		var config = new WKWebViewConfiguration ();
		_webView = new WKWebView (CGRect.Empty, config) {
			AllowsBackForwardNavigationGestures = true
		};

		var viewController = new UIViewController () {
			View = _webView
		};

		Window = new UIWindow (UIScreen.MainScreen.Bounds);
		Window.RootViewController = viewController;
		Window.MakeKeyAndVisible ();

		// Figure out what page to load. Use the last visited site that we stored last
		// run, or the books first page is nothing was previously stored. Just doing the
		// simplest thing here to get something useful.

		String lastVisitedUrl = NSUserDefaults.StandardUserDefaults.StringForKey (PrefsLastUrlKey);
		String urlToVisit = String.IsNullOrEmpty (lastVisitedUrl)
			? InitialPageUrl
			: lastVisitedUrl;

		var request = new NSUrlRequest (new NSUrl (urlToVisit));
		_webView.LoadRequest (request);

		return true;
	}


	public override void DidEnterBackground (UIApplication application)
	{
		// Remember where we left off when quitting
		var currentUrl = _webView?.Url?.ToString ();
		NSUserDefaults.StandardUserDefaults.SetString (currentUrl, PrefsLastUrlKey);

		Console.WriteLine ($"DidEnterBackground: {currentUrl}");
	}
}
