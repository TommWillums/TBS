namespace TBS.Data
{
    public interface IQuery<T>
    {
        T Execute(ISession db);
    }
}
