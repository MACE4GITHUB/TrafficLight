using System;
using TrafficLightLib.Events;

namespace TrafficLightLib.Infrastructure
{
    public class Power : IPower
    {
        private Status _state = Status.Off;

        /// <summary>
        /// Set Power State
        /// </summary>
        public Status State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state == value) return;
                _state = value;
                OnStateChanged();
            }
        }

        /// <summary>
        /// The event occurs when a power state changes.
        /// </summary>
        public event EventHandler<PowerStateChangedEventArgs> StateChanged;

        private void OnStateChanged()
        {            
            var args = new PowerStateChangedEventArgs(State);
            StateChanged?.Invoke(this, args);
        }
    }
}