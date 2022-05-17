using KazLab02.Models;
using KazLab02.Tools;
using KazLab02.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace KazLab02.ViewModels    
{
    internal class ProceedViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
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

        public DateTime? BirthNullable
        {
            get { return _person.BirthNullable; }
            set  {  _person.BirthNullable = value;  }
        }
        
        public bool? IsAdult
        {
            get { return _person.IsAdult; }
        }
        public string SunSign
        {
            get { return _person.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person.ChineseSign; }
        }
        public bool? IsBirthday
        {
            get { return _person.IsBirthday; }
        }
        #endregion

        
        


        private async void Proceed()
        {
            await Task.Run(() => Thread.Sleep(500));

            _person.IsBirthdayFunction();
            _person.IsAdultFunction();

            try
            {
                _person.Validate();
            }
            catch (FutureBirthException e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            catch (PastBirthException e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            catch (BadEmailException e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            await Task.Run(() =>
            {
                _person.CalculateSunSign();
                _person.CalculateChineseSign();
                _person.IsBirthdayFunction();
                _person.IsAdultFunction();
            });
            
            

            OnPropertyChanged(nameof(BirthNullable));
            OnPropertyChanged(nameof(IsAdult));
            OnPropertyChanged(nameof(IsBirthday));
            OnPropertyChanged(nameof(SunSign));
            OnPropertyChanged(nameof(ChineseSign));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));

            if ((bool)IsBirthday)
                MessageBox.Show("Congratulations! Today is your Birthday! Best wishes :)");
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(_ => Proceed(), CanExecute));
            }
        }

        private bool CanExecute(object obj) => !String.IsNullOrWhiteSpace(Name) &&
                                               !String.IsNullOrWhiteSpace(Surname) &&
                                               !String.IsNullOrWhiteSpace(Email) &&
                                               BirthNullable!= null;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
}
