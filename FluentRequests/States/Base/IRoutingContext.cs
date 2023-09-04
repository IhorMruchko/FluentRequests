namespace FluentRequests.Lib.States.Base
{
    internal interface IRoutingContext
    {
        RoutingState State { get; }
        
        void ChangeState(RoutingState newState);
    }
}
