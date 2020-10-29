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


            //StationControl
            StationControl stationControl = new StationControl(door, chargerControlSimulator, display, readerSimulator, );

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.OnRfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
