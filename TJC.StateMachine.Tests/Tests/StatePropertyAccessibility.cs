using System.Reflection;
using TJC.StateMachine.Tests.Mocks;

namespace TJC.StateMachine.Tests.Tests
{
    
    public class StatePropertyAccessibility
    {
        [Fact]
        public void EnsurePropertyStateIsNotPubliclyAccessible()
        {
            var prop = typeof(StateMachineBase<RevolverStates>).GetProperty(
                "State",
                BindingFlags.Instance | BindingFlags.Public
            );
            Assert.Null(prop);
        }

        [Fact]
        public void EnsurePropertyStateIsProtectedAccessible()
        {
            var prop = typeof(StateMachineBase<RevolverStates>).GetProperty(
                "State",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            Assert.NotNull(prop);
            var getter = prop.GetMethod;
            Assert.NotNull(getter);
            Assert.True(getter.IsFamily);
        }
    }
}
