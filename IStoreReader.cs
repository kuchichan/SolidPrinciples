namespace InterfaceSegregation
{
    public interface IStoreReader
    {
        Maybe<string> Read(int id);
    }
}