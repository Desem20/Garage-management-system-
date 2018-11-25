using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eStatusVehicle
        {
            Repairing,
            Repaired,
            Paid,
        }

        public enum eTypesVehicles
        {
            RegularMotorCycle = 1,
            ElectricMotorCycle = 2,
            RegularCar = 3,
            ElectricCar = 4,
            Truck = 5,
        }

        private Dictionary<string, Vehicle> m_VehiclesOfGarage;

        public Garage()
        {
            this.m_VehiclesOfGarage = new Dictionary<string, Vehicle>();
        }

        public List<string> LicenseNumbersOfVehicles()
        {
            List<string> licenseNumbersOfVehicles = new List<string>(this.m_VehiclesOfGarage.Keys);
            return licenseNumbersOfVehicles;
        }

        public List<string> LicenseNumbersOfVehiclesByTheirStatus(eStatusVehicle i_StatusOfVehicle)
        {
            List<string> licenseNumbersOfVehiclesByTheirStatus = new List<string>();
            foreach (Vehicle vehicle in m_VehiclesOfGarage.Values)
            {
                if (vehicle.StatusOfVehicle == i_StatusOfVehicle)
                {
                    licenseNumbersOfVehiclesByTheirStatus.Add(vehicle.LicenseNumber);
                }
            }

            return licenseNumbersOfVehiclesByTheirStatus;
        }

        public bool VehicleExist(string i_LicenseNumber)
        {
            return this.m_VehiclesOfGarage.ContainsKey(i_LicenseNumber);
        }

        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            if (!VehicleExist(i_LicenseNumber))
            {
                throw new ArgumentException();
            }
            else
            {
                return this.m_VehiclesOfGarage[i_LicenseNumber];
            }
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            if (i_Vehicle == null)
            {
                throw new ArgumentException();
            }
            else
            {
                this.m_VehiclesOfGarage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
            }
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToInflate;
            bool isInTheGarage;
            isInTheGarage = this.m_VehiclesOfGarage.TryGetValue(i_LicenseNumber, out vehicleToInflate);

            if (!isInTheGarage)
            {
                throw new ArgumentException();
            }
            else
            {
                vehicleToInflate.InflateAllWheelsToMax();
            }
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eStatusVehicle i_NewStatus)
        {
            Vehicle vehicleToChangeStatus;
            bool isInTheGarage;
            isInTheGarage = this.m_VehiclesOfGarage.TryGetValue(i_LicenseNumber, out vehicleToChangeStatus);
            if (!isInTheGarage)
            {
                throw new ArgumentException();
            }
            else
            {
                vehicleToChangeStatus.StatusOfVehicle = i_NewStatus;
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_NumberOfHourrsToAdd)
        {
            Vehicle vehicleToAddHours;
            bool isInTheGarage = this.m_VehiclesOfGarage.TryGetValue(i_LicenseNumber, out vehicleToAddHours);
            if (!isInTheGarage)
            {
                throw new ArgumentException();
            }
            else
            {
                if (vehicleToAddHours.EnergySource is Battery)
                {
                    ((Battery)vehicleToAddHours.EnergySource).ChargeBattery(i_NumberOfHourrsToAdd);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void RefuelRegularVehicle(string i_LicenseNumber, float i_AmountOfFuelToAdd, GasTank.eTypeOfFuel i_TypeOfFuelToAdd)
        {
            Vehicle vehicleToAddFuel;
            bool isInTheGarage = this.m_VehiclesOfGarage.TryGetValue(i_LicenseNumber, out vehicleToAddFuel);
            if (!isInTheGarage)
            {
                throw new ArgumentException();
            }
            else
            {
                if (vehicleToAddFuel.EnergySource is GasTank)
                {
                    ((GasTank)vehicleToAddFuel.EnergySource).AddFuelToCar(i_TypeOfFuelToAdd, i_AmountOfFuelToAdd);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}