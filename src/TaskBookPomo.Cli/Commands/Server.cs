using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace TaskBookPomo.Cli.Commands
{
    public class Server : Command
    {
        public Server() : base(name: "server", description: "Spin up Taskbook Pomodoro API Server")
        {
            Handler = CommandHandler.Create(action: Handle);
        }

        private void Handle()
        {
            Web.Program.Main(args: Array.Empty<string>());
        }
    }
}