using System;
using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("User [{UserName}]")]
    public class UserModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
