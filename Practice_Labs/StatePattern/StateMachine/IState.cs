namespace StateMachine
{
    /// <summary>
    /// This looks a lot like the original IGumballMachine interface, 
    /// but we are encapsulating the states to be separate from the machine, 
    /// allowing us to change the behaviors of the gumballmachine as needed by 
    /// just delegating the details to the concrete implimentations of the IState
    /// </summary>
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }
}