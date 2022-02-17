using System;

namespace DoctorModelsLibrary
{
//Create a CRUD operation for Doctor objects
//Doctor - Id, Name, Experience, Speciality
//5 doctors max
//Can edit Experienceand Speciality
//Note:
//Print doctor sorted by Experience
//Create Model class in library
//Manage the doctor in console app project
//Ensure the application does not break(avoid exceptions using error handling as much as possible)
    public class Doctor:IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Experience { get; set; }
        public string Speciality { get; set; }

        public int CompareTo(object obj)
        {
            Doctor d2 = (Doctor)obj;
            return this.Experience.CompareTo(d2.Experience);
        }

        public override string ToString()
        {
            return "\n==============Doctor Details==============\n" +
             "\nId: " + Id +
             "\nName: " + Name +
             "\nExperience: " + Experience +
             "\nSpeciality: " + Speciality + "\n";
        }

    }
}
