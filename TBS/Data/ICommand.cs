namespace TBS.Data
{
    public interface ICommand
    {
        void Execute(ISession db);
    }
}


