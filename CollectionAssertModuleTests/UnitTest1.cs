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
            Medicines medicine = new Medicines();
            List<Medicines> medicines = new List<Medicines>();

            var med1 = new Medicines(1, "нурофен", "НурофенСтрой", 666, 4);
            var med2 = new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2);
            var med3 = new Medicines(3, "нурофен3", "Нурофениум", 333, 10);

            medicines.Add(med1);

            medicine.medicines.Add(med1);
            medicine.medicines.Add(med2);
            medicine.medicines.Add(med3);

            CollectionAssert.AreEqual(medicines, medicine.GetMedicinesOnName(medicineName));
        }

        [TestMethod]
        public void GetMedicinesOnManufactureTest()
        {
            var medicineName = "НурофенСтрой";
            List<Medicines> medicines = new List<Medicines>();
            Medicines medicine = new Medicines();

            var med1 = new Medicines(1, "нурофен", "НурофенСтрой", 666, 4);
            var med2 = new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2);
            var med3 = new Medicines(3, "нурофен3", "Нурофениум", 333, 10);

            medicines.Add(med1);
            medicines.Add(med2);

            medicine.medicines.Add(med1);
            medicine.medicines.Add(med2);
            medicine.medicines.Add(med3);

            CollectionAssert.AreEqual(medicines, medicine.GetMedicinesOnManufacture(medicineName));
        }

        [TestMethod]
        public void GetTheMostExpensiveMedicineTest()
        {
            var medicine = new Medicines();

            var med1 = new Medicines(1, "нурофен", "НурофенСтрой", 667, 4);
            var med2 = new Medicines(1, "нурофен", "НурофенСтрой", 333, 4);
            var med3 = new Medicines(1, "нурофен", "НурофенСтрой", 444, 4);

            medicine.medicines.Add(med1);
            medicine.medicines.Add(med2);
            medicine.medicines.Add(med3);

            Assert.AreEqual(med1, medicine.GetTheMostExpensiveMedicine());
        }

        [TestMethod]
        public void SortUpPriceTest()
        {
            List<Medicines> medicines = new List<Medicines>();
            Medicines medicine = new Medicines();

            var med1 = new Medicines(3, "нурофен3", "Нурофениум", 333, 10);
            var med2 = new Medicines(1, "нурофен", "НурофенСтрой", 666, 4);
            var med3 = new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2);

            medicines.Add(med1);
            medicines.Add(med2);
            medicines.Add(med3);

            medicine.medicines.Add(med1);
            medicine.medicines.Add(med2);
            medicine.medicines.Add(med3);

            CollectionAssert.AreEqual(medicines, medicine.SortUpPrice());
        }

        [TestMethod]
        public void SortDownPriceTest()
        {
            List<Medicines> medicines = new List<Medicines>();
            Medicines medicine = new Medicines();

            var med1 = new Medicines(3, "нурофен3", "Нурофениум", 333, 10);
            var med2 = new Medicines(1, "нурофен", "НурофенСтрой", 666, 4);
            var med3 = new Medicines(2, "нурофен2", "НурофенСтрой", 777, 2);

            medicines.Add(med3);
            medicines.Add(med2);
            medicines.Add(med1);

            medicine.medicines.Add(med3);
            medicine.medicines.Add(med2);
            medicine.medicines.Add(med1);

            CollectionAssert.AreEqual(medicines, medicine.SortDownPrice());
        }

        [TestMethod]
        public void GetMediciniesOfThisPharmacyTest()
        {
            Pharmacy pharmacy = new Pharmacy();
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
            var phar1 = new Pharmacy(1, "Казань", medicines);
            var phar2 = new Pharmacy(2, "Саратов", medicines2);

            pharmacy.Pharmacies.Add(phar1);
            pharmacy.Pharmacies.Add(phar2);

            CollectionAssert.AreEqual(phar1.MedicinesList, pharmacy.GetMediciniesOfThisPharmacy(phar1.Id));
        }

        [TestMethod]
        public void GetPharmacistOnYearTest()
        {
            var farmacevtss = new List<Pharmacist>();
            var fam = new Pharmacist();

            var fam1 = new Pharmacist(1, "Иванов", "2000", 23);
            var fam2 = new Pharmacist(1, "Петров", "1999", 12);
            var fam3 = new Pharmacist(1, "Сергеев", "2001", 6);

            farmacevtss.Add(fam3);

            fam.Pharmacists.Add(fam1);
            fam.Pharmacists.Add(fam2);
            fam.Pharmacists.Add(fam3);

            CollectionAssert.AreEqual(farmacevtss, fam.GetPharmacistOnYear("2001"));
        }  
    }
}
