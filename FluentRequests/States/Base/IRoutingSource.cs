namespace FluentRequests.Lib.States.Base
{
    internal interface IRoutingSource
    {
        RoutingState CurrentState { get; }


        RoutingState ChangeState(RoutingState currentState, float increment=0);
    }
}