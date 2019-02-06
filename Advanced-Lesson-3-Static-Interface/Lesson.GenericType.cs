using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Lesson
    {  
        public static void RentInAutoHouseExample()
        {
            var autoHouse = new AutoHouse(new List<Car> { new Car() });

            var from = new Location();
            var to = new Location();

            if (autoHouse.IsAvailableFor(from, to))
            {
                var transport = autoHouse.RentTransport(8);
                transport.Move(34);
                //transport.FillUp(50);
                // Travelling... Travelling... Travelling...
                autoHouse.ReturnTransport(transport);
            }
        }

        public static void RentInPortExample()
        {
            var port = new Port(new List<Marine> { new Marine() });
            var from = new Location();
            var to = new Location();

            if (port.IsAvailableFor(from, to))
            {
                var transport = port.RentTransport(8);
                transport.Move(34);
                // Travelling... Travelling... Travelling...
                port.ReturnTransport(transport);
            }
        }

        public static void GenericRentInAutoHouseExample()
        {
            var autoHouse = new AutoHouseG(new List<Car> { new Car() });

            var from = new Location();
            var to = new Location();

            if (autoHouse.IsAvailableFor(from, to))
            {
                Car transport = autoHouse.RentTransport(8);
                transport.Move(34);
                transport.FillUp(45);
                // Travelling... Travelling... Travelling...
                autoHouse.ReturnTransport(transport);
            }
        }
    }

    public struct Location
    {
        float Lat { get; set; }
        float Long { get; set; }
    }

    interface IRentPoint
    {
        ITransport RentTransport(int duration);

        void ReturnTransport(ITransport transport);

        bool IsAvailableFor(Location from, Location to);
    }

    interface IGenericRentPoint<T> where T: ITransport
    {
        T RentTransport(int duration);

        void ReturnTransport(T transport);

        bool IsAvailableFor(Location from, Location to);
    }

    public class AutoHouse: IRentPoint
    {
        public AutoHouse(List<Car> items)
        {
            Items = items;
        }

        public List<Car> Items { get; private set; }

        public bool IsAvailableFor(Location from, Location to)
        {
            return false;
        }

        public ITransport RentTransport(int duration)
        {
            var transport = Items.FirstOrDefault();
            Items.Remove(transport);
            return transport;
        }

        public void ReturnTransport(ITransport transport)
        {
            var car = transport as Car;
            car.FillUp(50);
            Items.Add(car);
        }
    }

    public class Port : IRentPoint
    {
        public Port(List<Marine> items)
        {
            Items = items;
        }

        public List<Marine> Items { get; set; }

        public bool IsAvailableFor(Location from, Location to)
        {
            return true;
        }

        public ITransport RentTransport(int duration)
        {
            var transport = Items.FirstOrDefault();
            Items.Remove(transport);
            return transport;
        }

        public void ReturnTransport(ITransport transport)
        {
            Items.Add(transport as Marine);
        }
    }

    public class AutoHouseG : IGenericRentPoint<Car>
    {
        public AutoHouseG(List<Car> items)
        {
            Items = items;
        }

        public List<Car> Items { get; private set; }

        public bool IsAvailableFor(Location from, Location to)
        {
            return false;
        }

        public Car RentTransport(int duration)
        {
            var transport = Items.FirstOrDefault();
            Items.Remove(transport);
            return transport;
        }

        public void ReturnTransport(Car transport)
        {
            transport.FillUp(50);
            Items.Add(transport);
        }
    }

    public class PortG : IGenericRentPoint<Marine>
    {
        public PortG(List<Marine> items)
        {
            Items = items;
        }

        public List<Marine> Items { get; set; }

        public bool IsAvailableFor(Location from, Location to)
        {
            return true;
        }

        public Marine RentTransport(int duration)
        {
            var transport = Items.FirstOrDefault();
            Items.Remove(transport);
            return transport;
        }

        public void ReturnTransport(Marine transport)
        {
            Items.Add(transport);
        }
    }
}
