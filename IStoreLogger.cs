namespace InterfaceSegregation
{
    public interface IStoreLogger
    {
         void Saving(int id, string message);
         void Saved (int id, string message);
         void Reading(int id);
         void DidNotFind(int id);
         void Returning(int id);
    }
}