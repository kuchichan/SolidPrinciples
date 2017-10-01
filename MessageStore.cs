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

        private readonly IFileLocator fileLocator;
        private readonly IStoreWriter writer;
        private readonly IStoreReader reader;

        public MessageStore(
            IStoreWriter writer,
            IStoreReader reader,
            IFileLocator fileLocator)
        {
            // Composite work very well in combination with commands
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (fileLocator == null)
                throw new ArgumentNullException("fileLocator");
            
            this.fileLocator = fileLocator;
            this.writer = writer;
            this.reader = reader;
        }
        // Composite Implementation of Save -> Adding IStoreWriter instance
        public void Save(int id, string message)
        {
            this.Writer.Save(id, message);
        }
        
        
        public Maybe<string> Read(int id)
        {
            return this.reader.Read(id);
        }

        public FileInfo GetFileInfo(int id)
        {
            return this.FileLocator.GetFileInfo(id);
        }

        // Factory properties

        protected virtual IFileLocator FileLocator 
        {
            get {return this.fileLocator;}
        }

        protected virtual IStoreWriter Writer
        {
            get { return this.writer;}
        }

        protected virtual IStoreReader Reader
        {
            get { return this.reader;}
        }
    }
}