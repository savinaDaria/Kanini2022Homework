using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorModelsLibrary
{
    //Edit the code that you did on Day12 assignment so that it can take as much doctors ad the user gives
    //Note:
    //Use Generic collection
    public class ManageDoctorCollection:ManageDoctors
    {
        List<Doctor> doctors;
        public ManageDoctorCollection()
        {
            doctors = new List<Doctor>();
        }
        public override void AddDoctors()
        {
            string choice = "yes";
            do
            {
                doctors.Add(TakeDoctorDataFromConsole());
                Console.WriteLine("Do you want to add one more Doctor?(print no to exit)");
                choice = Console.ReadLine();
            } while (choice != "no");
        }
        public override void DeleteDoctor()
        {
            Doctor doctor = GetDoctorByIdFromConsole();
            if (doctor != null)
            {
                doctors.Remove(doctor);
                Console.WriteLine("Successfully deleted!");
            }
              
        }
        public override void SortDoctorsByExperience()
        {
            doctors.Sort();
            PrintAllDoctors();
        }
        protected override int GenerateId()
        {
            int id;
            if (doctors.Count == 0) return 101;
            id = doctors.Last<Doctor>().Id + 1;
            return id;
        }
        public override void PrintAllDoctors()
        {
            foreach (var doctor in doctors)
            {
                if (doctor != null)
                {
                    Console.WriteLine(doctor);
                }
            }
        }
        public override Doctor GetDoctorById(int DoctorId)
        {
            foreach (var doctor in doctors)
            {
                if (doctor != null && doctor.Id == DoctorId) return doctor;
            }
            Console.WriteLine("Can`t find doctor by this id.");
            return null;
        }
    }
}
