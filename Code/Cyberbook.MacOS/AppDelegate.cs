using Cyberbook.Common;
using Cyberbook.Common.ViewModels;
using Cyberbook.MacOS.Views;

using Industrious.Storage;

namespace Cyberbook.MacOS;

// ReSharper disable once UnusedType.Global
[Register("AppDelegate")]
public class AppDelegate : NSApplicationDelegate
{
	private CommonApplication? _commonApplication;
	private MainWindowController? _mainWindowController;


	public override void DidFinishLaunching(NSNotification notification)
	{
		_commonApplication = CommonApplication.New(FileStorageProvider.Icloud);

		var initialViewModel = new LibraryViewModel();
		var initialViewController = new LibraryViewController(initialViewModel);

		_mainWindowController = MainWindowController.New(initialViewController);
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
