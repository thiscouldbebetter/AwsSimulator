using AwsSimulator.Services.S3.Commands;
using System.IO;

namespace AwsSimulator.Services.S3
{
	public class ServiceS3 : Service
	{
		public const string Name = "s3";

		private readonly string _localDirectoryPath;

		public ServiceS3(string localDirectoryPath) : base(Name, CommandsBuild() )
		{
			_localDirectoryPath = localDirectoryPath;
		}

		public static Command[] CommandsBuild()
		{
			return new Command[]
			{
				new CommandS3_Cp(),
				new CommandS3_Ls(),
				new CommandS3_Mv(),
				new CommandS3_Rm()
			};
		}

		private string ConvertPathToLocalIfS3Uri(string pathToConvert)
		{
			const string s3UriPrefix = "s3://";
			if (pathToConvert.StartsWith(s3UriPrefix))
			{
				pathToConvert = pathToConvert.Substring(s3UriPrefix.Length);
				pathToConvert = _localDirectoryPath + pathToConvert;
			}
			return pathToConvert;
		}

		public bool DirectoryExistsAtPath(string directoryPath)
		{
			return Directory.Exists(ConvertPathToLocalIfS3Uri(directoryPath));	
		}

		public string DirectoryContentsListAtPath(string directoryPath)
		{
			var directoryContentsAsString = "";

			if (Directory.Exists(directoryPath))
			{
				var directoryEntries = Directory.GetFileSystemEntries(directoryPath);
				directoryContentsAsString = string.Join("\r\n", directoryEntries);
			}

			return directoryContentsAsString;
		}

		public void FileCopyFromPathToPath(string filePathFrom, string filePathTo)
		{
			if (DirectoryExistsAtPath(filePathFrom))
			{
				filePathFrom = ConvertPathToLocalIfS3Uri(filePathFrom);
				filePathTo = ConvertPathToLocalIfS3Uri(filePathTo);

				File.Copy(filePathFrom, filePathTo);
			}
		}

		public void FileDeleteFromPath(string fileToDeletePath)
		{
			if (FileExistsAtPath(fileToDeletePath))
			{
				File.Delete(fileToDeletePath);
			}
		}

		public bool FileExistsAtPath(string filePath)
		{
			return File.Exists(ConvertPathToLocalIfS3Uri(filePath));	
		}

		public void FileMoveFromPathToPath(string filePathFrom, string filePathTo)
		{
			if (DirectoryExistsAtPath(filePathFrom))
			{
				filePathFrom = ConvertPathToLocalIfS3Uri(filePathFrom);
				filePathTo = ConvertPathToLocalIfS3Uri(filePathTo);

				File.Move(filePathFrom, filePathTo);
			}
		}

	}
}
