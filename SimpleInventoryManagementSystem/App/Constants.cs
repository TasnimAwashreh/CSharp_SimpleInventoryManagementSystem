namespace SimpleInventoryManagementSystem.App
{
    public class Constants
    {
        public const string Seperator = "--------------------------------------------------------------------------------------------";
        public const string EmptyInput = "Empty input: Please try again";
        public const string ProcessingStr = "Processing Input...";
        public const string Introduction =
                        $"""
            ============================================================================================
            **                                                                                        **
            **                           Welcome to the Inventory Management System                   **
            **                                                                                        **
            ============================================================================================
            How to Use:
                - To add a product to the inventory: 
                  'insert [product_name] [price] [quantity]'
                  Example: insert potato 6.50 7

                - To view the current inventory, simply type in 'view'

                - To update the product's name:
                  'edit_name [product_name] [new product name]'

                - To update the product's quantity:
                  'edit_quantity [current_quantity] [new_quantity]'

                - To update the product's price:
                  'edit_price [old_price] [new_price]'

                - To delete product:
                  'delete [product_name]'

                - To search for a product:
                  'search [product_name]'

                - To exit: simply type 'exit'
            """;

        public const string InsertProduct = "Please enter the product name, price, and product quantity to insert";
        public const string ProductExists = "This product already exists. ";
        public const string ProductDoesNotExist = "This product does not exist. ";
        public const string ProductInserted = "Product has been inserted successfully. ";
        public const string IncorrectInformation = "Please enter the necessary input";
        public const string IncorrectFormat = "Please enter information in the correct format";
        public const string SuccessfulProductUpdate = "Product has been successfully updated";
        public const string UpdateName = "Please enter the product name and its new name";
        public const string UpdatePrice = "Please enter the product name and price";
        public const string UpdateQty = "Please enter the product name and quantity";
        public const string UpdateNameFormatIncorrect = "Please enter the current product's name and its new name";
        public const string UpdatePriceFormatIncorrect = "Please enter the product name and new price";
        public const string UpdateQtyFormatIncorrect = "Please enter the product name and new quantity";
        public const string AppropriateActionError = "\n Please enter an appropriate action";
    }
}
