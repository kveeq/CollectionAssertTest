using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssertTest
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            Pharmacies = new List<Pharmacy>();
            MedicinesList = new List<Medicines>();
        }

        public Pharmacy(int id, string address, List<Medicines> medicinesList)
        {
            Id = id;
            Address = address;
            MedicinesList = medicinesList;
            Pharmacies = new List<Pharmacy>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public List<Medicines> MedicinesList{ get; set; }
        public List<Pharmacy> Pharmacies{ get; set; }

        public override string ToString()
        {
            return Id + ") " + Address;
        }

        public List<Medicines> GetMediciniesOfThisPharmacy(int Id)
        {
            return Pharmacies.Where(x => x.Id == Id).FirstOrDefault().MedicinesList;
        }

    }
}
