namespace TJC.StateMachine.Tests.Mocks
{
    internal class RevolverMock() : StateMachineBase<RevolverStates>(RevolverStates.Loaded)
    {
        public int BulletsLoaded { get; private set; } = 6;

        internal uint StateChanges = 0;

        public bool TryShoot()
        {
            switch (State)
            {
                case RevolverStates.Empty:
                    return false;
                case RevolverStates.Loaded:
                    BulletsLoaded--;
                    if (BulletsLoaded == 0)
                        State = RevolverStates.Empty;
                    return true;
                default:
                    throw new InvalidOperationException(
                        $"Unknown State [{State}] for method {nameof(TryShoot)}"
                    );
            }
        }

        public void Reload()
        {
            BulletsLoaded = 6;
            State = RevolverStates.Loaded;
        }

        protected override void OnStateChanged()
        {
            base.OnStateChanged();
            StateChanges++;
        }
    }
}
