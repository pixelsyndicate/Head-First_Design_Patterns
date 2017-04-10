namespace GumballMachine
{
    public interface IGumballMachineOld
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();

        // todo: other methods like toString() and refill()
        string ToString();
    }
}