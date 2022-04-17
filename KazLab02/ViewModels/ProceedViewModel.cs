using KazLab02.Models;
using KazLab02.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KazLab02.ViewModels
{
    internal class ProceedViewModel
    {
        #region Fields
        private Person _person = new Person();

        #region Commands
        private RelayCommand<Object> _proceedCommand;
        #endregion
        #endregion

        #region Properties
        public string Name
        {
            get { return _person.Name; }
            set { _person.Name = value; }
        }
        public string Surname
        {
            get { return _person.Surname; }
            set { _person.Surname = value; }
        }
        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; }
        }
        public int Birth
        {
            get { return _person.Birth; }
            set { _person.Birth = value; }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(_ => Proceed(), CanExecute));
            }
        }


        #endregion
        private void Proceed()
        {
            MessageBox.Show($"Your name is {_person.Name}\n Your surname is {_person.Surname}\n Your email is {_person.Email}");
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_person.Name) &&
                   !String.IsNullOrWhiteSpace(_person.Surname) &&
                   !String.IsNullOrWhiteSpace(_person.Email);
                   //!String.IsNullOrWhiteSpace(_person.Birth);
            
        }

        
    }
}
