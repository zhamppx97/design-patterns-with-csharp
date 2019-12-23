using System;

public class ProxyPattern
{
    class SubjectAccessor
    {
        public interface ISubject
        {
            string Request();
        }

        private class Subject
        {
            public string Request()
            {
                return "Subject Request " + "Choose left door\n";
            }
        }

        public class Proxy : ISubject
        {
            Subject subject;

            public string Request()
            {
                // A virtual proxy create the object only on its first method call
                if (subject == null)
                {
                    Console.WriteLine("Subject inactive");
                    subject = new Subject();
                }
                Console.WriteLine("Subject active");
                return "Proxy: Call to " + subject.Request();
            }
        }

        public class ProtectionProxy : ISubject
        {
            // An authentication proxy first asks for a password
            Subject subject;
            readonly string password = "zhamppx97";

            public string Authenticate(string supplied)
            {
                if (!supplied.Equals(password))
                {
                    return "Protection Proxy: No access";
                }
                else
                {
                    subject = new Subject();
                    return "Protection Proxy: Call to " + subject.Request();
                }
            }

            public string Request()
            {
                if (subject == null)
                {
                    return "Protection Proxy: Authenticate first";
                }
                else
                {
                    return "Protection Proxy: Call to" + subject.Request();
                }
            }
        }
    }

    class ClassClient : SubjectAccessor
    {
        public static void Client()
        {
            Console.WriteLine("Proxy Pattern\n");

            ISubject subject = new Proxy();
            Console.WriteLine(subject.Request());
            Console.WriteLine(subject.Request());

            Console.WriteLine(subject.Request());
            Console.WriteLine((subject as ProtectionProxy).Authenticate("Secret"));
            Console.WriteLine((subject as ProtectionProxy).Authenticate("zhamppx97"));
            Console.WriteLine(subject.Request());
        }
    }
}
