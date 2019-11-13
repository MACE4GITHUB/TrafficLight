using System;
using TrafficLightLib.Events;

namespace TrafficLightLib
{
    public interface ITrafficLight
    {
        /// <summary>
        /// Power for traffic light.
        /// </summary>
        IPower Power { get; }

        /// <summary>
        /// The event occurs when the state of the traffic light sections changes.
        /// </summary> 
        event EventHandler<TrafficLightSectionChangedEventArgs> SectionChanged;
    }
}