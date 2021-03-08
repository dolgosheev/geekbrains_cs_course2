using System;
using System.Windows.Forms;

namespace AteroidsGame.Exceptions
{
    internal class InitializeException : ApplicationException
    {
        private readonly Form _form;

        public InitializeException(Form form,string message) : base(message)
        {
            _form = form;
        }

        public Form Form => _form;
    }
}
