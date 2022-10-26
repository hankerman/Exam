using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Fasad fasad = new Fasad("Boss", "123");
            fasad.Start();

        }
    }

    abstract class Creator
    {
        public abstract string Name { get; set; }
        
    }

    class Admin : Creator
    {
        public override string Name { get; set; }
        public string Password { get; set; } 
        

        public Admin(string name, string password)
        {
            Name = name;
            Password = password;           
        }

        public Massage Massage(string mas)
        {
            return new Massage(mas);
        }
        
        
    }

    class User : Creator
    {
        public override string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }

        public void Massage(Massage mas)
        {
            Console.Write(Name + ": ");
            mas.Print();
        }
        
    }

    class Server
    {
        private List<User> users;
        public Server()
        {
            users = new List<User>();
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public void Distribution(Massage mass)
        {
            foreach (User user in users)
            {
                user.Massage(mass);                
            }
        }

    }

    class Massage
    {
        public string massage { get; set; }
        public Massage(string massage)
        {
            this.massage = massage;
        }
        public void Print()
        {
            Console.WriteLine(massage);
        }
    }

    class Fasad
    {
        
        Admin admin;
        Server server;        

        public Fasad(string Name, string Password)
        {
            admin = new Admin(Name, Password);
            server = new Server();
            server.AddUser(new User("Петров"));
            server.AddUser(new User("Васечкин"));
            server.AddUser(new User("Иванов"));
        }

        public void Start()
        {
            Massage mas = admin.Massage("Расспродажа");
            server.Distribution(mas);
        }
    }
}
