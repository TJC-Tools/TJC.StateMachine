using System.Reflection;
using TJC.StateMachine.Tests.Mocks;

namespace TJC.StateMachine.Tests.Tests
{
    [TestClass]
    public class StatePropertyAccessibility
    {
        [TestMethod]
        public void EnsurePropertyStateIsNotPubliclyAccessible()
        {
            var prop = typeof(StateMachineBase<RevolverStates>).GetProperty(
                "State",
                BindingFlags.Instance | BindingFlags.Public
            );
            Assert.IsNull(prop);
        }

        [TestMethod]
        public void EnsurePropertyStateIsProtectedAccessible()
        {
            var prop = typeof(StateMachineBase<RevolverStates>).GetProperty(
                "State",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            Assert.IsNotNull(prop);
            var getter = prop.GetMethod;
            Assert.IsNotNull(getter);
            Assert.IsTrue(getter.IsFamily);
        }
    }
}
