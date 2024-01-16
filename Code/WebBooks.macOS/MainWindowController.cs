using WebKit;

namespace WebBooks;

public sealed class MainWindowController : NSWindowController
{
	private readonly WKWebView _webView;


	public MainWindowController ()
	{
		// Create the main application window
		const NSWindowStyle style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
		Window = new NSWindow (new CGRect (100, 100, 800, 600), style, NSBackingStore.Buffered, true)
		{
			Title = "WebBooks"
		};

		// Remember where the user leaves it
		WindowFrameAutosaveName = "MainWindow";

		// Create a web view to put in it
		_webView = new WKWebView (CGRect.Empty, new WKWebViewConfiguration ());
		Window.ContentView = _webView;

	}


	public String? CurrentUrl => _webView.Url?.ToString ();


	public void LoadUrl (String url)
	{
		var request = new NSUrlRequest (new NSUrl (url));
		_webView.LoadRequest (request);
	}
}
