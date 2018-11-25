namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        public Battery(float i_MaxTimeState) : base(i_MaxTimeState)
        {
        }

        public void ChargeBattery(float i_AmountPowerToAdd)
        {
            this.LoadEnergySource(i_AmountPowerToAdd);
        }
    }
}