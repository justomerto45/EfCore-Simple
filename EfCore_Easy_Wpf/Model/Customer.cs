namespace EfCore_Easy_Wpf.Model
{
    public class Customer
    {
        public int CustomerID { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int CustomerTypeID { get; internal set; }
        public int CustomerStateID { get; internal set; }
    }
}