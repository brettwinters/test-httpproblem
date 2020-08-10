using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace BlazorApp1.Pages
{
    public class ActionHandler
    {

        public ActionHandler()
        {
        }

        [EffectMethod]
        public Task Effect(
            NonAsyncAction action,
            IDispatcher dispatcher)
        {
            throw new InvalidOperationException();
        }

        [EffectMethod]
        public async Task Effect(
            AsyncAction action,
            IDispatcher dispatcher)
        {
            await Task.Delay(500);
            throw new InvalidOperationException();     
        }
    }
}
