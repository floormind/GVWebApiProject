using System;
using System.IO;
using System.Web;

namespace GrandVisualFileReader.Logger
{
    public class SimpleLogger : IDalLogger
    {
        public void LogError(Exception ex)
        {
            var path = HttpContext.Current.Server.MapPath("~\\App_Data\\log.txt");

            using (var writer = File.AppendText(path))
            {
               writer.WriteLine($"An error occured. Date: {DateTime.Now}, Message: {ex.Message}, Source: {ex.Source}");
            }
        }
    }
}
