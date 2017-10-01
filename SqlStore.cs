using System;
using System.IO;

namespace InterfaceSegregation
{
    public class SqlStore : IStore
    {
        public  void Save(int id, string message)
        {
           // Wrte to database here 
        }

        public  Maybe<string> Read(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}