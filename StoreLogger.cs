using System.Linq;
using Serilog;

namespace InterfaceSegregation
{
    public class StoreLogger : IStoreLogger, IStoreWriter, IStoreReader
    {
        private readonly IStoreWriter writer;
        private readonly IStoreReader reader;

        public StoreLogger(IStoreWriter writer, IStoreReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }
        public virtual void Saving(int id, string message)
        {
            Log.Information("Saving message {id}.", id);
            this.writer.Save(id, message);
            Log.Information("Saved message {id}.", id);
        }

        public virtual void Saved(int id, string message)
        {
        }
        public virtual void Reading(int id)
        {
            Log.Debug("Reading message {id}.", id);
        }
        public virtual void DidNotFind(int id)
        {
            Log.Debug("Saving message {id}.", id);
        }
        public virtual void Returning(int id)
        {
            Log.Debug("Saving message {id}.", id);
        }

        public void Save(int id, string message)
        {
        }

        public Maybe<string> Read(int id)
        {
            Log.Debug("Reading message {id}.", id);
            var retVal = this.reader.Read(id);
            if (retVal.Any())
                Log.Debug("Returning message {id}",id);
            else
                Log.Debug("No message {id}",id);
            return retVal;
        }
    }
}