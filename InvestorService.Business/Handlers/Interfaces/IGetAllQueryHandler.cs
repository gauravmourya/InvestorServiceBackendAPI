namespace InvestorService.Business.Handlers.Interfaces
{
    public interface IGetAllQueryHandler<in Tin, out TOut>
    {
        TOut ExecuteQuery(Tin request);
    }

    public interface IGetAllQueryHandler<out TOut>
    {
        TOut ExecuteQuery();
    }
}
