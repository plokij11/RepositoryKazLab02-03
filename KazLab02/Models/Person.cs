using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazLab02.Models
{
    internal class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private int _birth;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }
        #endregion
    }
}
