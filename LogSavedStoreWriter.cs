using Serilog;

namespace InterfaceSegregation
{
    public class LogSavedStoreWriter : IStoreWriter
    {
        public void Save(int id, string message)
        {
            Log.Information("Saved message {id}",id);
        }
    }
}