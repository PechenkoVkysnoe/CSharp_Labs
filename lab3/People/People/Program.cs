using System;

namespace laba3
{
    enum Sex
    {
        Man,
        Women
    }
    class Program
    {
        static void Main()
        {
            People I = new People("Михаил", "Григорчук", "Александрович", Sex.Man, 18);
            People Mam = new People("Алла", "Григорчук", "Викентьевна");
            Mam.age = 50;
            Mam.sex = Sex.Women;
            I.GetInfo();
            Mam.GetInfo();
            I.age = 19;
            I.GetInfo();
            Humans family = new Humans();
            family[0] = I;
            family[1] = Mam;
            Console.WriteLine($"Age: {family[1].age}");
        }
    }
}
