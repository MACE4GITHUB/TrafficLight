using System;
using TrafficLightLib.Events;

namespace TrafficLightLib
{
    public interface IPower
    {
        Status State { get; set; }    
        
        event EventHandler<PowerStateChangedEventArgs> StateChanged;
    }
}