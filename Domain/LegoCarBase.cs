namespace LegoCarStoreEF.Domain
{
    public abstract class LegoCarBase
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public abstract string GetCategory();
    }
}
