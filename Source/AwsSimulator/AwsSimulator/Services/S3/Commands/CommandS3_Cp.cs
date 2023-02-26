
namespace AwsSimulator.Services.S3.Commands
{
	public class CommandS3_Cp : CommandS3
	{
		public CommandS3_Cp() : base("cp")
		{ }

		public override string ExecuteAndReturnOutput
		(
			AwsSimulator awsSimulator, Service service, string[] args
		)
		{
			var filePathFrom = args[2];
			var filePathTo = args[3];
			(service as ServiceS3).FileCopyFromPathToPath(filePathFrom, filePathTo);
			var outputText = "Copied from '" + filePathFrom + "' to '" + filePathTo + "'.";
			return outputText;
		}
	}
}
