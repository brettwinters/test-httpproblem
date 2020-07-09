using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace BlazorApp1.Pages
{
    public class ActionHandler
    {
        [ReducerMethod]
        public static FetchingState Reduce(
            FetchingState state,
            IsFetchingAction action)
        {
            return new FetchingState(isFetching: true);
        }

        [ReducerMethod]
        public static FetchingState Reduce(
            FetchingState state,
            HasFetchedAction action)
        {
            return new FetchingState(isFetching: false);
        }
    }
}
