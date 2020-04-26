using System;
using System.IO;

namespace CommonLib.Helpers.JsonHelper
{
    public static class FileHelper
    {
        public static String GetText(String filePath)
        {
            String pathToSource = AppDomain.CurrentDomain.BaseDirectory + filePath;
            String data = File.ReadAllText(pathToSource);

            return data;
        }
    }
}
