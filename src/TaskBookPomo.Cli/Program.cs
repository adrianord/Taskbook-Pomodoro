using System.CommandLine;
using TaskBookPomo.Cli.Commands;

namespace TaskBookPomo.Cli
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            var rootCommand = new RootCommand(description: "Task Book Pomodoro");
            rootCommand.AddCommand(command: new Server());
        
            return rootCommand.InvokeAsync(args: args).Result;
        }
    }
}