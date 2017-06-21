using System.Collections.Generic;
using GrandVisualFileReader.DataModel;

namespace GrandVisualFileReader.DAL
{
    public interface IReaderRepository
    {
        IList<Developer> GetAllDevelopers();

        IList<Developer> GetHighLevelDevelopers();
    }
}