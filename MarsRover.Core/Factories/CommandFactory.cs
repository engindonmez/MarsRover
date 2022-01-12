using MarsRover.Core.Commands;
using MarsRover.Core.Commands.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsRover.Core.Factories
{
    public class CommandFactory
    {
        public static void ParseCommandList(string commandList, IList<ICommand> commands)
        {
            if (!string.IsNullOrWhiteSpace(commandList))
            {
                foreach (char command in commandList.ToUpper())
                {
                    switch (command)
                    {
                        case 'M':
                            commands.Add(new MoveCommand());
                            break;
                        case 'L':
                            commands.Add(new TurnLeftCommand());
                            break;
                        case 'R':
                            commands.Add(new TurnRightCommand());
                            break;
                        default:
                            throw new InvalidOperationException("Your command is not valid.");
                    }
                }
            }
        }
    }
}
