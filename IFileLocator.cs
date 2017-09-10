using System.IO;

namespace InterfaceSegregation
{
    public interface IFileLocator
    {
         FileInfo GetFileInfo(int id);
    }
}