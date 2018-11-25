using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            this.r_ManufacturerName = i_ManufacturerName;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public void WheelInflation(float i_AirPressureToAdd)
        {
            if (this.m_CurrentAirPressure + i_AirPressureToAdd > this.r_MaxAirPressure || i_AirPressureToAdd < 0)
            {
                throw new ValueOutOfRangeExecption(this.r_MaxAirPressure - this.m_CurrentAirPressure, 0);
            }
            else
            {
               this.m_CurrentAirPressure += i_AirPressureToAdd;
            }
        }

        public void GetPressureToMax()
        {
            this.m_CurrentAirPressure = this.r_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return this.r_ManufacturerName;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                if (value > r_MaxAirPressure)
                {
                    throw new ValueOutOfRangeExecption(r_MaxAirPressure, 0);
                }
                else
                {
                    this.m_CurrentAirPressure = value;
                }
            }
        }
    }
}