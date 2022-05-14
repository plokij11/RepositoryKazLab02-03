using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazLab02.Exceptions
{
    internal class PastBirthException : Exception
    {
        private string _message;

        internal PastBirthException(string message)
        {
            _message = message;
        }

        public override string Message
        {
            get => _message;
        }
    }
}
