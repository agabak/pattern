using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace array
{
    class Program
    {
        static void Main(string[] args)
        {
            var alert = new AlertMessage("Hello there");

            alert.PrintMessage();

            var agaba = new[]
                        {
                            new Claim(ClaimTypes.Name, "Agaba"),
                            new Claim(ClaimTypes.NameIdentifier, "12"),
                        };

                Console.WriteLine("Enter all the information :");

                var password = Console.ReadLine();

                //byte[] passwordHash, key;

                var hash = new Hashtable();
                hash.Add(45, "Agaba");
                hash.Add(34, "Asimwe");
                hash.Add(11, "Dinniana");
               var rt =   hash.Contains(59);

                     Console.WriteLine(rt);
                    StringCryptOgrapgy.Cryptograyphy(out var passwordHash,out var  key, password);

                 
                Console.WriteLine(StringCryptOgrapgy.GetPassword(password, passwordHash,key));
             
                Console.ReadLine();

            var messages = new List<IMessage>
                {
                  new  NormanMessage(new SimpleMessage("Frist Message")),
                  new NormanMessage (new AlertMessage("Second message with beep")),
                  new SimpleMessage("Not Decord.."),
                  new ErrorMessage(new AlertMessage("What are you doing..."))

                };

            foreach(var message in messages )
            {
                message.PrintMessage();
            }


            var mechanic = new Machanic();
            var detailer = new Detail();
            var wheels = new WheelSpecialist();
            var qa = new QualityControl();

            qa.SetNextServiceHandler(detailer);
            wheels.SetNextServiceHandler(qa);
            mechanic.SetNextServiceHandler(wheels);
           // mechanic.SetNextServiceHandler(qa);

            Console.WriteLine("Car 1 is dirty");
            mechanic.Service(new Car
            {
                Requirements = ServiceRequirements.Dirty | ServiceRequirements.EngineTune
                                     | ServiceRequirements.TestDrive | ServiceRequirements.WheelAligment
            });

            Console.ReadLine();
        }
    }
}
