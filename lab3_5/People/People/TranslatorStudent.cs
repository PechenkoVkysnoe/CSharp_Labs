using System;
using System.Threading;
namespace laba3
{
    class TranslatorStudent : Student
    {
        public enum MainLanguage
        {
            English,
            German,
            French,
            Spanish,
            Italian,
            Turkish,
            Portuguese
        }
        public MainLanguage mainLanguage { get; set; }
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
        public TranslatorStudent(string firstName, string secondName, string thirdName, Sex sex, int age, University university, int course, bool grant, bool freeEducation, MainLanguage mainLanguage, LanguageEnglish languageEnglish)
            : base(firstName, secondName, thirdName, sex, age, university, course, grant, freeEducation)
        {
            this.mainLanguage = mainLanguage;
            this.languageEnglish = languageEnglish;
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
        public void Translate()
        {
            Console.WriteLine("Translate...");
            Thread.Sleep(5000);
            Console.WriteLine("Translation completed");
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Free Education: {freeEducation}");
            Console.WriteLine($"Grant: {grant}");
            Console.WriteLine($"Main Language: {mainLanguage}");
            Console.WriteLine($"Language English: {languageEnglish}");
        }
    }
}