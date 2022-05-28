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
            medicines = new List<Medicines>();
        }

        public Medicines()
        {
            medicines = new List<Medicines>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public double Price { get; set; }
        public int PharmacyCount { get; set; }
        public List<Medicines> medicines { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Manufacture}, {Price}, {PharmacyCount}";
        }

        public int CompareTo(object obj)
        {
            var book = (Medicines)obj;
            return (Price.CompareTo(book.Price));
        }

        public List<Medicines> GetMedicinesOnName(string name)
        {
            return medicines.Where(x => x.Name == name).ToList();
        }

        public List<Medicines> GetMedicinesOnManufacture(string name)
        {
            return medicines.Where(x => x.Manufacture == name).ToList();
        }

        public Medicines GetTheMostExpensiveMedicine()
        {
            return medicines.Where(x => x.Price == (medicines.Max(a => a.Price))).FirstOrDefault();
        }

        public List<Medicines> SortDownPrice()
        {
            for (int i = medicines.Count - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    object element1 = medicines[(j - 1)];
                    object element2 = medicines[(j)];
                    var comparableElement1 = (IComparable)element1;
                    if (comparableElement1.CompareTo(element2) < 0)
                    {
                        object temporary = medicines[(j)];
                        medicines[j] = (medicines[j - 1]);
                        medicines[j - 1] = (Medicines)temporary;
                    }
                }
            return medicines;
        }

        public List<Medicines> SortUpPrice()
        {
            for (int i = medicines.Count - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    object element1 = medicines[(j - 1)];
                    object element2 = medicines[(j)];
                    var comparableElement1 = (IComparable)element1;
                    if (comparableElement1.CompareTo(element2) > 0)
                    {
                        object temporary = medicines[(j)];
                        medicines[j] = (medicines[j - 1]);
                        medicines[j - 1] = (Medicines)temporary;
                    }
                }
            return medicines;
        }
    }
}
