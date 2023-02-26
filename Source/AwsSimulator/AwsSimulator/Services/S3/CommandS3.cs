namespace AwsSimulator.Services.S3
{
	public abstract class CommandS3 : Command
	{
		public CommandS3(string name)
			: base(ServiceS3.Name, name)
		{}
	}
}
