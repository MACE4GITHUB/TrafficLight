using System;
using TrafficLightLib.Infrastructure;

namespace TrafficLightLib.Events
{
    public class TrafficLightSectionChangedEventArgs : EventArgs
    {
        public Section Section { get; }

        public TrafficLightSectionChangedEventArgs(Section section)
        {
            Section = section;
        }
    }
}