namespace StateMachine
{
    /// <summary>
    /// Upgraded version of Gumball Machine now uses IState instances.
    /// It will also be passed as a reference parameter for the State implimentations
    /// </summary>
    public interface IGumballMachine
    {

        // todo: other methods like toString() and refill()
        string ToString();


        void SetState(IState newState);

        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();

    }


}