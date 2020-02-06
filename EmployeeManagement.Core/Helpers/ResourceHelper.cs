using System.IO;
using System.Reflection;

namespace EmployeeManagement.Core.Helpers
{
    public static class ResourceHelper
    {
        public static string GetResourceValueByName(string resourceName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }
    }
}