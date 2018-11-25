using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly float sr_TruckWheelMaxAirPressure = 28;
        private static readonly int sr_TruckNumberOfWheels = 4;
        private readonly float r_CapacityTrunk;
        private bool m_TrunkOpen;// $G$ CSS-000 (-5) The variable name is not meaningful and understandable.

        public Truck(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, bool i_TrunkOpen, float i_CapacityTrunk, EnergySource i_EnergySource)
            : base(i_Model, i_LicenseNumber)
        {
            this.m_TrunkOpen = i_TrunkOpen;
            this.r_CapacityTrunk = i_CapacityTrunk;
            this.m_EnergySource = i_EnergySource;
            this.m_NumberOfWheels = sr_TruckNumberOfWheels;
            this.m_VehicleWheelMaxAirPressure = sr_TruckWheelMaxAirPressure;
            this.AddWheels(i_WheelManufacturerName, i_WheelMaxAirPressure);
        }

        public bool TrunkOpen
        {
            get
            {
                return this.m_TrunkOpen;
            }
        }

        public float CapacityTrunk
        {
            get
            {
                return this.r_CapacityTrunk;
            }
        }
    }
}