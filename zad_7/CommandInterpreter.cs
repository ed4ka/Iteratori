using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha7
{
    internal class CommandInterpreter
    {
        private Dictionary<string, Clinic> clinics;

        public CommandInterpreter()
        {
            clinics = new Dictionary<string, Clinic>();
        }

        public void ExecuteCommand(string[] commandArgs)
        {
            string command = commandArgs[0];

            switch (command)
            {
                case "Create":
                    string type = commandArgs[1];
                    if (type == "Pet")
                    {
                        string name = commandArgs[2];
                        int age = int.Parse(commandArgs[3]);
                        string petType = commandArgs[4];
                        Pet pet = new Pet(name, age, petType);
                        Console.WriteLine(CreatePet(pet));
                    }
                    else if (type == "Clinic")
                    {
                        string clinicName = commandArgs[2];
                        int roomsCount = int.Parse(commandArgs[3]);
                        Console.WriteLine(CreateClinic(clinicName, roomsCount));
                    }
                    break;
                case "Add":
                    string petName = commandArgs[1];
                    string clinicNameToAdd = commandArgs[2];
                    Console.WriteLine(AddPetToClinic(petName, clinicNameToAdd));
                    break;
                case "Release":
                    string clinicNameToRelease = commandArgs[1];
                    Console.WriteLine(ReleasePetFromClinic(clinicNameToRelease));
                    break;
                case "HasEmptyRooms":
                    string clinicNameToCheck = commandArgs[1];
                    Console.WriteLine(HasEmptyRooms(clinicNameToCheck));
                    break;
                case "Print":
                    string clinicNameToPrint = commandArgs[1];
                    if (commandArgs.Length == 2)
                    {
                        PrintClinic(clinicNameToPrint);
                    }
                    else
                    {
                        int roomNumber = int.Parse(commandArgs[2]);
                        PrintRoom(clinicNameToPrint, roomNumber);
                    }
                    break;
            }
        }

        private string CreatePet(Pet pet)
        {
            return clinics.Values.Any(c => c.Name == pet.Name) ?
                "Invalid operation. Pet with that name already exists." :
                "Pet created.";
        }

        private string CreateClinic(string name, int rooms)
        {
            try
            {
                clinics.Add(name, new Clinic(name, rooms));
                return "Clinic created.";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
        }

        private string AddPetToClinic(string petName, string clinicName)
        {
            if (!clinics.ContainsKey(clinicName))
            {
                return "Invalid operation. Clinic with that name doesn't exist.";
            }

            if (!clinics.Values.Any(c => c.Name == petName))
            {
                return "Invalid operation. Pet with that name doesn't exist.";
            }

            if (!clinics[clinicName].AddPet(clinics.Values.FirstOrDefault(c => c.Name == petName)))
            {
                return "Invalid operation. Clinic is full.";
            }

            return "Pet added.";
        }

        private string ReleasePetFromClinic(string clinicName)
        {
            if (!clinics.ContainsKey(clinicName))
            {
                return "Invalid operation. Clinic with that name doesn't exist.";
            }

            if (!clinics[clinicName].ReleasePet())
            {
                return "Invalid operation. Clinic is empty.";
            }

            return "Pet released.";
        }

        private string HasEmptyRooms(string clinicName)
        {
            if (!clinics.ContainsKey(clinicName))
            {
                return "Invalid operation. Clinic with that name doesn't exist.";
            }

            return clinics[clinicName].HasEmptyRooms() ? "True" : "False";
        }

        private void PrintClinic(string clinicName)
        {
            if (!clinics.ContainsKey(clinicName))
            {
                Console.WriteLine("Invalid operation. Clinic with that name doesn't exist.");
                return;
            }

            clinics[clinicName].Print();
        }

        private void PrintRoom(string clinicName, int roomNumber)
        {
            if (!clinics.ContainsKey(clinicName))
            {
                Console.WriteLine("Invalid operation. Clinic with that name doesn't exist.");
                return;
            }

            clinics[clinicName].Print(roomNumber);
        }
    }
}
