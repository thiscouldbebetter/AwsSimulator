
namespace AwsSimulator.Services.S3.Commands
{
	public class CommandS3_Mv : CommandS3
	{
		public CommandS3_Mv() : base("mv")
		{ }

		public override string ExecuteAndReturnOutput
		(
			AwsSimulator awsSimulator, Service service, string[] args
		)
		{
			var filePathFrom = args[2];
			var filePathTo = args[3];
			(service as ServiceS3).FileMoveFromPathToPath(filePathFrom, filePathTo);
			var outputText = "Moved from '" + filePathFrom + "' to '" + filePathTo + "'.";
			return outputText;
		}
	}
}
