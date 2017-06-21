using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using GrandVisualFileReader.DataModel;
using Newtonsoft.Json;
using GrandVisualFileReader.Logger;

namespace GrandVisualFileReader.DAL
{
    public class FileReaderReporsitory : IReaderRepository
    {
        private IList<Developer> HighLevelDeveloper { get; set; } 

        public FileReaderReporsitory(IList<Developer> highLevelDeveloper)
        {
            HighLevelDeveloper = highLevelDeveloper;
        }
        public IList<Developer> GetAllDevelopers()
        {
            try
            {
                var filePath = HttpContext.Current.Server.MapPath("~\\App_Data\\developers.json");
                var readerTask = Task.Run(() => File.ReadAllText(filePath));
                readerTask.Wait();

                return JsonConvert.DeserializeObject<IList<Developer>>(readerTask.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Developer> GetHighLevelDevelopers()
        {
            try
            {
                var people = GetAllDevelopers();

                var highLevelDeveloperTask = Task.Run(() => GetHighLevelDevelopers(people));
                highLevelDeveloperTask.Wait();

                return highLevelDeveloperTask.Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Task<IList<Developer>> GetHighLevelDevelopers(IList<Developer> developers)
        {
            foreach (var developer in developers)
            {
                for (var i = developer.Skills.Count - 1; i >= 0; i--)
                {
                    var skill = (Skill)developer.Skills[i];

                    if (skill.Level < 8)
                    {
                        developer.Skills.RemoveAt(i);
                    }
                }
                if (developer.Skills.Count > 0)
                {
                    HighLevelDeveloper.Add(developer);
                }
            }

            return Task.FromResult(HighLevelDeveloper);
        }
    }
}
