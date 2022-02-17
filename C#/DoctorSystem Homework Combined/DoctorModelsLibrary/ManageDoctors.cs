using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorModelsLibrary
{
    public class ManageDoctors
    {
        Doctor[] doctors = new Doctor[5];
        int DoctorsCount = 0;

        public virtual void PrintAllDoctors()
        {
            
            foreach(var doctor in doctors)
            {
                if (doctor != null)
                {
                    Console.WriteLine(doctor);
                }
            }
        }
        public Doctor GetDoctorByIdFromConsole()
        {
            int DoctorId = TakeDoctorIdFromConsole();
            return GetDoctorById(DoctorId);
        }
        public virtual Doctor GetDoctorById(int DoctorId)
        {
            foreach (var doctor in doctors)
            {
                if (doctor != null && doctor.Id == DoctorId) return doctor;
            }
            Console.WriteLine("Can`t find doctor by this id.");
            return null;
        }
        public int TakeDoctorIdFromConsole()
        {
            int DoctorId;
            Console.WriteLine("Please,enter Doctor Id:");
            while (!Int32.TryParse(Console.ReadLine(),out DoctorId))
            {
                Console.WriteLine("Invalid entry for Doctor Id.Try again");
            }
            return DoctorId;
        }
        public Doctor TakeDoctorDataFromConsole()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("=========================Enter start=========================");
            doctor.Id = GenerateId();
            Console.WriteLine("Please enter Doctor Name:");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter Doctor Experience(format 5,2 for example):");
            double exp;
            while (!Double.TryParse(Console.ReadLine(), out exp))
            {
                Console.WriteLine("Invalid entry for experience.Try again");
            }
            doctor.Experience = exp;
            Console.WriteLine("Please enter Doctor Speciality:");
            doctor.Speciality = Console.ReadLine();
            Console.WriteLine("=========================Enter end=========================");
            return doctor;
        }
        protected virtual int GenerateId()
        {
            if (DoctorsCount == 0)
            {
                return 101;
            }
            return doctors[DoctorsCount-1].Id + 1;

        }
        public virtual void AddDoctors()
        {
            string choice = "yes";
            do
            {
                doctors[DoctorsCount] = TakeDoctorDataFromConsole();
                DoctorsCount++;
                Console.WriteLine("Do you want to add one more Doctor?(print no to exit)");
                choice = Console.ReadLine();
            } while (DoctorsCount < 5 && choice!="no" ); 
            
        }        
        public void UpdateDoctorExperience()
        {
            Doctor doctor = GetDoctorByIdFromConsole();
            if (doctor != null)
            {
                Console.WriteLine("Please enter new value for Doctor experience:");
                double exp;
                while (!Double.TryParse(Console.ReadLine(), out exp))
                {
                    Console.WriteLine("Invalid entry for experience.Try again");
                }
                doctor.Experience = exp;
                Console.WriteLine("Successfully updated!");
                                 
            }
        }
        public void UpdateDoctorSpeciality()
        {
            Doctor doctor = GetDoctorByIdFromConsole();
            if (doctor != null)
            {
                Console.WriteLine("Please enter new value for Doctor Speciality:");
                doctor.Speciality= Console.ReadLine();
                Console.WriteLine("Successfully updated!");
            }
        }
        public virtual void SortDoctorsByExperience()
        {
            Array.Sort(doctors);
            PrintAllDoctors();
        }
        public virtual void DeleteDoctor()
        {
            int DoctorId = TakeDoctorIdFromConsole();
            for (int i = 0; i < DoctorsCount; i++)
            {
                if (doctors[i]!= null && doctors[i].Id == DoctorId)
                {
                    doctors[i] = null;
                    for (int j = i; j < DoctorsCount-1; j++)
                    {
                        doctors[i] = doctors[i + 1];
                    }
                    DoctorsCount--;
                    Console.WriteLine("Successfully deleted!");
                    break;
                }
            }
        }

    }
}
