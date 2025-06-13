namespace Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; } // ID товара (например, LegoCar)
        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}
