using TrafficLightLib.Infrastructure;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace TrafficLightLib.Infrastructure.Tests
{
    [TestFixture()]
    public class TrafficLightTests
    {
        [Test()]
        public void TrafficLightCreateExeptionTest()
        {
            TrafficLight trafficLight;
            Action act = () => { trafficLight = new TrafficLight(null); };

            act.Should().Throw<ArgumentNullException>();
        }

        [Test()]
        public void TrafficLightCreateGoodTest()
        {
            var mockPower = new Mock<IPower>();

            var trafficLight = new TrafficLight(mockPower.Object);

            trafficLight.Should().NotBeNull();
        }

        [Test()]
        public void TrafficLightTest()
        {
            var mockPower = new Mock<IPower>();

            var trafficLight = new TrafficLight(mockPower.Object);

            trafficLight.Power.Should().NotBeNull();
        }
    }
}