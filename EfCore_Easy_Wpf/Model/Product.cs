using System;

namespace EfCore_Easy_Wpf.Model
{
    public class Product
    {
        public int ProductID { get; internal set; }
        public string Title { get; internal set; }
        public bool IsActive { get; internal set; }
        public DateTime Created { get; internal set; }
        public DateTime Modified { get; internal set; }
        public string CreatedBy { get; internal set; }
    }
}