using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Czat_SignalR
{
    
    public class ChatHub : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.All.user(Context.User.Identity.Name);
            return base.OnConnected();
        }
        public void send(string message)
        {
            Clients.Caller.message("You: " + message);
            Clients.Others.message(Context.User.Identity.Name + ": " + message);
        }


    }
    [HubName("hitCounter")]
    public class HitCounterHub : Hub
    {
        private static int _hitCount = 0;
        public void RecordHit()
        {
            _hitCount += 1;
            this.Clients.All.onRecordHit(_hitCount);
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            _hitCount -= 1;
            this.Clients.All.onRecordHit(_hitCount);
            return base.OnDisconnected(stopCalled);
        }
    }
}