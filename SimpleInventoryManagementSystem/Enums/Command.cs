using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Enums
{
    public enum Command
    {
        none,
        insert,
    }
    public class UserCommands
    {
        public static Command GetCommand(string command)
        {
            switch (command.ToLower())
            {
                case "insert": 
                    return Command.insert;
                default:
                    return Command.none;
            }
        }
    }
}
