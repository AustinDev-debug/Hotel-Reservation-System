using System;


namespace HotelSystem
{
    class Program
    {
        List<Room> rooms = new List<Room>();
        static void Main(string[] args)
        {
            bool RunProgram = true;
            Program program = new Program();
            while (RunProgram)
            {
                Console.WriteLine("Welcome to Austin's Hotel Reservation System");
                Console.WriteLine("1. Add Room\n" +
                    "2. Reserve Room\n" +
                    "3. Check Out Guest\n" +
                    "4. Search Room\n" +
                    "5. List All Rooms\n" +
                    "6. Exit");
                Console.Write("Input: ");
                int input = program.NumberValidation(Console.ReadLine()!);
                // Switch statement for user input
                switch (input)
                {
                    case 1:
                        program.AddRoom();
                        break;
                    case 2:
                        program.ReserveRoom();
                        break;
                    case 3:
                        program.CheckOut();
                        break;
                    case 4:
                        program.SearchRooms();
                        break;
                    case 5:
                        program.ListRooms();
                        break;
                    case 6:
                        RunProgram = false;
                        break;

                }
            }
        }

        #region Input validation
        string InputValidation(string input)
        {
            while(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Your input can not be empty");
                input = Console.ReadLine()!;
            }
            return input;
        }
        #endregion

        #region Number Validation
        int NumberValidation(string input)
        {
            int number = 0;
            while(true)
            {
                while(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input can not be empty");
                    input = Console.ReadLine()!;
                }
                if (int.TryParse(input, out number))
                {
                    return number;
                }
                Console.WriteLine("Enter a valid number");
                input = Console.ReadLine()!;
            }
        }
        #endregion

        #region Add Room
        void AddRoom()
        {
            Console.WriteLine("How many rooms do you want to add?");
            int NumOfRooms = NumberValidation(Console.ReadLine()!);
            for (int i = 0; i < NumOfRooms; i++)
            {
                Console.WriteLine("Enter the room number");
                int number = NumberValidation(Console.ReadLine()!);
                Console.WriteLine("Enter room name");
                string RoomName = InputValidation(Console.ReadLine()!);
                Console.WriteLine("Enter number of beds the room has");
                int Beds = NumberValidation(Console.ReadLine()!);
                Console.WriteLine("Enter the price of the room per night");
                int Price = NumberValidation(Console.ReadLine()!);
                bool CheckedOut = false;
                Room room = new Room(number, RoomName, Beds, Price, CheckedOut);
                rooms.Add(room);
            }
        }
        #endregion

        #region List Rooms
        void ListRooms()
        {
            // list all rooms 
            foreach (Room room in rooms)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Room Name: {room.Name}");
                Console.WriteLine($"Room Number: {room.RoomNumber}");
                Console.WriteLine($"Number of beds: {room.NumOfBeds}");
                Console.WriteLine($"Price Per Night: {room.PricePerNight}");
                Console.WriteLine($"Currently Occupied: {room.IsOccupied}");
                Console.WriteLine("----------------------------------------");
            }
        }
        #endregion

        #region Reserve Room
        void ReserveRoom()
        {
            Console.WriteLine("Enter the number of the room you wish to reserve");
            int RoomNumber = NumberValidation(Console.ReadLine()!);
            bool RoomFound = false;
            // cycle through rooms 
            foreach (Room room in rooms)
            {
                if (room.RoomNumber == RoomNumber)
                {
                    if (room.IsOccupied)
                    {
                        RoomFound = true;
                        Console.WriteLine("Room is currently occupied, can not reserve");
                        break;
                    }
                    else
                    {
                        RoomFound = true;
                        room.IsOccupied = true;
                        Console.WriteLine("Room has been reserved");
                        break;
                    }
                   
                }
            }
            if (!RoomFound)
            {
                Console.WriteLine("Room not found, try again");
            }
        }
        #endregion

        #region Check Out
        void CheckOut()
        {
            Console.WriteLine("Enter the number of the room that is checking out");
            int RoomNumber = NumberValidation(Console.ReadLine()!);
            bool RoomFound = false;
            // cycle through rooms
            foreach (Room room in rooms)
            {
                if (room.RoomNumber == RoomNumber)
                {
                    if (!room.IsOccupied)
                    {
                        RoomFound = true;
                        Console.WriteLine("That room is not currently occupied");
                    }
                    else
                    {
                        room.IsOccupied = false;
                        RoomFound = true;
                        Console.WriteLine("Room has been vacated");
                    }
                }
            }
            if (!RoomFound)
            {
                Console.WriteLine("Room not found, try again");
            }
        }
        #endregion

        #region Search Rooms
        void SearchRooms()
        {
            Console.WriteLine("Enter the number of the room you are looking for");
            int RoomNumber = NumberValidation(Console.ReadLine()!);
            bool RoomFound = false;
            // cycle through rooms
            foreach (Room room in rooms)
            {
                if (room.RoomNumber == RoomNumber)
                {
                    RoomFound = true;
                    Console.WriteLine($"Room Name: {room.Name}");
                    Console.WriteLine($"Room Number: {room.RoomNumber}");
                    Console.WriteLine($"Room Occupied: {room.IsOccupied}");
                    Console.WriteLine($"Price Per Night: {room.PricePerNight}");
                    Console.WriteLine($"Number Of Beds: {room.NumOfBeds}");
                }
            }
            if (!RoomFound )
            {
                Console.WriteLine("Room not found, try again");
            }
        }
        #endregion
    }






}