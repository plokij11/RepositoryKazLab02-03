using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazLab02.Exceptions
{
    internal class FutureBirthException : Exception
    {
        private string _message;

        internal FutureBirthException(string message)
        {
            _message = message;
        }

        public override string Message
        {
            get => _message;
        }
    }
}
