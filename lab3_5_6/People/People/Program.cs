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
            People Mam = new People("Алла", "Григорчук", "Викентьевна");
            Mam.age = 50;
            Mam.sex = Sex.Women;
            Mam.GetInfo();
            Humans family = new Humans();
            family[0] = Mam;
            Console.WriteLine($"Age: {family[0].age}");
            Student Sister = new TranslatorStudent("Анна", "Григорчук", "Александровна", Sex.Women, 21, Student.University.BNTU, 5, true,true,TranslatorStudent.MainLanguage.English, TranslatorStudent.LanguageEnglish.C1);
            Sister.GetInfo();
            Sister.PickUpGrant();
            Sister.GetInfo();
            Sister.Deduct();
            Sister.GetInfo();
            ITStudent I = new ITStudent("Михаил", "Григорчук", "Александрович", Sex.Man, 19, Student.University.BSUIR, 1, true, true, ITStudent.MainProgrammingLanguage.cSharp, ITStudent.LanguageEnglish.A2, true);
            I.GetInfo();
            I.TakeCourseEnglish();
            I.WriteLaboratory();
            I.GetWork();
            I.PickUpGrant();
            I.GetInfo();
            I.Deduct();
            I.GetInfo();
            TranslatorStudent Friend = new TranslatorStudent("Иван", "Иванов", "Иванов", Sex.Man, 20, Student.University.GRSU, 2, false, false, TranslatorStudent.MainLanguage.English, TranslatorStudent.LanguageEnglish.C1);
            Friend.TakeCourseEnglish();
            Friend.Translate();
            Friend.GetInfo();
            People Teacher = new People("Константин", "Вильчевский","Юрьевич", Sex.Man, 24);
            Console.WriteLine(I.CompareTo(Teacher));
        }
    }
}
