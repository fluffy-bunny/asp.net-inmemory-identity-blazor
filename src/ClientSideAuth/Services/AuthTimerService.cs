using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientSideAuth.Services
{
    public class AuthTimerService : 
        IAuthHandlerHook
    {
        public AuthTimerService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        

        private Timer _timer;
        private IJSRuntime _jsRuntime;

        public Task OnAuthorizedCallAsync(long seconds)
        {
            if(_timer != null)
            {
                _timer.Dispose();
            }
            _timer = new Timer(TimerAction, null, seconds* 1000, seconds * 1000000);
            return Task.CompletedTask;
        }
        private void TimerAction(object state)
        {
            _jsRuntime.InvokeAsync<string>("reload").GetAwaiter().GetResult();
        }
    }
}
