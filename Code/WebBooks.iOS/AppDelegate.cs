using WebKit;

namespace WebBooks;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate, IWKNavigationDelegate
{
	private const String InitialPageUrl = "https://essentialcsharp.com/home";
	private const String PrefsLastUrlKey = "LastVisitedUrl";

	private WKWebView? _webView;


	public override UIWindow? Window
	{
		get;
		set;
	}


	// When the application finishes launching...
	public override Boolean FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// Create a web view to show the content
		var config = new WKWebViewConfiguration ();
		_webView = new WKWebView (CGRect.Empty, config) {
			AllowsBackForwardNavigationGestures = true,
			NavigationDelegate = this
		};

		var viewController = new UIViewController () {
			View = _webView
		};

		Window = new UIWindow (UIScreen.MainScreen.Bounds);
		Window.RootViewController = viewController;
		Window.MakeKeyAndVisible ();

		// Figure out what page to load. Use the last visited site that we stored last
		// run, or the book's first page is nothing was previously stored. Just doing the
		// simplest thing here to get something useful.

		String lastVisitedUrl = NSUserDefaults.StandardUserDefaults.StringForKey (PrefsLastUrlKey);
		String urlToVisit = String.IsNullOrEmpty (lastVisitedUrl)
			? InitialPageUrl
			: lastVisitedUrl;

		var request = new NSUrlRequest (new NSUrl (urlToVisit));
		_webView.LoadRequest (request);

		return true;
	}


	// Each time the user navigates...
	[Export ("webView:didFinishNavigation:")]
	public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
	{
		// ...save the current URL
		var currentUrl = _webView?.Url?.ToString ();
		NSUserDefaults.StandardUserDefaults.SetString (currentUrl, PrefsLastUrlKey);
	}
}
