using System;

namespace TrafficLightLib.Infrastructure
{
    public class Section
    {
        /// <summary>
        /// Sets status section of traffic light
        /// </summary>
        /// <param name="red">Sets status Red section</param>
        /// <param name="yellow">Sets status Yellow section</param>
        /// <param name="green">Sets status Green section</param>
        /// <param name="lightTime">Sets time section</param>
        public Section(Status red, Status yellow, Status green, int lightTime = 1000)
        {
            Red = red;
            Yellow = yellow;
            Green = green;            
            LightTime = TimeSpan.FromMilliseconds(lightTime);
        }
        /// <summary>
        /// Get status Red section of traffic light
        /// </summary>
        public Status Red { get; }

        /// <summary>
        /// Get status Yellow section of traffic light
        /// </summary>
        public Status Yellow { get; }

        /// <summary>
        /// Get status Green section of traffic light
        /// </summary>
        public Status Green { get; }

        /// <summary>
        /// Get Time section
        /// </summary>
        public TimeSpan LightTime { get; }        
    }
}