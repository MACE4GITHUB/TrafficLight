using System;
using TrafficLightLib.Events;

namespace TrafficLightLib
{
    /// <summary>
    /// Traffic light power
    /// </summary>
    public interface IPower
    {
        /// <summary>
        /// Power Status
        /// </summary>
        Status State { get; set; }

        /// <summary>
        /// The event occurs when the power Status changes.
        /// </summary>
        event EventHandler<PowerStateChangedEventArgs> StateChanged;
    }
}