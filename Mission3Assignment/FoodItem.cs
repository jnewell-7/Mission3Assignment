namespace Mission3Assignment
{
    internal class FoodItem
    {
        // Properties for a food item
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Constructor
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity >= 0 ? quantity : throw new ArgumentException("Quantity cannot be negative.");
            ExpirationDate = expirationDate;
        }

        // Override ToString for easy display
        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }
    }
}