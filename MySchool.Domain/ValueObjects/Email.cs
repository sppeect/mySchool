using Flunt.Validations;
using MySchool.Common.ValueObjects;

namespace MySchool.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Email>()
                .Requires()
                .IsEmail(Address, "Email.Address", "E-mail Invalido")
                );
        }

        public string Address { get; set; }
    }




}
