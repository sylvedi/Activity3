using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IService1
    {
        public string GetData(string value)
        {
            return "If your voice travels " + value + " meters, The area of influence of your voice is " + Int32.Parse(value) * 3.14 + " sq meters";
        }

        public HelloObject GetObjectModel(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("composite");
            }
            HelloObject helloObject = new HelloObject();
            if(Int32.Parse(id) < 0)
            {
                helloObject.happyHello = false;
                helloObject.helloMessage = "I am not well :-(";
            }else
            {
                helloObject.happyHello = true;
                helloObject.helloMessage = "I am very happy, thank you";
            }
            return helloObject;
        }

        public string SayHello()
        {
            return "Dear friend, I pray that all may go well with you and that you may be in good health, as it goes well with your soul.";
        }

        public HelloObject GetHelloObject(string id)
        {
            HelloObject helloObject = new HelloObject();

            if(Int32.Parse(id) > 0)
            {
                helloObject.happyHello = true;
                helloObject.helloMessage = "Great day to be alive";
            }

            return helloObject;
        }
    }
}
