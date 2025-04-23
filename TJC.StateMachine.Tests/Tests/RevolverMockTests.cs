using TJC.StateMachine.Tests.Mocks;

namespace TJC.StateMachine.Tests.Tests
{
    [TestClass]
    public class RevolverMockTests
    {
        [TestMethod]
        public void EnsureRevolverStartsFull()
        {
            var revolver = new RevolverMock();
            Assert.AreEqual(6, revolver.BulletsLoaded);
        }

        [TestMethod]
        public void EnsureRevolverShootingLowersBulletsToZeroThenRequiresReloading()
        {
            var revolver = new RevolverMock();

            var result = revolver.TryShoot();
            Assert.IsTrue(result);
            Assert.AreEqual(5, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.IsTrue(result);
            Assert.AreEqual(4, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.IsTrue(result);
            Assert.AreEqual(3, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.IsTrue(result);
            Assert.AreEqual(2, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.IsTrue(result);
            Assert.AreEqual(1, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.IsTrue(result);
            Assert.AreEqual(0, revolver.BulletsLoaded);

            result = revolver.TryShoot();
            Assert.IsFalse(result);
            Assert.AreEqual(0, revolver.BulletsLoaded);
        }

        [TestMethod]
        public void EnsureReloadingResetsBulletsTo6()
        {
            var revolver = new RevolverMock();

            Assert.AreEqual(6, revolver.BulletsLoaded);
            revolver.TryShoot();
            Assert.AreEqual(5, revolver.BulletsLoaded);
            revolver.Reload();
            Assert.AreEqual(6, revolver.BulletsLoaded);
        }
    }
}
