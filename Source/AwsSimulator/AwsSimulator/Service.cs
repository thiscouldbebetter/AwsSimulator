using System.Linq;

namespace AwsSimulator
{
	public abstract class Service
	{
		public string Name;
		public Command[] Commands;

		public Service(string name, Command[] commands)
		{
			Name = name;
			Commands = commands;
		}

		public Command CommandByName(string commandName)
		{
			return Commands.SingleOrDefault(x => x.Name == commandName);
		}
	}
}
