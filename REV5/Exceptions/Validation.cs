using System;

namespace REV5.Exceptions
{
    public class Validation : Exception
    {
        public Validation(string message) : base(message)
        {
        }
    }
}