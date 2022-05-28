using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssertTest
{
    public class Pharmacist
    {
        public Pharmacist()
        {
            Pharmacists = new List<Pharmacist>();
        }

        public Pharmacist(int id, string fio, string date, int workExperience)
        {
            Id = id;
            Fio = fio;
            Date = date;
            WorkExperience = workExperience;
            Pharmacists = new List<Pharmacist>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Date { get; set; }
        public int WorkExperience { get; set; }
        public List<Pharmacist> Pharmacists { get; set; }

        public override string ToString()
        {
            return $"{Fio}, {Date}, {WorkExperience}";
        }
        public List<Pharmacist> GetPharmacistOnYear(string med)
        {
            return Pharmacists.Where(x => x.Date == med).ToList();
        }
    }
}
