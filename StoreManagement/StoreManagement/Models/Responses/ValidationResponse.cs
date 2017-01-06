using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManagement.Models.Responses
{
    public class ValidationResponse
    {
        public string ValidationMessage { get; set; }
        public bool IsValid => string.IsNullOrWhiteSpace(ValidationMessage);

        public ValidationResponse() { }

        public ValidationResponse(string validationMessage)
        {
            ValidationMessage = validationMessage;
        }
    }
}