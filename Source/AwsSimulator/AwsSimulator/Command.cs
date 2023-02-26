
namespace AwsSimulator
{
	public abstract class Command
	{
		public readonly string Name;
		public readonly string ServiceName;

		public Command(string serviceName, string name)
		{
			ServiceName = serviceName;
			Name = name;
		}

		public abstract string ExecuteAndReturnOutput(AwsSimulator awsSimulator, Service service, string[] arguments);
	}
}
