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
        }

        public Pharmacist(int id, string fio, string date, int workExperience)
        {
            Id = id;
            Fio = fio;
            Date = date;
            WorkExperience = workExperience;
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Date { get; set; }
        public int WorkExperience { get; set; }

        public override string ToString()
        {
            return $"{Fio}, {Date}, {WorkExperience}";
        }
    }
}
