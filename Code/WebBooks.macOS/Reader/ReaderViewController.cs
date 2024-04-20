using WebKit;

namespace WebBooks.Reader;

public class ReaderViewController : NSViewController
{
	private readonly AppDelegate _appDelegate;
	private readonly String _url;
	private WKWebView? _webView;


	public ReaderViewController (AppDelegate appDelegate, String url)
	{
		_appDelegate = appDelegate;
		_url = url;
	}


	public override void LoadView ()
	{
		var config = new WKWebViewConfiguration ();

		_webView = new WKWebView (CGRect.Empty, config) {
			AllowsBackForwardNavigationGestures = true,
			AllowsMagnification = true
		};

		var request = new NSUrlRequest (new NSUrl (_url));
		_webView.LoadRequest (request);

		View = _webView;
		Zoom = 100;
	}


	[Action ("showUserLibrary:")]
	public void ShowUserLibrary (NSObject sender)
	{
		_appDelegate.ShowLibraryView ();
	}


	private const String ZoomToActualAction = "zoomImageToActualSize:";
	private const String ZoomInAction = "zoomIn:";
	private const String ZoomOutAction = "zoomOut:";

	private Int32 Zoom
	{
		get => _zoom;
		set {
			_zoom = value;
			_webView!.PageZoom = _zoom / 100.0f;
		}
	}

	private Int32 _zoom = 100;


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
}
