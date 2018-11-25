using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LicenseNumber;
        protected string m_OwnerOfTheVehicle;
        protected string m_NumberPhoneOfOwner;
        protected Garage.eStatusVehicle m_StatusOfVehicle;
        protected float m_PercentageOfEnergy;
        protected List<Wheel> m_WheelsOfVehicle;
        protected EnergySource m_EnergySource;
        protected int m_NumberOfWheels;
        protected float m_VehicleWheelMaxAirPressure;

        protected Vehicle(string i_Model, string i_LicenseNumber)
        {
            this.r_Model = i_Model;
            this.r_LicenseNumber = i_LicenseNumber;
        }

        protected void AddWheels(string i_WheelManufacturerName, float i_WheelMaxAirPressure)
        {
            if (m_VehicleWheelMaxAirPressure < i_WheelMaxAirPressure)
            {
                i_WheelMaxAirPressure = m_VehicleWheelMaxAirPressure;
            }

            m_WheelsOfVehicle = new List<Wheel>(m_NumberOfWheels);
            for (int indexOfWheel = 0; indexOfWheel < m_NumberOfWheels; indexOfWheel++)
            {
                m_WheelsOfVehicle.Add(new Wheel(i_WheelManufacturerName, i_WheelMaxAirPressure));
            }
        }

        public void CurrentWheelsPressure(float i_WheelCurrentAirPressure)
        {
            foreach (Wheel wheel in m_WheelsOfVehicle)
            {
                wheel.CurrentAirPressure = i_WheelCurrentAirPressure;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.r_LicenseNumber;
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return this.m_NumberOfWheels;
            }
        }

        public string Model
        {
            get
            {
                return this.r_Model;
            }
        }

        public string OwnerOfTheVehicle
        {
            get
            {
                return this.m_OwnerOfTheVehicle;
            }

            set
            {
                this.m_OwnerOfTheVehicle = value;
            }
        }

        public string NumberPhoneOfOwner
        {
            get
            {
                return this.m_NumberPhoneOfOwner;
            }

            set
            {
                this.m_NumberPhoneOfOwner = value;
            }
        }

        public Garage.eStatusVehicle StatusOfVehicle
        {
            get
            {
                return this.m_StatusOfVehicle;
            }

            set
            {
                this.m_StatusOfVehicle = value;
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_WheelsOfVehicle)
            {
                wheel.GetPressureToMax();
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return this.m_EnergySource;
            }
        }

        public Wheel WheelOfVehicle
        {
            get
            {
                return this.m_WheelsOfVehicle[0];
            }
        }
    }
}