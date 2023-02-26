
namespace AwsSimulator.Services.S3.Commands
{
	public class CommandS3_Rm : CommandS3
	{
		public CommandS3_Rm() : base("rm")
		{ }

		public override string ExecuteAndReturnOutput
		(
			AwsSimulator awsSimulator, Service service, string[] args
		)
		{
			var fileToDeletePath = args[2];
			(service as ServiceS3).FileDeleteFromPath(fileToDeletePath);
			var outputText = "Deleted from '" + fileToDeletePath;
			return outputText;
		}
	}
}
