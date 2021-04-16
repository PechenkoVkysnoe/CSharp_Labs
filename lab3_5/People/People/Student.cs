using System;

namespace laba3
{
     class Student : People
    {
        public enum University
        {
            Other,
            BSUIR,
            BSU,
            BNTU,
            GRSU,
            None
        }
        public University university { get; set; }
        public int course { get; set; }
        public bool grant { get; set; }
        public bool freeEducation { get; set; }
        public int chanceDeducted { get; set; }
        public Student(string firstName, string secondName, string thirdName, Sex sex, int age, University university, int course, bool grant, bool freeEducation)
            : base(firstName,secondName,thirdName,sex,age)
        {
            this.university = university;
            this.course = course;
            this.freeEducation = freeEducation;
            if (!freeEducation)
            {
                this.grant = false;
            }
            else
            {
                this.grant = grant;
            }
            Random rnd = new Random();
            if (sex==Sex.Women)
            {
                chanceDeducted = rnd.Next(10, 50);
            }
            else
            {
                chanceDeducted = rnd.Next(10, 90);
            }
        }
        public void PickUpGrant()
        {
            grant = false;
        }
        public void GiveUpGrant()
        {
            grant = true;
        }
        public void Deduct()
        {
            university = University.None;
            course = 0;
            freeEducation = false;
            grant = false;
            chanceDeducted = 0;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"University: {university}");
            Console.WriteLine($"Course: {course}");
            Console.WriteLine($"Free Education: {freeEducation}");
            Console.WriteLine($"Grant: {grant}");
            Console.WriteLine($"Chance Deducted: {chanceDeducted}");
        }
    }
}
