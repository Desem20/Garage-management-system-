using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Grey,
            Blue,
            White,
            Black,
        }

        public enum eNumOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        private static readonly float sr_CarWheelMaxAirPressure = 32;
        private static readonly int sr_CarNumberOfWheels = 4;
        private readonly eColor r_Color;
        private readonly eNumOfDoors r_NumberOfDoors;

        public Car(string i_Model, string i_LicenseNumber, string i_WheelManufacturerName, float i_WheelMaxAirPressure, eColor i_Color, eNumOfDoors i_NumberOfDoors, EnergySource i_DrivingForce)
            : base(i_Model, i_LicenseNumber)
        {
            this.r_Color = i_Color;
            this.r_NumberOfDoors = i_NumberOfDoors;
            this.m_EnergySource = i_DrivingForce;
            this.m_NumberOfWheels = sr_CarNumberOfWheels;
            this.m_VehicleWheelMaxAirPressure = sr_CarWheelMaxAirPressure;
            this.AddWheels(i_WheelManufacturerName, i_WheelMaxAirPressure);
        }

        public eColor Color
        {
            get
            {
                return this.r_Color;
            }
        }

        public eNumOfDoors NumberOfDoors
        {
            get
            {
                return this.r_NumberOfDoors;
            }
        }
    }
}