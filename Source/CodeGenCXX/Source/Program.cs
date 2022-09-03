using ClangSharp.Interop;
using System.Reflection;

namespace CodeGenCXX
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var exeAsm = Assembly.GetExecutingAssembly();
            var exeAsmFileInfo = new FileInfo(exeAsm.Location);
            var projDir = exeAsmFileInfo.Directory!.Parent!.Parent!.Parent!.Parent!;

            var headerFilePath = Path.Combine(projDir.FullName, "CXXClass.h");
            var sourceFilePath = Path.Combine(projDir.FullName, "CXXClass.cpp");

            if (!File.Exists(headerFilePath) ||
                !File.Exists(sourceFilePath))
            {
                Console.WriteLine("Not found C++ header and source.");
                return -1;
            }

            var headerRawStr = File.ReadAllText(headerFilePath);
            var sourceRawStr = File.ReadAllText(sourceFilePath);

            return 0;
        }
    }
}