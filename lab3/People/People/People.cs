using System;
using System.Collections.Generic;
namespace laba3
{
    class Humans
    {
        List<People> humans;
        public People this[int index]
        {
            set
            {
                humans.Insert(index, value);
                ++numberOfHumans;
            }
            get
            {
                return humans[index];
            }
        }
        public Humans()
        {
            humans = new List<People>();
            numberOfHumans = 0;
        }
        private int numberOfHumans;
    }
    class People
    {
        private Guid id;
        public int age { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public Sex sex { get; set; }

        public People(string firstName, string secondName, string thirdName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            id = Guid.NewGuid();
        }
        public People(string firstName, string secondName, string thirdName, Sex sex, int age)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.sex = sex; this.age = age;
            id = Guid.NewGuid();
        }
        public void GetInfo()
        {
            Console.WriteLine("Information");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"FirstName: {firstName}");
            Console.WriteLine($"SecondName: {secondName}");
            Console.WriteLine($"ThirdName: {thirdName}");
            Console.WriteLine($"Sex: {sex}");
            Console.WriteLine($"Age: {age}");
        }
    }
}
