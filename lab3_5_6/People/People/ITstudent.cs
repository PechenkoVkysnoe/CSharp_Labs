using System;

namespace laba3
{
    class ITStudent : Student
    {
        public enum MainProgrammingLanguage
        {
            cSharp,
            cPlusPlus,
            Pascal,
            Delphi,
            Java,
            Python,
            Assembler,
            Ruby
        }
        public MainProgrammingLanguage mainProgrammingLanguage { get; set; }
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
        public ITStudent(string firstName, string secondName, string thirdName, Sex sex, int age, University university, int course, bool grant, bool freeEducation, MainProgrammingLanguage mainProgrammingLanguage, LanguageEnglish languageEnglish, bool work,int sum)
            : base(firstName, secondName, thirdName, sex, age,university,course,grant,freeEducation)
        {
            this.languageEnglish = languageEnglish;
            this.mainProgrammingLanguage = mainProgrammingLanguage;
            this.work = work;
        }
        public delegate void MoneyHandler(string message);
        public event MoneyHandler Notify;
        public int sum { get; private set; }
        public void Put(int _sum)
        {
            sum += _sum;
            Notify?.Invoke($"На счет поступило: {_sum}");
        }
        public void Take(int _sum)
        {
            if (sum>=_sum)
            {
                sum -= _sum;
                Notify?.Invoke($"Со счета снято: {-sum}");
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {sum}"); ;
            }
        }
        public void ChangeMainProgrammingLanguage(MainProgrammingLanguage mainProgrammingLanguage)
        {
            this.mainProgrammingLanguage = mainProgrammingLanguage;
        }
        public void GetWork()
        {
            work = true;
        }
        public void TakeCourseEnglish()
        {
            if ((int)languageEnglish!=5)
            {
                languageEnglish++;
            }
        }
        public void ChangeLanguageEnglish(LanguageEnglish languageEnglish)
        {
            this.languageEnglish = languageEnglish;
        }
        public void WriteLaboratory()
        {
            Random rnd = new Random();
            int chance = rnd.Next(42, 90);
            if (chance<50)
            {
                DoNotPassLaboratory();
            }
            else
            {
                PassLaboratory();
            }
        }
        public void PassLaboratory()
        {
            chanceDeducted--;
        }
        public void DoNotPassLaboratory()
        {
            chanceDeducted++;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Free Education: {freeEducation}");
            Console.WriteLine($"Grant: {grant}");
            Console.WriteLine($"Main Programming Language: {mainProgrammingLanguage}");
            Console.WriteLine($"Language English: {languageEnglish}");
            Console.WriteLine($"Work: {work}");
            Console.WriteLine($"Money: {sum}");
        }
    }
}