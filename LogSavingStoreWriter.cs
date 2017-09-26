using Serilog;

namespace InterfaceSegregation
{
    public class LogSavingStoreWriter : IStoreWriter
    {
        public void Save(int id, string message)
        {
            Log.Information("Saving message {id}.", id);
        }
    }
}