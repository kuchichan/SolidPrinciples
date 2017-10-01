using System;

namespace InterfaceSegregation
{
    public interface IStoreCache
    {
         void Save(int id, string message);
         Maybe<string> Read(int id);
    }
}