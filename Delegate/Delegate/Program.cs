using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Program
    {
        public delegate void Notification (string name, string mesage);
        public delegate void NotificationWithUser(User user, string mesage);

        public static void Sms(string name, string sms)
            {
                Console.WriteLine($"Mr {name} you hawe receved sms:{sms}");
            }
            public static void Mms(string name, string mms)
            {
                Console.WriteLine($"Mr {name} you hawe receved mms:{mms}");
            }

            public static void Email (string name, string email)
            {
                Console.WriteLine($"Mr {name} you hawe receved email:{email}");
             }
        static void Main(string[] args)
        {
            Notification one = new Notification(Sms);
            one += Mms;
            one += Email;
            one("Kristijan", "You are learning delegates");
            Console.ReadKey();


            User Pero = new User("Pero", "Perovski", "070223322", " peroperovski@delegate.sedc");
            var delUser = new NotificationWithUser(SendEmail);

            delUser += SendSms;
            delUser(Pero, "Kazi zdravo be peer");

            Console.Read();
        }

        public static void SendEmail(User user, string msg)
        {
            Console.WriteLine($"Sending {msg} to {user.Email}");
        }

        public static void SendSms(User user, string msg)
        {
            Console.WriteLine($"Sending {msg} to {user.PhoneNumber}");
        }
    }
}
