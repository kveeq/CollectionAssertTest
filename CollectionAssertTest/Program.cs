using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssertTest
{
    public class Program
    {
        static List<Medicines> medicines = new List<Medicines>() {new Medicines(1, "нурофен", "НурофенСтрой", 666, 4), new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2), new Medicines(3, "нурофен3", "Нурофениум", 333, 10) };
        static List<Medicines> medicines2 = new List<Medicines>() {new Medicines(1, "нурофен22", "НурофенСтрой", 666, 4), new Medicines(2, "нурофен23", "НурофенСтрой", 777, 2), new Medicines(3, "нурофен23", "Нурофениум", 333, 10) };
        static List<Pharmacist> pharmacist = new List<Pharmacist>() { new Pharmacist(1, "Иван Петров", "1972", 20), new Pharmacist(2, "Петр Иванов", "1982", 10), new Pharmacist(3, "Иван Иванов", "1962", 30) };
        static List<Pharmacy> pharmacies = new List<Pharmacy>() { new Pharmacy(1, "Казань", medicines), new Pharmacy(2, "Саратов", medicines2)};
        static void Main(string[] args)
        {

            while (true)
            {
                int a = GetMenu();
                if (a == 1)
                {
                    Console.WriteLine("Введите название лекартсва");
                    var med = Console.ReadLine();
                    GetMedicinesOnName(med);
                }
                else if (a == 2)
                {
                    Console.WriteLine("Введите производителя");
                    var med = Console.ReadLine();
                    GetMedicinesOnManufacture(med);
                }
                else if (a == 3)
                {
                    GetTheMostExpensiveMedicine();
                }
                else if (a == 4)
                {
                    Sort();
                }
                else if (a == 5)
                {
                    ShowList(pharmacies);
                    Console.WriteLine("Выберите Id аптеки");
                    var med = int.Parse(Console.ReadLine());
                    GetMediciniesOfThisPharmacy(med);
                }
                else if (a == 6)
                {
                    Console.WriteLine("Введите год рождения");
                    var med = Console.ReadLine();
                    GetPharmacistOnYear(med);
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        private static int GetMenu()
        {
            Console.WriteLine("1) Список лекарств по названию");
            Console.WriteLine("2) Список лекарств по производителю");
            Console.WriteLine("3) Получение самого дорогого лекарства");
            Console.WriteLine("4) Сортировка списка по возрастанию и убыванию цены");
            Console.WriteLine("5) Получение списка лекарств, которые имеются в ассортименте данной аптеки");
            Console.WriteLine("6) Список фармацевтов родившихся в определенном году");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static void ShowList<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            if (items.Count == 0 || items == null)
            {
                Console.WriteLine("Элемент не существует!");
            }
        }

        public static List<Medicines> GetMedicinesOnName(string name)
        {
            var a = medicines.Where(x => x.Name == name).ToList();
            ShowList(a);
            return a;
        }
        
        public static List<Medicines> GetMedicinesOnManufacture(string name)
        {
            var a = medicines.Where(x => x.Manufacture == name).ToList();
            ShowList(a);
            return a;
        }
        
        public static Medicines GetTheMostExpensiveMedicine()
        {
            var item = medicines.Where(x => x.Price == (medicines.Max(a => a.Price))).FirstOrDefault();
            Console.WriteLine(item);
            return item;
        }

        public static void Sort()
        {
            Console.WriteLine($"1) Сортировать по возрастанию цены\n2) Сортировать по убыванию цены");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
                SortUpPrice();
            else
                SortDownPrice();
        }

        public static List<Medicines> GetMediciniesOfThisPharmacy(int Id)
        {
            var a = pharmacies.Where(x => x.Id == Id).FirstOrDefault().MedicinesList;
            ShowList(a);
            return a;
        }

        public static List<Pharmacist> GetPharmacistOnYear(string med)
        {
            var a = pharmacist.Where(x => x.Date == med).ToList();
            ShowList(a);
            return a;
        }

        public static List<Medicines> SortDownPrice()
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
            ShowList(medicines);
            return medicines;
        }

        public static List<Medicines> SortUpPrice()
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
            ShowList(medicines);
            return medicines;
        }
    }
}