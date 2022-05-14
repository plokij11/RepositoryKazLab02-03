using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KazLab02.Exceptions;

namespace KazLab02.Models
{
    internal class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birth;
        private DateTime? _birthNullable;
        private bool? _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool? _isBirthday;
        #endregion

        #region Properties
        

        internal string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        internal string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        internal string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        internal DateTime? BirthNullable
        {
            get { return _birthNullable; }
            set
            {
                _birthNullable = value;
                _birth = (DateTime)_birthNullable;
            }
        }

        internal DateTime Birth
        {
            get { return _birth; }
        }

        internal bool? IsAdult
        {
            get { return _isAdult; }
        }

        internal void IsAdultFunction()
        {
            _isAdult = (((DateTime.Today - Birth).Days / 365) >= 18);
        }

        internal string SunSign
        {
            get { return _sunSign; }
        }

        internal string ChineseSign
        {
            get { return _chineseSign; }
        }

        internal bool? IsBirthday
        {
            get { return _isBirthday; }
        }

        internal void IsBirthdayFunction()
        {
            _isBirthday = _birth.Day == DateTime.Today.Day && _birth.Month == DateTime.Today.Month;
        }



        #endregion

        internal Person(string name, string surname, string email, DateTime birth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birth = birth;
        }

        internal Person(string name, string surname, string email) : this(name, surname, email, new DateTime())
        {
            
        }

        internal Person(string name, string surname, DateTime birth) : this(name, surname, null, birth)
        {
        }

        internal Person()
        {
        }
        /*internal string CalculateYourAge(DateTime Person)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Person).Ticks).Year - 1;
            DateTime PastYearDate = Person.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            Years, Months, Days, Hours, Seconds);
        }*/

        internal string CalculateSunSign()
        {
            int month = _birth.Month;
            int day = _birth.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return _sunSign = "Capricorn";
                    else
                        return _sunSign = "Aquarius";

                case 2:
                    if (day <= 18)
                        return _sunSign = "Aquarius";
                    else
                        return _sunSign = "Pisces";
                case 3:
                    if (day <= 20)
                        return _sunSign = "Pisces";
                    else
                        return _sunSign = "Aries";
                case 4:
                    if (day <= 19)
                        return _sunSign = "Aries";
                    else
                        return _sunSign = "Taurus";
                case 5:
                    if (day <= 20)
                        return _sunSign = "Taurus";
                    else
                        return _sunSign = "Gemini";
                case 6:
                    if (day <= 20)
                        return _sunSign = "Gemini";
                    else
                        return _sunSign = "Cancer";
                case 7:
                    if (day <= 22)
                        return _sunSign = "Cancer";
                    else
                        return _sunSign = "Leo";
                case 8:
                    if (day <= 22)
                        return _sunSign = _sunSign = "Leo";
                    else
                        return _sunSign = "Virgo";
                case 9:
                    if (day <= 22)
                        return _sunSign = "Virgo";
                    else
                        return _sunSign = "Libra";
                case 10:
                    if (day <= 23)
                        return _sunSign = "Libra";
                    else
                        return _sunSign = "Scorpio";
                case 11:
                    if (day <= 21)
                        return _sunSign = "Scorpio";
                    else
                        return _sunSign = "Sagittarius";
                case 12:
                    if (day <= 21)
                        return _sunSign = "Sagittarius";
                    else
                        return _sunSign = "Capricorn";
            }
            return _sunSign = "???";
        }

        internal string CalculateChineseSign()
        {
            System.Globalization.EastAsianLunisolarCalendar cc =
                  new System.Globalization.ChineseLunisolarCalendar();
            int sexagenaryYear = cc.GetSexagenaryYear(_birth);
            int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);

            string[] years = new string[] { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            return _chineseSign = years[terrestrialBranch - 1];
        }



        internal void ValidateBirthday()
        {
            if (Birth > DateTime.Today)
            {
                throw new FutureBirthException("Your date of birth is incorrect! You cannot born in future");
            }
            if (DateTime.Today.Year - Birth.Year > 135)
            {
                throw new PastBirthException("Your date of birth is incorrect! Your age is more than 135 years old");
            }
        }

        internal void Validate()
        {
            ValidateBirthday();
        }

       
    }
}
