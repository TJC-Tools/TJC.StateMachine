namespace TJC.StateMachine
{
    /// <summary>
    /// State machine pattern base class.
    /// </summary>
    /// <typeparam name="T">State Type.</typeparam>
    /// <param name="initialState">Initial State of the State Machine.</param>
    public abstract class StateMachineBase<T>(T initialState)
    {
        private T _state = initialState;

        /// <summary>
        /// State of the state machine.
        /// </summary>
        protected T State
        {
            get => _state;
            set
            {
                if (Equals(_state, value))
                    return;
                _state = value;
                OnStateChanged();
            }
        }

        /// <summary>
        /// Called on state change.
        /// Can be used to add tracing &amp; debugging.
        /// Should not be used to notify of state changes externally.
        /// </summary>
        protected abstract void OnStateChanged();
    }
}
