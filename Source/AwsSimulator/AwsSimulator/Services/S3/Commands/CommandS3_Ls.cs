namespace AwsSimulator.Services.S3.Commands
{
	public class CommandS3_Ls : CommandS3
	{
		public CommandS3_Ls() : base("ls")
		{ }

		public override string ExecuteAndReturnOutput(
			AwsSimulator awsSimulator, Service service, string[] args
		)
		{
			var directoryPath = args[2];
			var directoryContentsAsString = (service as ServiceS3).DirectoryContentsListAtPath(directoryPath);
			return directoryContentsAsString;
		}
	}
}
