using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectionAssertTest;
using System.Linq;
using System;
using System.Collections.Generic;

namespace CollectionAssertModuleTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetMedicinesOnNameTest()
        {
            var medicineName = "нурофен";   
            List<Medicines> medicines = new List<Medicines>() 
            {
                new Medicines(1, "нурофен", "НурофенСтрой", 666, 4), 
                new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2), 
                new Medicines(3, "нурофен3", "Нурофениум", 333, 10)
            };
            CollectionAssert.IsNotSubsetOf(medicines.Where(x => x.Name == medicineName).ToList(), Program.GetMedicinesOnName(medicineName));
        }

        [TestMethod]
        public void GetMedicinesOnManufactureTest()
        {
            var medicineName = "НурофенСтрой";
            List<Medicines> medicines = new List<Medicines>()
            {
                new Medicines(1, "нурофен", "НурофенСтрой", 666, 4),
                new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2),
                new Medicines(3, "нурофен3", "Нурофениум", 333, 10)
            };
            CollectionAssert.IsNotSubsetOf(medicines.Where(x => x.Manufacture == medicineName).ToList(), Program.GetMedicinesOnManufacture(medicineName));
        }

        [TestMethod]
        public void GetTheMostExpensiveMedicineTest()
        {
            var medicine = new Medicines(1, "нурофен", "НурофенСтрой", 666, 4);
            Assert.AreNotEqual(medicine, Program.GetTheMostExpensiveMedicine());
        }

        [TestMethod]
        public void SortUpPriceTest()
        {
            List<Medicines> medicines = new List<Medicines>() 
            { 
                new Medicines(3, "нурофен3", "Нурофениум", 333, 10),
                new Medicines(1, "нурофен", "НурофенСтрой", 666, 4), 
                new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2), 
            };
            CollectionAssert.IsNotSubsetOf(medicines, Program.SortUpPrice());
        }

        [TestMethod]
        public void SortDownPriceTest()
        {
            List<Medicines> medicines = new List<Medicines>() 
            { 
                new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2), 
                new Medicines(1, "нурофен", "НурофенСтрой", 666, 4), 
                new Medicines(3, "нурофен3", "Нурофениум", 333, 10) 
            };
            CollectionAssert.IsNotSubsetOf(medicines, Program.SortDownPrice());
        }

        [TestMethod]
        public void GetMediciniesOfThisPharmacyTest()
        {
            int Id = 1;
            List<Medicines> medicines = new List<Medicines>() 
            { 
                new Medicines(1, "нурофен", "НурофенСтрой", 666, 4), 
                new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2), 
                new Medicines(3, "нурофен3", "Нурофениум", 333, 10) 
            };
            List<Medicines> medicines2 = new List<Medicines>() 
            { 
                new Medicines(1, "нурофен22", "НурофенСтрой", 666, 4), 
                new Medicines(2, "нурофен23", "НурофенСтрой", 777, 2), 
                new Medicines(3, "нурофен23", "Нурофениум", 333, 10) 
            };
            List<Pharmacy> pharmacies = new List<Pharmacy>() 
            { 
                new Pharmacy(1, "Казань", medicines),
                new Pharmacy(2, "Саратов", medicines2) 
            };

            CollectionAssert.IsNotSubsetOf(pharmacies.Find(x => x.Id == Id).MedicinesList, Program.GetMediciniesOfThisPharmacy(Id));
        }

        [TestMethod]
        public void GetPharmacistOnYearTest()
        {
            var date = "1972";
            List<Pharmacist> pharmacist = new List<Pharmacist>() 
            { 
                new Pharmacist(1, "Иван Петров", "1972", 20), 
                new Pharmacist(2, "Петр Иванов", "1982", 10), 
                new Pharmacist(3, "Иван Иванов", "1962", 30) 
            };
            CollectionAssert.IsNotSubsetOf(pharmacist.Where(x => x.Date == date).ToList(), Program.GetPharmacistOnYear(date));
        }  
    }
}
