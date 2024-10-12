using Cyberbook.Common.Models;

using ObjCRuntime;

namespace Cyberbook.MacOS.Views;

public class LibraryViewItemController(NativeHandle handle)
	: NSCollectionViewItem(handle)
{
	private NSTextField? _textField;


	public Book? Book
	{
		set
		{
			_textField!.StringValue = value?.Title ?? String.Empty;
		}
	}


	public override void LoadView()
	{
		View = _textField = new NSTextField()
		{
			StringValue = String.Empty,
			Editable = false
		};
	}
}
