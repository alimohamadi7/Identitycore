using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.filter
{
    public static class ContentTypeOptionsConstants
    {
        /// <summary>
        /// Header value for X-Content-Type-Options
        /// </summary>
        public static readonly string Header = "X-Content-Type-Options";

        /// <summary>
        /// Disables content sniffing
        /// </summary>
        public static readonly string NoSniff = "nosniff";

    }
}
