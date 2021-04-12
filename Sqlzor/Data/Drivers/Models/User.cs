using System;
using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Users")]
    [DebuggerDisplay("User [{UserName}]")]
    public class User
    {
        [SchemaColumn("UID")]
        public string Id { get; set; }

        [SchemaColumn("USER_NAME")]
        public string UserName { get; set; }

        [SchemaColumn("CREATEDATE")]
        public DateTime CreateDate { get; set; }

        [SchemaColumn("UPDATEDATE")]
        public DateTime UpdateDate { get; set; }
    }
}
