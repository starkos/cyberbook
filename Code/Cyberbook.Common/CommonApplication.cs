using Industrious.Storage;

namespace Cyberbook.Common;

public class CommonApplication
{
	private CommonApplication(IFileStorageProvider fileStorage)
	{
		FileStorage = fileStorage;
	}


	public static CommonApplication New(FileStorageProvider defaultStorageProvider)
	{
		var fileStorage = Industrious.Storage.FileStorage.Connect(defaultStorageProvider);

		return new CommonApplication(fileStorage);
	}


	public IFileStorageProvider FileStorage { get; init; }
}
