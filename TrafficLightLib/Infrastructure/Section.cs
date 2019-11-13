using System;

namespace TrafficLightLib.Infrastructure
{
    public class Section
    {
        public Section(Status red, Status yellow, Status green, int lightTime = 1000)
        {
            Red = red;
            Yellow = yellow;
            Green = green;            
            LightTime = TimeSpan.FromMilliseconds(lightTime);
        }
        /// <summary>
        /// Get State Red section of traffic light
        /// </summary>
        public Status Red { get; }

        /// <summary>
        /// Get State Yellow section of traffic light
        /// </summary>
        public Status Yellow { get; }

        /// <summary>
        /// Get State Green section of traffic light
        /// </summary>
        public Status Green { get; }

        /// <summary>
        /// Get Time State
        /// </summary>
        public TimeSpan LightTime { get; }        
    }
}