using Autofac;
using HotellApp_Databasteknik_2.Utilities.Menu_Details;
using HotellApp_Databasteknik_2.Utilities.CRUD.Bookings;
using HotellApp_Databasteknik_2.Utilities.CRUD.Customers;
using HotellApp_Databasteknik_2.Utilities.CRUD.Rooms;
using HotellApp_Databasteknik_2.Utilities;
using HotellApp_Databasteknik_2.Data;
namespace HotellApp_Databasteknik_2
{
    public static class AutofacConfig
    {
        public static Autofac.IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Registrerar klasser
            builder.RegisterType<CalendarForBooking>().AsSelf();
            builder.RegisterType<Data_Initializer>().AsSelf();
            builder.RegisterType<Application>().AsSelf();
            builder.RegisterType<DisplayMenus>().AsSelf();
            builder.RegisterType<MenuControls>().AsSelf();

            // CRUD-tjänster
            builder.RegisterType<CreateCustomer>().AsSelf();
            builder.RegisterType<ReadCustomer>().AsSelf();
            builder.RegisterType<UpdateCustomer>().AsSelf();
            builder.RegisterType<DeleteCustomer>().AsSelf();

            builder.RegisterType<CreateRoom>().AsSelf();
            builder.RegisterType<ReadRoom>().AsSelf();
            builder.RegisterType<UpdateRoom>().AsSelf();
            builder.RegisterType<DeleteRoom>().AsSelf();

            builder.RegisterType<CreateBooking>().AsSelf();
            builder.RegisterType<ReadBooking>().AsSelf();
            builder.RegisterType<UpdateBooking>().AsSelf();
            builder.RegisterType<DeleteBooking>().AsSelf();

            // Returnera en Autofac-container
            return builder.Build();
        }
    }
}
