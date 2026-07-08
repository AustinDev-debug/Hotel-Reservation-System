using System;

namespace HotelSystem
{
    class Room
    {
        public int RoomNumber;
        public string Name;
        public int NumOfBeds;
        public int PricePerNight;
        public bool IsOccupied;
    

    public Room(int roomNumber, string name, int numberOfBeds, int pricePerNight, bool isOccupied)
        {
            RoomNumber = roomNumber;
            Name = name;
            NumOfBeds = numberOfBeds;
            PricePerNight = pricePerNight;
            IsOccupied = isOccupied;
        }
    } 
}
