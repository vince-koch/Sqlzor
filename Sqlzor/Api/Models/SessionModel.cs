using System;
using System.Data.Common;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Models;

namespace Sqlzor.Api.Models
{
    public class SessionModel
    {
        public Guid SessionId { get; set; }

        public string SessionName { get; set; }

        public IDatabaseDriver Driver { get; set; }

        public DbConnection Connetion { get; set; }

        public Node Schema { get; set; }
    }
}
