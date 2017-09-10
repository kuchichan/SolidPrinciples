using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using Serilog;
// Liskov substitution principle
// Signs that Liskov re not implemented:
// 1. NonSupportedExeption
// 2. IColletion<T> <---- ReadOnlyCollection throws notSupportedException while  adding element
// this breaks Liskov substitution exception
// 3. Downcasts
// 4. Extracted interfaces (watch out!) - almost always problematic
// LSP is often violated by attempts to remove features

namespace  InterfaceSegregation
{
    public class MessageStore
    {
        // reasons for change:
        // Logging ==> Different Class Storeogger
        // Caching
        // Storage
        // Orchestration
        public DirectoryInfo WorkingDirectory { get; private set; }
        private readonly StoreCache cache;
        private readonly StoreLogger log;

        private readonly IStore store;
        private readonly IFileLocator fileLocator;
        

        public MessageStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            this.WorkingDirectory = workingDirectory;
            this.cache = new StoreCache();
            this.log = new StoreLogger();
            this.store = new FileStore(workingDirectory);
        }

        public void Save(int id, string message)
        {
            this.Log.Saving(id, message);
            this.Store.Save(id, message);
            this.Cache.Save(id, message);
            this.Log.Saved(id, message);
        }
        
        
        public Maybe<string> Read(int id)
        {
            this.Log.Reading(id);
            var message = 
                this.Cache.GetOrAdd(id, _ => this.Store.ReadAllText(id));
            if(message.Any())
                this.Log.Returning(id);
            else
                this.Log.DidNotFind(id);
            return message;
        }

        public FileInfo GetFileInfo(int id)
        {
            return this.FileLocator.GetFileInfo(id);
        }

        // Factory properties

        protected virtual IStore Store
        {
            get {return this.store; }
        }

        protected virtual IStoreCache Cache
        {
            get { return this.cache; }
        }

        protected virtual IStoreLogger Log
        {
            get {return this.log ; }
        }

        protected virtual IFileLocator FileLocator 
        {
            get {return this.fileLocator;}
        }

    }
}