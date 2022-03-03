using System;

namespace ExceptionHandlingLibrary
{
    public class InvalidWordLengthException:Exception
    {
        string message;
        public InvalidWordLengthException(string word, int neededLength)
        {
            message = $"Invalid Word Length Exception. Word Length should be {neededLength}, but you have {word.Length}";
        }
        public InvalidWordLengthException()
        {
            message = "Invalid Word Length Exception.";
        }       
        public InvalidWordLengthException(string mes)
        {
            message = mes;
        }
        public override string Message => message;
    }
}
