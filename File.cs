using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace HealthCareFileManagement
{
    internal class File
    {
        long id;
        string name;
        string surname;
        DateTime visitDate;
        string complaint;
        string physicalExamNotes;
        string prescribedMedication;
        public long Id { get { return id; } }
        public string Name { get { return name; } } 
        public string Surname { get { return surname; } }
        public DateTime VisitDate { get { return visitDate; } }   
        public string Complaint { get { return complaint; } set { complaint = value; } }
        public string PhysicalExamNotes { get { return physicalExamNotes; } set { physicalExamNotes = value; } }
        public string PrescribedMedication { get { return prescribedMedication; } set { prescribedMedication = value; } }

        public File(long id, string name, string surname, DateTime visitDate, string complaint, string physicalExamNotes, string prescribedMedication)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.visitDate = visitDate;
            this.complaint = complaint;
            this.physicalExamNotes = physicalExamNotes;
            this.prescribedMedication = prescribedMedication;
        }
    }
}
