using WebKit;

namespace WebBooks;

public sealed class MainWindowController : NSWindowController
{
	private readonly WKWebView _webView;

	private Int32 _zoom = 100;


	public MainWindowController ()
	{
		// Create a web view to show the content
		var config = new WKWebViewConfiguration ();
		_webView = new WKWebView (CGRect.Empty, config) {
			AllowsBackForwardNavigationGestures = true,
			AllowsMagnification = true
		};

		// Put it in a window
		const NSWindowStyle style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
		Window = new NSWindow (new CGRect (100, 100, 800, 600), style, NSBackingStore.Buffered, true)
		{
			Title = "WebBooks",
			ContentView = _webView
		};

		// Remember where the user leaves it
		WindowFrameAutosaveName = "MainWindow";

		Zoom = 100;
	}


	public String? CurrentUrl => _webView.Url?.ToString ();


	public void LoadUrl (String url)
	{
		var request = new NSUrlRequest (new NSUrl (url));
		_webView.LoadRequest (request);
	}


	//---------------------------------------
	// this all belongs somewhere else

	private const String ZoomToActualAction = "zoomImageToActualSize:";
	private const String ZoomInAction = "zoomIn:";
	private const String ZoomOutAction = "zoomOut:";

	private Int32 Zoom
	{
		get => _zoom;
		set {
			_zoom = value;
			_webView.PageZoom = _zoom / 100.0f;
		}
	}


	[Action (ZoomToActualAction)]
	public void ZoomActualSize (NSObject sender)
	{
		Zoom = 100;
	}


	[Action (ZoomInAction)]
	public void ZoomIn (NSObject sender)
	{
		Zoom += 10;
	}


	[Action (ZoomOutAction)]
	public void ZoomOut (NSObject sender)
	{
		Zoom -= 10;
	}


	[Action("validateMenuItem:")]
	public Boolean ValidateMenuItem (NSMenuItem item)
	{
		return item.Action?.Name switch {
			ZoomToActualAction => (Zoom != 100),
			ZoomInAction => (Zoom < 500),
			ZoomOutAction => (Zoom > 10),
			_ => true
		};
	}
}
