using System.IO;
using System.Reflection;

namespace BinaryTreeAssestment.InputProviders
{
    public class FileDataManager : InputDataManager
    {
        private int Index { get; set; }
        private string[] FileContent { get; set; }

        public FileDataManager(string filePath)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            Index = 0;
            FileContent = File.ReadAllLines(path);
        }

        public override string ReadLine()
        {
            return Index < FileContent.Length ? FileContent[Index++] : null;
        }
    }
}
