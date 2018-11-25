using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserIntreface
    {
        private const string k_UserDisplayText =
@"Please choose from the following options (1-8):
1. Add a new vehicle to garage.
2. Display vehicles license numbers in the garage
   with option to filtered by vehicle's status.
3. Change a vehicle's status.
4. Inflate a vehicle's wheels to maximum.
5. Add fuel to regular vehicle.
6. Charge an electric vehicle.
7. Display full details of a vehicle.
8. Quit.";

        public enum eUserMenuOption
        {
            AddVehicle = 1,
            DisplayLicenseNumbers = 2,
            ChangeVehicleStatus = 3,
            InflateVehicleWheels = 4,
            AddFuelToRegularVehicle = 5,
            ChargeElectricVehicle = 6,
            DisplayVehicleDetails = 7,
            QuitProgram = 8
        }

        public void Run()
        {
            bool exitProgram = false;
            Garage garage = new Garage();
            while (!exitProgram)
            {
                try
                {
                    Console.WriteLine(k_UserDisplayText);
                    eUserMenuOption userSelection = getUserMenuChoice(Console.ReadLine());
                    Console.Clear();
                    if (userSelection == eUserMenuOption.QuitProgram)
                    {
                        break;
                    }

                    submitUserSelection(userSelection, garage);
                }
                catch (FormatException)
                {
                    Console.WriteLine("There is an error in the input");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("There is a logical error");
                }
                catch (ValueOutOfRangeExecption exeption)
                {
                    Console.WriteLine(string.Format("There is an error the value need to be in the range of:{0}-{1}.", exeption.MinValue, exeption.MaxValue));
                }
                catch (Exception)
                {
                    Console.WriteLine("unknown problem, exit from program......");
                    exitProgram = true;
                }

                Console.WriteLine("Press any key to back to menu.");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Bye Bye");
            Console.ReadLine();
        }

        private eUserMenuOption getUserMenuChoice(string i_UserChoise)
        {
            int userChoice = int.Parse(i_UserChoise);
            eUserMenuOption userSelection;
            if (Enum.IsDefined(typeof(eUserMenuOption), userChoice))
            {
                userSelection = (eUserMenuOption)userChoice;
            }
            else
            {
                throw new FormatException();
            }

            return userSelection;
        }

        private void submitUserSelection(eUserMenuOption i_MenuOption, Garage i_Garage)
        {
            if (i_MenuOption == eUserMenuOption.AddVehicle)
            {
                addVehicle(i_Garage);
            }
            else if (i_MenuOption == eUserMenuOption.DisplayLicenseNumbers)
            {
                displayLicenseNumbers(i_Garage);
            }
            else if (i_MenuOption == eUserMenuOption.ChangeVehicleStatus)
            {
                changeVehicleStatus(i_Garage);
            }
            else if (i_MenuOption == eUserMenuOption.InflateVehicleWheels)
            {
                inflateAllVehiclesWheelsToMax(i_Garage);
            }
            else if (i_MenuOption == eUserMenuOption.AddFuelToRegularVehicle)
            {
                refuelRegularVehicle(i_Garage);
            }
            else if (i_MenuOption == eUserMenuOption.ChargeElectricVehicle)
            {
                chargeElectricVehicle(i_Garage);
            }
            else if (i_MenuOption == eUserMenuOption.DisplayVehicleDetails)
            {
                displayVehicleDetails(i_Garage);
            }
        }

        private void refuelRegularVehicle(Garage i_Garage)
        {
            Console.WriteLine("Please enter number of license to refual vehicle. ");
            string numberOfLicense = getNumberValidInput();
            Console.WriteLine(@"Please enter amount of fuel to add.
please enter type of fuel to add (Soler,Ocatan95,Octan96,Octan98)");
            float amountOfFuelToAdd = float.Parse(Console.ReadLine());
            GasTank.eTypeOfFuel typeOfFuelToAdd = wantedTypeOfFuel(Console.ReadLine());
            i_Garage.RefuelRegularVehicle(numberOfLicense, amountOfFuelToAdd, typeOfFuelToAdd);
        }

        private GasTank.eTypeOfFuel wantedTypeOfFuel(string i_TypeOfFuelToAdd)
        {
            return (GasTank.eTypeOfFuel)Enum.Parse(typeof(GasTank.eTypeOfFuel), i_TypeOfFuelToAdd);
        }

        private void displayVehicleDetails(Garage i_Garage)
        {
            Console.WriteLine("Enter the vehicle licenseNumber");
            string licenseNumber = getNumberValidInput();
            Vehicle requestedVehicle = i_Garage.GetVehicle(licenseNumber);
            string requestedMessage = string.Format(
@"LicenseNumber is: {0}
Model is: {1} 
Owner of The vehicle is: {2}
Status of the vehicle is: {3}
Wheel manufacturer name is: {4}
Wheel current air pressure is: {5}
Wheel maximum air pressure is: {6}
Number of Wheels in the vehicle are: {7}",
            licenseNumber,
            requestedVehicle.Model,
            requestedVehicle.OwnerOfTheVehicle,
            requestedVehicle.StatusOfVehicle,
            requestedVehicle.WheelOfVehicle.ManufacturerName,
            requestedVehicle.WheelOfVehicle.CurrentAirPressure,
            requestedVehicle.WheelOfVehicle.MaxAirPressure,
            requestedVehicle.NumberOfWheels);

            addSpecificInformation(ref requestedMessage, requestedVehicle);
            addEnergySourceInformation(ref requestedMessage, requestedVehicle);
            Console.WriteLine(requestedMessage);
        }

        private void addEnergySourceInformation(ref string i_RequestedMessage, Vehicle i_RequestedVehicle)
        {
            string tempRequestedMessage;
            if (i_RequestedVehicle.EnergySource is GasTank)
            {
                GasTank gasTank = (GasTank)i_RequestedVehicle.EnergySource;
                tempRequestedMessage = string.Format(
@"{0}
Current state of fuel is :{1}
Energy left in percent :{2}%
The type of fuel is: {3}",
                i_RequestedMessage,
                gasTank.CurrentAmountOfForce,
                gasTank.RemainingEnergyPercent,
                gasTank.TypeOfFuel);
            }
            else if (i_RequestedVehicle.EnergySource is Battery)
            {
                Battery battery = (Battery)i_RequestedVehicle.EnergySource;
                tempRequestedMessage = string.Format(
@"{0}
Remaining time for battery : {1} hours
Energy left in percent: {2}%",
                i_RequestedMessage,
                battery.CurrentAmountOfForce,
                battery.RemainingEnergyPercent);
            }
            else
            {
                throw new ArgumentException();
            }

            i_RequestedMessage = tempRequestedMessage;
        }

        private void addSpecificInformation(ref string i_RequestedMessage, Vehicle i_RequestedVehicle)
        {
            string tempRequestedMessage;
            if (i_RequestedVehicle is Car)
            {
                Car car = (Car)i_RequestedVehicle;
                tempRequestedMessage = string.Format(
@"{0}
The color of the car is: {1}
Numbers of doors are: {2}",
                i_RequestedMessage,
                car.Color,
                car.NumberOfDoors);
            }
            else if (i_RequestedVehicle is MotorCycle)
            {
                MotorCycle motorCycle = (MotorCycle)i_RequestedVehicle;
                tempRequestedMessage = string.Format(
@"{0}
The license type of the motorCycle is: {1}
The engine volume is: {2}",
                i_RequestedMessage,
                motorCycle.LicenseType,
                motorCycle.EngineVolume);
            }
            else if (i_RequestedVehicle is Truck)
            {
                Truck truck = (Truck)i_RequestedVehicle;
                tempRequestedMessage = string.Format(
@"{0}
The trunk is open: {1}
The capacity trunk is:{2}",
                i_RequestedMessage,
                truck.TrunkOpen,
                truck.CapacityTrunk);
            }
            else
            {
                throw new ArgumentException();
            }

            i_RequestedMessage = tempRequestedMessage;
        }

        private void chargeElectricVehicle(Garage i_Garage)
        {
            Console.WriteLine("please enter number of license to charge");
            string numberOfLicense = getNumberValidInput();
            Console.WriteLine("please enter number of hours to add battery");
            float numberOfHoursToAdd = float.Parse(Console.ReadLine());
            i_Garage.ChargeElectricVehicle(numberOfLicense, numberOfHoursToAdd);
        }

        private void inflateAllVehiclesWheelsToMax(Garage i_Garage)
        {
            Console.WriteLine("Please enter number of license");
            string numberOfLicense = getNumberValidInput();
            i_Garage.InflateVehicleWheelsToMax(numberOfLicense);
        }

        private void displayLicenseNumbers(Garage i_Garage)
        {
            Console.WriteLine(
@"Choose your preference for showing vehicles license numbers in the garage
1.All license numbers 
2.Filtered by their status in the garage");

            List<string> licenseNumbers = userDisplayLicenseNumbersChoice(i_Garage);
            foreach (string vehicle in licenseNumbers)
            {
                Console.WriteLine(vehicle);
            }
        }

        private List<string> userDisplayLicenseNumbersChoice(Garage i_Garage)
        {
            List<string> licenseNumbers;
            string userChose = getNumberValidInput();
            if (userChose.Equals("1"))
            {
                licenseNumbers = i_Garage.LicenseNumbersOfVehicles();
            }
            else if (userChose.Equals("2"))
            {
                Console.WriteLine("Enter the status of vehicles(Repairing, Repaired, Paid)");
                string userStatusChoise = Console.ReadLine();
                Garage.eStatusVehicle statusOfVehicle = wantedNewStatus(userStatusChoise);
                licenseNumbers = i_Garage.LicenseNumbersOfVehiclesByTheirStatus(statusOfVehicle);
            }
            else
            {
                throw new ArgumentException();
            }

            return licenseNumbers;
        }

        private void changeVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine(
@"Please enter
1.Vehicle license number
2.Wanted status of vehicle (Repairing,Repaired,Paid)");
            string numberOfLicense = getNumberValidInput();
            Garage.eStatusVehicle newStatusOfVehicle = wantedNewStatus(Console.ReadLine());
            i_Garage.ChangeVehicleStatus(numberOfLicense, newStatusOfVehicle);
        }

        private Garage.eStatusVehicle wantedNewStatus(string i_NewStatusOfVehicle)
        {
            return (Garage.eStatusVehicle)Enum.Parse(typeof(Garage.eStatusVehicle), i_NewStatusOfVehicle);
        }

        private void addVehicle(Garage i_Garage)
        {
            Console.WriteLine("Enter The license number of The vehicle you want to add to the garage");
            string licenseNumber = getNumberValidInput();
            if (!i_Garage.VehicleExist(licenseNumber))
            {
                displayVehicleTypes();
                Garage.eTypesVehicles userVehicleChoise = getUserVehicleChose(Console.ReadLine());
                Vehicle vehicleToAdd = makeVehicle(userVehicleChoise, licenseNumber);
                addVehicleToGarage(vehicleToAdd, i_Garage);
            }
            else
            {
                Console.WriteLine("The vehicle exist in the garage");
                i_Garage.GetVehicle(licenseNumber).StatusOfVehicle = Garage.eStatusVehicle.Repairing;
            }
        }

        private Garage.eTypesVehicles getUserVehicleChose(string i_UserChoise)
        {
            int userChoise = int.Parse(i_UserChoise);
            Garage.eTypesVehicles userSelection;
            if (Enum.IsDefined(typeof(Garage.eTypesVehicles), userChoise))
            {
                userSelection = (Garage.eTypesVehicles)userChoise;
            }
            else
            {
                throw new FormatException();
            }

            return userSelection;
        }

        private void addVehicleToGarage(Vehicle i_VehicleToAdd, Garage i_Garage)
        {
            askFromUserVehiclesCurrentInformation();
            i_VehicleToAdd.OwnerOfTheVehicle = Console.ReadLine();
            i_VehicleToAdd.NumberPhoneOfOwner = getNumberValidInput();
            i_VehicleToAdd.CurrentWheelsPressure(float.Parse(Console.ReadLine()));
            i_VehicleToAdd.EnergySource.CurrentAmountOfForce = float.Parse(Console.ReadLine());
            i_Garage.AddVehicleToGarage(i_VehicleToAdd);
        }

        private Vehicle makeVehicle(Garage.eTypesVehicles i_VehicleToAdd, string i_LicenseNumber)
        {
            askFromUserVehiclesBasicInformation();
            string model = Console.ReadLine();
            string manufacturerName = Console.ReadLine();
            float maxAirPressure = float.Parse(Console.ReadLine());
            Vehicle addedVehicle = null;

            if (i_VehicleToAdd == Garage.eTypesVehicles.RegularMotorCycle)
            {
                addedVehicle = addRegularMotorCycle(i_LicenseNumber, model, manufacturerName, maxAirPressure);
            }
            else if (i_VehicleToAdd == Garage.eTypesVehicles.ElectricMotorCycle)
            {
                addedVehicle = addElectricMotorCycle(i_LicenseNumber, model, manufacturerName, maxAirPressure);
            }
            else if (i_VehicleToAdd == Garage.eTypesVehicles.RegularCar)
            {
                addedVehicle = addRegularCar(i_LicenseNumber, model, manufacturerName, maxAirPressure);
            }
            else if (i_VehicleToAdd == Garage.eTypesVehicles.ElectricCar)
            {
                addedVehicle = addElectricCar(i_LicenseNumber, model, manufacturerName, maxAirPressure);
            }
            else if (i_VehicleToAdd == Garage.eTypesVehicles.Truck)
            {
                addedVehicle = addTruck(i_LicenseNumber, model, manufacturerName, maxAirPressure);
            }

            return addedVehicle;
        }

        private void displayVehicleTypes()
        {
            string vehicleOptions =
@"Please choose a vehicle from the following vehicles (1-5):
1. Regular motorcycle
2. Electric motorcycle
3. Regular car
4. Electric car
5. Truck";
            Console.WriteLine(vehicleOptions);
        }

        private void askFromUserVehiclesBasicInformation()
        {
            string vehicleData =
@"Please enter the following information: 
1. Model of the vehicle
2. Manufacturer name of the wheels;
3. Maximum air pressure by Manufacturer wheels";
            Console.WriteLine(vehicleData);
        }

        private void askFromUserVehiclesCurrentInformation()
        {
            string vehicleData =
@"Please enter the following information: 
1. Owner Of the vehicle
2. Number phone of owner
3. Current Air Pressure of wheels
4. Current amount of energy";

            Console.WriteLine(vehicleData);
        }

        private Vehicle addRegularMotorCycle(string i_LicenseNumber, string i_Model, string i_ManufacturerName, float i_MaxAirPressure)
        {
            string regularMotorCycleData =
@"Please enter the following additional information: 
1. LicenseType (A,A1,B1,B2)
2. Engine volume";
            Console.WriteLine(regularMotorCycleData);
            MotorCycle.eLicenseType licenseType = (MotorCycle.eLicenseType)Enum.Parse(typeof(MotorCycle.eLicenseType), Console.ReadLine());
            int engineVolume = int.Parse(Console.ReadLine());
            return MakeVehicle.MakeRegularMotorCycle(i_Model, i_LicenseNumber, i_ManufacturerName, i_MaxAirPressure, licenseType, engineVolume);
        }

        private Vehicle addElectricMotorCycle(string i_LicenseNumber, string i_Model, string i_ManufacturerName, float i_MaxAirPressure)
        {
            string electricMotorCycleData =
@"Please enter the following additional information: 
1. LicenseType (A,A1,B1,B2)
2. Engine volume";
            Console.WriteLine(electricMotorCycleData);
            MotorCycle.eLicenseType licenseType = (MotorCycle.eLicenseType)Enum.Parse(typeof(MotorCycle.eLicenseType), Console.ReadLine());
            int engineVolume = int.Parse(Console.ReadLine());
            return MakeVehicle.MakeElectricMotorCycle(i_Model, i_LicenseNumber, i_ManufacturerName, i_MaxAirPressure, licenseType, engineVolume);
        }

        private Vehicle addRegularCar(string i_LicenseNumber, string i_Model, string i_ManufacturerName, float i_MaxAirPressure)
        {
            string regularCarData =
@"Please enter the following additional information: 
1. Car color (Grey,Blue,White,Black)
2. numberOfDoors(Two,Three,Four,Five)";
            Console.WriteLine(regularCarData);
            Car.eColor color = (Car.eColor)Enum.Parse(typeof(Car.eColor), Console.ReadLine());
            Car.eNumOfDoors numberOfDoors = (Car.eNumOfDoors)Enum.Parse(typeof(Car.eNumOfDoors), Console.ReadLine());
            return MakeVehicle.MakeRegularCar(i_Model, i_LicenseNumber, i_ManufacturerName, i_MaxAirPressure, color, numberOfDoors);
        }

        private Vehicle addElectricCar(string i_LicenseNumber, string i_Model, string i_ManufacturerName, float i_MaxAirPressure)
        {
            string electricCarData =
@"Please enter the following additional information: 
1. Car color (Grey,Blue,White,Black)
2. numberOfDoors(Two,Three,Four,Five)";
            Console.WriteLine(electricCarData);
            Car.eColor color = (Car.eColor)Enum.Parse(typeof(Car.eColor), Console.ReadLine());
            Car.eNumOfDoors numberOfDoors = (Car.eNumOfDoors)Enum.Parse(typeof(Car.eNumOfDoors), Console.ReadLine());
            return MakeVehicle.MakeElectricCar(i_Model, i_LicenseNumber, i_ManufacturerName, i_MaxAirPressure, color, numberOfDoors);
        }

        private Vehicle addTruck(string i_LicenseNumber, string i_Model, string i_ManufacturerName, float i_MaxAirPressure)
        {
            string truckData =
@"Please enter the following additional information: 
1. Trunk is open (True,False)
2. Capacity of the trunk";
            Console.WriteLine(truckData);
            bool i_TrunkOpen = bool.Parse(Console.ReadLine());
            float i_CapacityTrunk = float.Parse(Console.ReadLine());
            return MakeVehicle.MakeTruck(i_Model, i_LicenseNumber, i_ManufacturerName, i_MaxAirPressure, i_TrunkOpen, i_CapacityTrunk);
        }

        private string getNumberValidInput()
        {
            string numberToReturn = Console.ReadLine();

            try
            {
                int number = int.Parse(numberToReturn);
            }
            catch (FormatException)
            {
                Console.WriteLine("Current input is not valid, please try again");
                getNumberValidInput();
            }

            return numberToReturn;
        }
    }
}