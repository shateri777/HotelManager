using HotellApp_Databasteknik_2.Utilities.CRUD.Bookings;
using HotellApp_Databasteknik_2.Utilities.CRUD.Customers;
using HotellApp_Databasteknik_2.Utilities.CRUD.Rooms;

namespace HotellApp_Databasteknik_2.Utilities.Menu_Details
{
    public class MenuControls
    {
        private readonly DisplayMenus _displayMenus;
        private readonly CreateCustomer _createCustomer;
        private readonly ReadCustomer _readCustomer;
        private readonly UpdateCustomer _updateCustomer;
        private readonly DeleteCustomer _deleteCustomer;
        private readonly CreateRoom _createRoom;
        private readonly ReadRoom _readRoom;
        private readonly UpdateRoom _updateRoom;
        private readonly DeleteRoom _deleteRoom;
        private readonly CreateBooking _createBooking;
        private readonly ReadBooking _readBooking;
        private readonly UpdateBooking _updateBooking;
        private readonly DeleteBooking _deleteBooking;

        public MenuControls(
            DisplayMenus displayMenus,
            CreateCustomer createCustomer,
            ReadCustomer readCustomer,
            UpdateCustomer updateCustomer,
            DeleteCustomer deleteCustomer,
            CreateRoom createRoom,
            ReadRoom readRoom,
            UpdateRoom updateRoom,
            DeleteRoom deleteRoom,
            CreateBooking createBooking,
            ReadBooking readBooking,
            UpdateBooking updateBooking,
            DeleteBooking deleteBooking)
        {
            _displayMenus = displayMenus;
            _createCustomer = createCustomer;
            _readCustomer = readCustomer;
            _updateCustomer = updateCustomer;
            _deleteCustomer = deleteCustomer;
            _createRoom = createRoom;
            _readRoom = readRoom;
            _updateRoom = updateRoom;
            _deleteRoom = deleteRoom;
            _createBooking = createBooking;
            _readBooking = readBooking;
            _updateBooking = updateBooking;
            _deleteBooking = deleteBooking;
        }

        public void MainMenu(byte userInputMainMenu)
        {
            switch (userInputMainMenu)
            {
                case 1:
                    _displayMenus.CustomerMenu();
                    byte userInputCustomerMenu = Convert.ToByte(Console.ReadLine());
                    CustomerMenu(userInputCustomerMenu);
                    break;
                case 2:
                    _displayMenus.RoomMenu();
                    byte userInputRoomMenu = Convert.ToByte(Console.ReadLine());
                    RoomMenu(userInputRoomMenu);
                    break;
                case 3:
                    _displayMenus.BookingMenu();
                    byte userInputBookingMenu = Convert.ToByte(Console.ReadLine());
                    BookingMenu(userInputBookingMenu);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }

        public void CustomerMenu(byte userInputCustomerMenu)
        {
            switch (userInputCustomerMenu)
            {
                case 1:
                    _createCustomer.Create();
                    break;
                case 2:
                    _readCustomer.Read();
                    break;
                case 3:
                    _updateCustomer.Update();
                    break;
                case 4:
                    _deleteCustomer.Delete();
                    break;
                case 0:
                    MainMenu(0);
                    break;
            }
        }

        public void RoomMenu(byte userInputRoomMenu)
        {
            switch (userInputRoomMenu)
            {
                case 1:
                    _createRoom.Create();
                    break;
                case 2:
                    _readRoom.Read();
                    break;
                case 3:
                    _updateRoom.Update();
                    break;
                case 4:
                    _deleteRoom.Delete();
                    break;
                case 0:
                    MainMenu(0);
                    break;
            }
        }

        public void BookingMenu(byte userInputBookingMenu)
        {
            switch (userInputBookingMenu)
            {
                case 1:
                    _createBooking.Create();
                    break;
                case 2:
                    _readBooking.Read();
                    break;
                case 3:
                    _updateBooking.Update();
                    break;
                case 4:
                    _deleteBooking.Delete();
                    break;
                case 0:
                    MainMenu(0);
                    break;
            }
        }
    }
}
