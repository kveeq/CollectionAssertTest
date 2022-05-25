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
        }

        public Pharmacy(int id, string address, List<Medicines> medicinesList)
        {
            Id = id;
            Address = address;
            MedicinesList = medicinesList;
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public List<Medicines> MedicinesList{ get; set; }

        public override string ToString()
        {
            return Id + ") " + Address;
        }
    }
}
