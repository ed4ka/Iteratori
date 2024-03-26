using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha7
{
    internal class Clinic
    {
        private Pet[] rooms;

        public string Name { get; private set; }

        public Clinic(string name, int roomsCount)
        {
            if (roomsCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid operation. Number of rooms must be odd.");
            }

            Name = name;
            rooms = new Pet[roomsCount];
        }

        public bool AddPet(Pet pet)
        {
            int centralRoomIndex = rooms.Length / 2;

            for (int i = 0; i < rooms.Length; i++)
            {
                int index = (centralRoomIndex + i) % rooms.Length;
                if (rooms[index] == null)
                {
                    rooms[index] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool ReleasePet()
        {
            int centralRoomIndex = rooms.Length / 2;

            for (int i = centralRoomIndex; i < rooms.Length; i++)
            {
                if (rooms[i] != null)
                {
                    rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < centralRoomIndex; i++)
            {
                if (rooms[i] != null)
                {
                    rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return rooms.Any(room => room == null);
        }

        public void Print()
        {
            foreach (var room in rooms)
            {
                Console.WriteLine(room != null ? $"{room.Name} {room.Age} {room.Type}" : "Room empty");
            }
        }

        public void Print(int roomNumber)
        {
            roomNumber--;

            if (roomNumber < 0 || roomNumber >= rooms.Length)
            {
                throw new ArgumentException("Invalid room number.");
            }

            Console.WriteLine(rooms[roomNumber] != null ? $"{rooms[roomNumber].Name} {rooms[roomNumber].Age} {rooms[roomNumber].Type}" : "Room empty");
        }
    }
}
