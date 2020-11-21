using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Meeting.Api
{
    public class MeetingHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}