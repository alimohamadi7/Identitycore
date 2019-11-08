using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public IEnumerable< IdentityError> Errordescription { set; get; }
    }
}