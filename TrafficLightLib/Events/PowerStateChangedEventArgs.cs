using System;

namespace TrafficLightLib.Events
{
    public class PowerStateChangedEventArgs: EventArgs
    {
        public Status State { get; }

        public PowerStateChangedEventArgs(Status state)
        {
            State = state;
        }
    }
}