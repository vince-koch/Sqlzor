using System;
using System.Collections.Generic;
using System.Data;

using Sqlzor.Api.Models;

namespace Sqlzor.Shared
{
    public class ClientStateModel
    {
        public Guid SessionId => Session != null ? Session.SessionId : Guid.Empty;

        public SessionModel Session { get; set; }

        public string QueryText { get; set; } = string.Empty;

        public int CursorX { get; set; } = 0;

        public int CursorY { get; set; } = 0;

        public bool IsBusy { get; set; } = false;
        
        public TimeSpan? Elapsed { get; set; } = null;
        
        public DataTable[] Tables { get; set; } = null;

        public Exception Error { get; set; } = null;

        public ClientStateModel(SessionModel session)
        {
            Session = session;
        }
    }
}