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
        None = 0,
        Insert = 1,
        View = 2,
        EditPrice = 3,
        EditQuantity = 4,
        EditName = 5,
        Delete = 6,
        Search = 7,
        Exit = 8
    }
    public class UserCommands
    {
        public static Command ParseCommand(string command)
        {
            switch (command.ToLower())
            {
                case "insert": 
                    return Command.Insert;
                case "view":
                    return Command.View;
                case "edit_price":
                    return Command.EditPrice;
                case "edit_quantity":
                    return Command.EditQuantity;
                case "edit_name":
                    return Command.EditName;
                case "delete":
                    return Command.Delete;
                case "search":
                    return Command.Search;
                case "exit":
                    return Command.Exit;
                default:
                    return Command.None;
            }
        }
    }
}
