using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLMvc.Infrastructure
{
    public class EditPassword : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((string)value) || ((string)value).Length > 5)
                return true;
            return false;
        }
    }
}