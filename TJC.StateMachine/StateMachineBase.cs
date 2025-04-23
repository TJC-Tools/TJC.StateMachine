namespace TJC.StateMachine
{
    /// <summary>
    /// State machine pattern base class.
    /// </summary>
    /// <typeparam name="T">State Type.</typeparam>
    /// <param name="initialState">Initial State of the State Machine.</param>
    public class StateMachineBase<T>(T initialState)
    {
        /// <summary>
        /// State of the state machine.
        /// </summary>
        protected T State { get; set; } = initialState;
    }
}
