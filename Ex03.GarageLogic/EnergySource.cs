using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected readonly float r_MaxAmountOfEnergy;
        protected float m_CurrentAmountOfEnergy;
        protected float m_PercentLeftEnergy;

        public EnergySource(float i_MaxAmountOfEnergy)
        {
            this.r_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        protected void LoadEnergySource(float i_AmountOfForceToAdd)
        {
            if (i_AmountOfForceToAdd < 0 || i_AmountOfForceToAdd + this.m_CurrentAmountOfEnergy > this.r_MaxAmountOfEnergy)
            {
                throw new ValueOutOfRangeExecption(this.r_MaxAmountOfEnergy - this.m_CurrentAmountOfEnergy, 0);
            }
            else
            {
                this.m_CurrentAmountOfEnergy += i_AmountOfForceToAdd;
                updateAmountOfPercentLeft();
            }
        }

        public float MaxAmountOfForce
        {
            get
            {
                return this.r_MaxAmountOfEnergy;
            }
        }

        public float CurrentAmountOfForce
        {
            get
            {
                return this.m_CurrentAmountOfEnergy;
            }

            set
            {
                if (value > r_MaxAmountOfEnergy)
                {
                    throw new ValueOutOfRangeExecption(0, r_MaxAmountOfEnergy);
                }
                else
                {
                    this.m_CurrentAmountOfEnergy = value;
                    this.updateAmountOfPercentLeft();
                }
            }
        }

        private void updateAmountOfPercentLeft()
        {
            this.m_PercentLeftEnergy = this.m_CurrentAmountOfEnergy / this.r_MaxAmountOfEnergy * 100;
        }

        public float RemainingEnergyPercent
        {
            get
            {
                return this.m_PercentLeftEnergy;
            }
        }
    }
}