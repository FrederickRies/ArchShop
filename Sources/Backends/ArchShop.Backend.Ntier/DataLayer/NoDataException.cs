using System;

namespace ArchShop.DataLayer
{
    public class NoDataException : Exception
    {
        public NoDataException(string message)
            : base(message)
        {

        }
    }
}
