using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeExecption : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeExecption(float i_MaxValue, float i_MinValue)
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get
            {
                return this.r_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return this.r_MinValue;
            }
        }
    }
}