using System;

namespace Pharmacy.Core.Models
{
    public abstract class PharmacyException : Exception
    {
        public string Code { get; }

        protected PharmacyException()
        {
        }

        protected PharmacyException(string code)
        {
            Code = code;
        }

        protected PharmacyException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected PharmacyException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected PharmacyException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected PharmacyException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}