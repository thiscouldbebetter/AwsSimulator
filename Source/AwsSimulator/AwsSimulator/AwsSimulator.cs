using System;
using System.Linq;
using AwsSimulator.Services.S3;

namespace AwsSimulator
{
	public class AwsSimulator
	{
		public Service[] _services;

		public AwsSimulator(Service[] services)
		{
			_services = services;
		}

		private void WriteTextToConsole(string textToWrite)
		{
			Console.WriteLine(textToWrite);
		}

		public void Run(string[] args)
		{

			if (args.Length == 0)
			{
				Console.WriteLine("AWS Simulator running in interactive mode.");
				while (true)
				{
					Console.Write(">");
					var commandAsText = Console.ReadLine();
					var commandParts = commandAsText.Split
					(
						" ".ToCharArray(),
						StringSplitOptions.RemoveEmptyEntries
					);
					CommandParseFromPartsRunAndShowOutput(commandParts);
				}
			}
			else if (args.Length < 2)
			{
				Console.WriteLine("Error: Command not long enough.");
			}
			else
			{
				CommandParseFromPartsRunAndShowOutput(args);
			}
		}

		private void CommandParseFromPartsRunAndShowOutput(string[] commandParts)
		{
			if (commandParts.Length < 2)
			{
				Console.WriteLine("Error: Command not long enough.");
			}
			else
			{
				var serviceName = commandParts[0];
				var service = _services.SingleOrDefault(x => x.Name == serviceName);
				if (service == null)
				{
					Console.WriteLine("Unrecognized service: " + serviceName + ".");
				}
				else
				{
					var commandName = commandParts[1];
					var command = service.CommandByName(commandName);
					if (command == null)
					{
						Console.WriteLine("Unrecognized command: " + commandName + ".");
					}
					else
					{
						var commandOutput = command.ExecuteAndReturnOutput(this, service, commandParts);
						Console.WriteLine(commandOutput);
					}
				}
			}
		}
	}
}
