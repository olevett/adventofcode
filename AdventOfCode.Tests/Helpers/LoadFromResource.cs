using System.IO;
using System.Reflection;

namespace AdventOfCode.Tests.Helpers
{
    public class LoadFromResource
    {
        public static string Load(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
