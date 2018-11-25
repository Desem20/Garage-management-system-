using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            B2,
        }

        private static readonly float sr_MotorCycleWheelMaxAirPressure = 30;
        private static readonly int sr_MotorCycleNumberOfWheels = 2;
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        public MotorCycle(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, eLicenseType i_LicenseType, int i_EngineCapacity, EnergySource i_EnergySource)
            : base(i_Model, i_LicenseNumber)
        {
            this.r_LicenseType = i_LicenseType;
            this.r_EngineVolume = i_EngineCapacity;
            this.m_EnergySource = i_EnergySource;
            this.m_NumberOfWheels = sr_MotorCycleNumberOfWheels;
            this.m_VehicleWheelMaxAirPressure = sr_MotorCycleWheelMaxAirPressure;
            this.AddWheels(i_WheelManufacturerName, i_WheelMaxAirPressure);
        }

        public eLicenseType LicenseType
        {
            get
            {
                return this.r_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return this.r_EngineVolume;
            }
        }
    }
}