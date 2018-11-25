using System;

namespace Ex03.GarageLogic
{
    public class GasTank : EnergySource
    {
        public enum eTypeOfFuel
        {
            Octan95,
            Octan96,
            Octan98,
            Soler,
        }

        private readonly eTypeOfFuel r_TypeOfFuel;

        public GasTank(eTypeOfFuel i_FuelType, float i_MaxAmountOfFuel) : base(i_MaxAmountOfFuel)
        {
            this.r_TypeOfFuel = i_FuelType;
        }

        public void AddFuelToCar(eTypeOfFuel i_TypeOfFuel, float i_AmountOfFuelToAdd)
        {
            if (i_TypeOfFuel != this.r_TypeOfFuel)
            {
                throw new ArgumentException();
            }
            else
            {
                this.LoadEnergySource(i_AmountOfFuelToAdd);
            }
        }

        public eTypeOfFuel TypeOfFuel
        {
            get
            {
                return this.r_TypeOfFuel;
            }
        }
    }
}