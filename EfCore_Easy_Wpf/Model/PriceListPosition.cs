namespace EfCore_Easy_Wpf.Model
{
    public class PriceListPosition
    {
        public int PriceListPositionID { get; internal set; }
        public int PriceListID { get; internal set; }
        public int ProductID { get; internal set; }
        public double Price { get; internal set; }
    }
}