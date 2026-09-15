using TJC.StateMachine.Tests.Mocks;

namespace TJC.StateMachine.Tests.Tests
{
    public class RevolverMockTests
    {
        [Fact]
        public void EnsureRevolverStartsFull()
        {
            var revolver = new RevolverMock();
            Assert.Equal(6, revolver.BulletsLoaded);
        }

        [Fact]
        public void EnsureRevolverShootingLowersBulletsToZeroThenRequiresReloading()
        {
            var revolver = new RevolverMock();

            var result = revolver.TryShoot();
            Assert.True(result);
            Assert.Equal(5, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.True(result);
            Assert.Equal(4, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.True(result);
            Assert.Equal(3, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.True(result);
            Assert.Equal(2, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.True(result);
            Assert.Equal(1, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.True(result);
            Assert.Equal(0, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.False(result);
            Assert.Equal(0, revolver.BulletsLoaded);
        }

        [Fact]
        public void EnsureReloadingResetsBulletsTo6()
        {
            var revolver = new RevolverMock();

            Assert.Equal(6, revolver.BulletsLoaded);
            revolver.TryShoot();
            Assert.Equal(5, revolver.BulletsLoaded);
            revolver.Reload();
            Assert.Equal(6, revolver.BulletsLoaded);
        }

        [Fact]
        public void EnsureEmptyingChangesStateAndReloadingChangesStateAgain()
        {
            var revolver = new RevolverMock();

            Assert.Equal<uint>(0, revolver.StateChanges);

            revolver.TryShoot();
            revolver.TryShoot();
            revolver.TryShoot();
            revolver.TryShoot();
            revolver.TryShoot();
            revolver.TryShoot();

            Assert.Equal<uint>(1, revolver.StateChanges);

            revolver.Reload();

            Assert.Equal<uint>(2, revolver.StateChanges);
        }

        [Fact]
        public void EnsureReloadingMultipleTimesDoesNotChangeState()
        {
            var revolver = new RevolverMock();

            Assert.Equal<uint>(0, revolver.StateChanges);

            revolver.Reload();
            revolver.Reload();
            revolver.Reload();

            Assert.Equal<uint>(0, revolver.StateChanges);
        }
    }
}
