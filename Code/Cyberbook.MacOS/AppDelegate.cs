using Cyberbook.Common;

using Industrious.Storage;

namespace Cyberbook.MacOS;

// ReSharper disable once UnusedType.Global
[Register("AppDelegate")]
public class AppDelegate : NSApplicationDelegate
{
	private CommonApplication? _commonApplication;

	private readonly MainWindowController _mainWindowController = new();


	public override void DidFinishLaunching(NSNotification notification)
	{
		_commonApplication = CommonApplication.Create(FileStorageProvider.Icloud);

		_mainWindowController.ShowWindow(this);
	}


	public override Boolean SupportsSecureRestorableState(NSApplication application)
	{
		return true;
	}


	public override void WillTerminate(NSNotification notification)
	{
		// Insert code here to tear down your application
	}
}
