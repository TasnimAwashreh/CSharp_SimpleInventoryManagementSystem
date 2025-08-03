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
        view,
        edit_price,
        edit_quantity,
        edit_name,
        delete,
    }
    public class UserCommands
    {
        public static Command GetCommand(string command)
        {
            switch (command.ToLower())
            {
                case "insert": 
                    return Command.insert;
                case "view":
                    return Command.view;
                case "edit_price":
                    return Command.edit_price;
                case "edit_quantity":
                    return Command.edit_quantity;
                case "edit_name":
                    return Command.edit_name;
                case "delete":
                    return Command.delete;
                default:
                    return Command.none;
            }
        }
    }
}
