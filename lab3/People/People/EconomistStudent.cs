using System;

namespace laba3
{
    class EconomistStudent : Student
    {
        public enum LanguageEnglish
        {
            A1,
            A2,
            B1,
            B2,
            C1,
            C2
        }
        public LanguageEnglish languageEnglish { get; set; }
        public bool work { get; set; }
        public EconomistStudent(string firstName, string secondName, string thirdName, Sex sex, int age, University university, int course, bool grant, bool freeEducation, LanguageEnglish languageEnglish,bool work)
            : base(firstName, secondName, thirdName, sex, age, university, course, grant, freeEducation)
        {
            this.languageEnglish = languageEnglish;
            this.work = work;
        }
        public void TakeCourseEnglish()
        {
            if ((int)languageEnglish != 5)
            {
                languageEnglish++;
            }
        }
        public void ChangeLanguageEnglish(LanguageEnglish languageEnglish)
        {
            this.languageEnglish = languageEnglish;
        }
        public void GetWork()
        {
            work = true;
        }
        public void CreateStartUp()
        {
            work = true;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Free Education: {freeEducation}");
            Console.WriteLine($"Grant: {grant}");
            Console.WriteLine($"Language English: {languageEnglish}");
            Console.WriteLine($"Work: {work}");
        }
    }
}
