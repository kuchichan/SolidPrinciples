using System.IO;

namespace InterfaceSegregation
{
    public interface IStore
    {
         void Save(int id, string message);

        // Remove the GetFileInfo because it is impossible to implement correctly this method is nace of eg. SQL Database
        // We have another role interface IFileLocator that gives us possibility to to gt rid of this method
        //FileInfo GetFileInfo(int id);
    }
}