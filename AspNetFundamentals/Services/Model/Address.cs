using System;
namespace AspNetFundamentals.Services.Model
{
    public class Address
    {
        internal Address(string addressLine)
        {
            AddressLine = addressLine;
        }
        public string AddressLine { get; set; }
        public static Address Create(string addressLine)
        {
            if (string.IsNullOrEmpty(addressLine)) throw new ArgumentNullException(nameof(addressLine));
            return new Address(addressLine);
        }
    }
}
