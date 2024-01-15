using WebKit;

namespace WebBooks;

public sealed class MainWindowController : NSWindowController
{
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
		var webView = new WKWebView (CGRect.Empty, new WKWebViewConfiguration ());
		Window.ContentView = webView;

		// Load the first page into the web view
		var url = new NSUrl ("https://deadwinter.cc/page/1");
		var request = new NSUrlRequest (url);
		webView.LoadRequest (request);
	}
}
