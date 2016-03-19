using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp
{
    public static class Test
    {
        public static void StartTesting()
        {
            int myage = 38;
            int yourage = 10;
            int total = myage + yourage;
            Debug.WriteLine(total);

            bool isOfAge = myage > 18;
            bool isOfAge2 = yourage > 18;

            Debug.WriteLine(string.Format("Is Of Age {0}", isOfAge));
            Debug.WriteLine(string.Format("Is Of Age 2 {0}", isOfAge2));

            double mySalary = 1.25;
            double yourSalary = 2.14;
            double totalSalary = mySalary + yourSalary;
            Debug.WriteLine(string.Format("Total Salary {0}", totalSalary));

            bool areYouABaller = yourSalary > mySalary;
            Debug.WriteLine(string.Format("Are you a baller? {0}", areYouABaller));

            string myName = "Danny";

            string yourName = "Wendell";
            string ourNames = myName + yourName;
            Debug.WriteLine(string.Format("Our Names {0}", ourNames));

            //Debug.WriteLine(string.Format("{0}", myName)(string.Format("Are you a Baller? {0}", areYouABaller)));
            Debug.WriteLine(string.Format("{0} are you a baller? {1}", myName, areYouABaller));

            int[] myArray = new int[10];
            myArray[0] = 1;
            myArray[1] = 45345;
            myArray[2] = 234;
            myArray[3] = 767;
            myArray[4] = 123423452;

            foreach (int currentValue in myArray)
            {

            }

            for (int i = 0; i < myArray.Length; i++)
            {
                int currentValue = myArray[i];
                Debug.WriteLine(string.Format("Current Value {0}", currentValue));


                switch (currentValue)
                {
                    case 234:
                        Debug.WriteLine("Target Value Found");
                        break;
                    default:
                        Debug.WriteLine("Searching for Target Value");
                        break;
                }

            }

        }

        public static void ObjectTesting()
        {
            Person person1 = new Person();
            person1.Birthday = DateTime.Now.AddYears(-38);
            person1.Speak();
            person1.Name = "John";

            Person person2 = new Person();
            person2.Name = "Billy";

            person1.AddFriend(person2);
            person1.ShowFriends();
        }
        public static void AnimalTesting()
        {
            //Animal teddy = new Animal();
            //teddy.Birthday = DateTime.Now.AddMonths(-4);
            //teddy.Name = "Teddy";
            //teddy.NumberOfLegs = 4;
            //teddy.isAlive = teddy.numberOfLegs > 0;
            //Debug.WriteLine(string.Format("Is Teddy Alive? {0}", teddy.isAlive));

            //Animal vinny = new Animal();
            //vinny.Birthday = DateTime.Now.AddMonths(1);
            //vinny.Name = "Vinny";
            //vinny.NumberOfLegs = 4;
            //vinny.isAlive = vinny.Birthday > DateTime.Now;
            //Debug.WriteLine(string.Format("Is Vinny Alive? {0}", vinny.isAlive));

            Dog teddy = new Dog();
            Dog darla = (Dog)teddy.GiveBirth();
            Debug.WriteLine(string.Format("Darla has {0} legs and is alive {1}", darla.NumberOfLegs, darla.isAlive));
        }

    }

    public class Person
    {
        private DateTime _birthday;
        private string _name;

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName { get; set; }

        public List<Person> Friends { get; set; }

        public Person()
        {
            this.Friends = new List<Person>();
        }

        public void Speak()
        {
            Debug.WriteLine(string.Format("My Birthday is {0}", this.Birthday));
        }

        public void AddFriend(Person friend)
        {
            this.Friends.Add(friend);
        }
        //This is a method
        public void ShowFriends()  
        {
            //this is a loop        
            foreach (Person currentPerson in this.Friends)
            {
                Debug.WriteLine(string.Format("{0}", currentPerson.Name));
            }

        }
    }

    public abstract class Animal
    {
        //this is field (ivar jin C++) or instance variable
        private DateTime _birthday;
        //This is a property...they have getters and setters
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        // Synth property (caps for properties)
        public string Name { get; set; }
        // protected means only subclasses have access to set
        public int NumberOfLegs { get; protected set; }
        public bool isAlive { get; set; }

        public virtual Animal GiveBirth()
        {
            return null;
        }

    }
    //this is a case on inheritence, where Dog inherits the properties of Animal
    public class Dog : Animal
    {
        //this is a constructor, called when c# rolls up the instance
        public Dog()
        {
            // This refers to the specific instance, in this case Dog
            this.NumberOfLegs = 4;
            this.isAlive = true;
   
        }
        public override Animal GiveBirth()
        {
            var newDog = new Dog();
            return newDog;
        }
    }
}

