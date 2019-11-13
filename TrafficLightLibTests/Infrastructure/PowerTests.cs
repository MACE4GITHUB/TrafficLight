using FluentAssertions;
using NUnit.Framework;
using TrafficLightLib.Events;

namespace TrafficLightLib.Infrastructure.Tests
{
    [TestFixture(), Timeout(50)]
    public class PowerTests
    {
        IPower power;

        [SetUp()]
        public void PowerNew()
        {
            power = new Power();
        }

        [Test()]
        public void PowerTest()
        {
            power.Should().NotBeNull();
        }

        [Test()]
        public void PowerStartStateBeOffTest()
        {
            Status state = power.State;
            state.Should().Be(Status.Off);
        }

        [Test()]
        public void PowerStateBeOnTest()
        {
            power.State = Status.On;
            power.State.Should().Be(Status.On);
        }

        [Test()]
        public void PowerStateBeOffTest()
        {
            power.State = Status.On;
            power.State = Status.Off;
            power.State.Should().Be(Status.Off);
        }

        [Test()]
        public void PowerEventStateTest()
        {
            Status state = Status.Off;
            void lambda(object _, PowerStateChangedEventArgs e) { state = e.State; }
            power.StateChanged += lambda;
            power.State = Status.On;
            
            state.Should().Be(Status.On);

            power.State = Status.Off;

            state.Should().Be(Status.Off);

            power.StateChanged -= lambda;            
        }
    }
}