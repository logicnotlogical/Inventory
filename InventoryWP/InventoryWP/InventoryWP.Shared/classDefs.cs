namespace InventoryWP
{
    /// <summary>
    /// A category with which to sort items.
    /// </summary>
    class ItemCategory
    {
        private string CategoryName;

        /// <summary>
        /// Creates a new item category.
        /// </summary>
        /// <param name="Name">The name of the category.</param>
        public ItemCategory (string Name)
        {
            CategoryName = Name;
        }

        /// <summary>
        /// Retreives the name of the category.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return CategoryName;
        }

        /// <summary>
        /// Changes the name of the category.
        /// </summary>
        /// <param name="NewName">The new name of the category.</param>
        public void SetName(string NewName)
        {
            CategoryName = NewName;
        }
    }

    /// <summary>
    /// One or more of a specific item; for instance a mobile phone, or five AA batteries.
    /// </summary>
    class Item
    {
        private string ItemName;
        private string ItemID;
        private int Quantity;
        //These variables are set as -1 until a value is set.
        private float Weight = -1;
        private float Cost = -1;
        
        public Item (string itemName, string quantity) {

        }
    }
}