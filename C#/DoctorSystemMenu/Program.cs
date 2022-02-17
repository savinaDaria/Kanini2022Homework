using System;
using DoctorModelsLibrary;

namespace DoctorSystemMenu
{
    class Program
    {
        void DoctorSystemMenu()
        {

            int choice = 0;
            ManageDoctors manageDoctor = new ManageDoctorCollection();
            Console.WriteLine("Welcome to Doctor Management System Menu!\n" +
                                   "1) Add doctors\n" +
                                   "2) Delete doctor\n" +
                                   "3) Print all doctors\n" +
                                   "4) Update doctor experience\n" +
                                   "5) Update doctor speciality\n" +
                                   "6) Sort doctors by experience\n" +
                                   "7) Exit");
            do
            {
                Console.WriteLine("\nPlease,choose one option: ");
                Int32.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        manageDoctor.AddDoctors();
                        break;
                    case 2:
                        manageDoctor.DeleteDoctor();
                        break;
                    case 3:
                        manageDoctor.PrintAllDoctors();
                        break;
                    case 4:
                        manageDoctor.UpdateDoctorExperience();
                        break;
                    case 5:
                        manageDoctor.UpdateDoctorSpeciality();
                        break;
                    case 6:
                        manageDoctor.SortDoctorsByExperience();
                        break;
                    case 7:
                        Console.WriteLine("~~~~~~~~~~~~Menu Exit~~~~~~~~~~~~");
                        break;
                    default:
                        Console.WriteLine("Invalid option number. Try again");
                        break;
                }
            } while (choice != 7);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.DoctorSystemMenu();
        }
    }
}
