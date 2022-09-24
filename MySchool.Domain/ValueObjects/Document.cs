using Flunt.Validations;
using MySchool.Common.Enums;
using MySchool.Common.ValueObjects;
using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Validations;
using MySchool.Common.Enums;
using MySchool.Common.ValueObjects;

namespace MySchool.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Document>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Document Invalido")
                );

           
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14) 
            {
                return true;
            }
            if(Type == EDocumentType.CPF && Number.Length == 11)
            {
                return true;
            }
            return false;
        }
    }
}
