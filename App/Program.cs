using System;


namespace KernFunkLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assemble your system here from all the classes
            //Display
            Output output = new Output();
            DisplaySimulator display = new DisplaySimulator(output);

            //ChargeControl
            UsbChargerSimulator usbChargerSimulator = new UsbChargerSimulator();
            ChargerControlSimulator chargerControlSimulator = new ChargerControlSimulator(display, usbChargerSimulator);

            //Door
            DoorSimulator door = new DoorSimulator();

            //RfidReader
            RfidReaderSimulator readerSimulator = new RfidReaderSimulator();

            //Writer
            WriterSimulator writer = new WriterSimulator("log.txt");

            //StationControl
            StationControl stationControl = new StationControl(door, chargerControlSimulator, display, readerSimulator, writer);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E - End, O - Open door, C - Close door, R - Indtast rfid, P - Tilslut Telefon, D - Frakobel Telefon");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpened();
                        break;

                    case 'C':
                        door.OnDoorClosed();
                        break;
                    case 'P':
                        usbChargerSimulator.SimulateConnected(true);
                        break;
                    case 'D':
                        usbChargerSimulator.SimulateConnected(false);
                        break;
                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        readerSimulator.SetId(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
