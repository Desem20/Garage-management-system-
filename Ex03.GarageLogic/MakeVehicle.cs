using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class MakeVehicle
    {
        private const int k_RegularCarVolumeGasTank = 45;
        private const int k_RegularMotorCycleVolumeGasTank = 6;
        private const int k_TrunkVolumeGasTank = 115;
        private const float k_ElectricCarMaxBattery = 3.2f;
        private const float k_ElectricMotorCycleMaxBattery = 1.8f;

        public static Vehicle MakeRegularCar(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, Car.eColor i_Color, Car.eNumOfDoors i_NumberOfDoors)
        {
            return new Car(i_Model, i_LicenseNumber, i_WheelManufacturerName, i_WheelMaxAirPressure, i_Color, i_NumberOfDoors, new GasTank(GasTank.eTypeOfFuel.Octan98, k_RegularCarVolumeGasTank));
        }

        public static Vehicle MakeElectricCar(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, Car.eColor i_Color, Car.eNumOfDoors i_NumberOfDoors)
        {
            return new Car(i_Model, i_LicenseNumber, i_WheelManufacturerName, i_WheelMaxAirPressure, i_Color, i_NumberOfDoors, new Battery(k_ElectricCarMaxBattery));
        }

        public static Vehicle MakeRegularMotorCycle(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            return new MotorCycle(i_Model, i_LicenseNumber, i_WheelManufacturerName, i_WheelMaxAirPressure, i_LicenseType, i_EngineVolume, new GasTank(GasTank.eTypeOfFuel.Octan96, k_RegularMotorCycleVolumeGasTank));
        }

        public static Vehicle MakeElectricMotorCycle(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, MotorCycle.eLicenseType i_LicenseType, int i_EngineVolume)
        {
            return new MotorCycle(i_Model, i_LicenseNumber, i_WheelManufacturerName, i_WheelMaxAirPressure, i_LicenseType, i_EngineVolume, new Battery(k_ElectricMotorCycleMaxBattery));
        }

        public static Vehicle MakeTruck(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, bool i_TrunkOpen, float i_CapacityTrunk)
        {
            return new Truck(i_Model, i_LicenseNumber, i_WheelManufacturerName, i_WheelMaxAirPressure, i_TrunkOpen, i_CapacityTrunk, new GasTank(GasTank.eTypeOfFuel.Soler, k_TrunkVolumeGasTank));
        }
    }
}