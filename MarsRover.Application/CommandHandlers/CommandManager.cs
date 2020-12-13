using MarsRover.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.CommandHandlers
{
    public class CommandManager
    {
        public List<ICommand> Commands { get; set; } = new List<ICommand>();

        public void InvokeAll()
        {
            foreach (var command in Commands)
            {
                command.Execute();
            }
        }
    }
}
