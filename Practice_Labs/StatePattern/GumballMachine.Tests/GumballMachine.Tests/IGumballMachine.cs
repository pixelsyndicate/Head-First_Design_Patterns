namespace GumballMachine
{
    public interface IGumballMachine
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();

        // todo: other methods like toString() and refill()
        string ToString();
    }
}