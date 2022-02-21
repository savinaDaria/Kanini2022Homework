using System;
using System.Collections.Generic;
using PersonModelsLibrary;
namespace ManagePersonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagePerson managePerson = new ManagePerson();
            managePerson.CreatePerson();
            managePerson.CreatePeople();
        }
    }
}
