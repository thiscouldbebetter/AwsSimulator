using AwsSimulator.Services.S3;

namespace AwsSimulator
{
	class Program
	{
		static void Main(string[] args)
		{
			var serviceS3LocalDirectoryPath = "/Temp/s3"; // todo
			var serviceS3 = new ServiceS3(serviceS3LocalDirectoryPath);
			
			var services = new Service[] { serviceS3 };
			
			var awsSimulator = new AwsSimulator(services);

			awsSimulator.Run(args);
		}
	}
}
