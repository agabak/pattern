using System;
using System.Collections.Generic;
using System.Text;

namespace array
{
    //FlagsAttribute in C# ia a greater way of using a bit feild to hold a collection of flags
    [Flags]
    public enum ServiceRequirements
    {
        None = 0,
        WheelAligment = 1,
        Dirty = 2,
        EngineTune = 4,
        TestDrive = 5
    }

    public class Car
    {
        public ServiceRequirements Requirements { get; set; }

        public bool IsServiceComplete
        {
            get
            {
                return Requirements == ServiceRequirements.None;
            }
        }
    }

    public abstract class ServiceHandler
    {
        protected ServiceHandler _nextServiceHandler;
        protected ServiceRequirements _serviceProvided;

        public ServiceHandler(ServiceRequirements serviceProvided)
        {
            _serviceProvided = serviceProvided;
        }

        public void Service(Car car)
        {
            if(_serviceProvided == (car.Requirements & _serviceProvided))
            {
                Console.WriteLine($"{this.GetType().Name} providing {this._serviceProvided}  service");
                car.Requirements &= ~_serviceProvided;
            }
            if (car.IsServiceComplete || _nextServiceHandler == null) return;
            _nextServiceHandler.Service(car);
        }

        public void SetNextServiceHandler(ServiceHandler handler)
        {
            _nextServiceHandler = handler;
        }
    }

    public class Detail: ServiceHandler
    {
        public Detail(): base(ServiceRequirements.Dirty)
        {
        }
    }

    public class Machanic: ServiceHandler
    {
        public Machanic(): base(ServiceRequirements.EngineTune)
        {

        }
    }


    public class WheelSpecialist: ServiceHandler
    {
        public WheelSpecialist(): base(ServiceRequirements.WheelAligment)
        {

        }

    }

    public class QualityControl :ServiceHandler
    {
        public QualityControl() : base(ServiceRequirements.TestDrive)
        {

        }
    }



    class Chain
    {
    }
}
