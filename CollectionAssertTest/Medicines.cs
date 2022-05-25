using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssertTest
{
    public class Medicines : IComparable
    {
        public Medicines(int id, string name, string manufacture, double price, int pharmacyCount)
        {
            Id = id;
            Name = name;
            Manufacture = manufacture;
            Price = price;
            PharmacyCount = pharmacyCount;
        }

        public Medicines()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public double Price { get; set; }
        public int PharmacyCount { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Manufacture}, {Price}, {PharmacyCount}";
        }

        public int CompareTo(object obj)
        {
            var book = (Medicines)obj;
            return (Price.CompareTo(book.Price));
        }
    }
}
