using Flunt.Validations;
using MySchool.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Domain.ValueObjects
{
    public class Email: ValueObject
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
