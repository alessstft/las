namespace LegoCarStoreEF.Domain
{
    public class CarLogic
    {
        public bool IsValidPrice(decimal price) => price >= 0 && price < 1000;
        public string FormatDisplay(LegoCarBase car)
        {
            return $"[{car.GetCategory()}] {car.Name} - {car.Price:C}";
        }
    }
}
