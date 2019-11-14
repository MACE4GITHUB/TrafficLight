using System;
using System.Threading;
using System.Threading.Tasks;
using TrafficLightLib.Events;

namespace TrafficLightLib.Infrastructure
{
    public class TrafficLight : ITrafficLight
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Thread _thread;
        private readonly Section _sectionOff = new Section(Status.Off, Status.Off, Status.Off, 10);
        private readonly Section[] _sections = new Section[] {
                new Section(Status.On, Status.Off, Status.Off, 7000),
                new Section(Status.On, Status.On, Status.Off, 2000),
                new Section(Status.Off, Status.Off, Status.On, 5000),
                new Section(Status.Off, Status.Off, Status.Off, 500),
                new Section(Status.Off, Status.Off, Status.On),
                new Section(Status.Off, Status.Off, Status.Off, 500),
                new Section(Status.Off, Status.Off, Status.On),
                new Section(Status.Off, Status.Off, Status.Off, 500),
                new Section(Status.Off, Status.Off, Status.On),
                new Section(Status.Off, Status.On, Status.Off, 2000)
            };        

        /// <summary>
        /// Create new traffic light
        /// </summary>
        /// <param name="power">Traffic light power supply</param>
        public TrafficLight(IPower power)
        {
            Power = power ?? throw new ArgumentNullException(nameof(power), "Ошибка. Не задан источник питания.");
            Power.StateChanged += ChangeWorkingState;
        }

        /// <summary>
        /// Power for traffic light.
        /// </summary>
        public IPower Power { get; }

        /// <summary>
        /// The event occurs when the state of the traffic light sections changes.
        /// </summary>        
        public event EventHandler<TrafficLightSectionChangedEventArgs> SectionChanged;

        private void OnSectionChanged(Section section)
        {
            var eventArgs = new TrafficLightSectionChangedEventArgs(section);
            SectionChanged?.Invoke(this, eventArgs);
        }

        private void ChangeWorkingState(object sender, PowerStateChangedEventArgs eventArgs)
        {
            if (eventArgs.State == Status.On)
            {
                TrafficLightWorking();
            }
            else
            {
                _cancellationTokenSource.Cancel();
                _thread.Join();
                OnSectionChanged(_sectionOff);
            }
        }

        private void TrafficLightWorking()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _thread = new Thread(DoWork);
            object obj = new Obj(this, _cancellationTokenSource.Token);
            _thread.Start(obj);
        }

        private static void DoWork(object o)
        {
            var obj = (Obj)o;
            var sections = obj.TrafficLight._sections;
            var cancellationToken = obj.CancellationToken;
            var waitHandle = cancellationToken.WaitHandle;
            while (!waitHandle.WaitOne(0))
            {
                foreach (var section in sections)
                {
                    bool hasRepeat = true;
                    do
                    {
                        obj.TrafficLight.OnSectionChanged(section);
                        hasRepeat = false;
                    }
                    while (!waitHandle.WaitOne(section.LightTime) && (hasRepeat));
                    if (waitHandle.WaitOne(0)) return;
                }
            }
        }

        private class Obj
        {
            public Obj(TrafficLight trafficLight, CancellationToken cancellationToken)
            {
                TrafficLight = trafficLight;
                CancellationToken = cancellationToken;
            }

            public TrafficLight TrafficLight { get; }

            public CancellationToken CancellationToken { get; }
        }
    }
}