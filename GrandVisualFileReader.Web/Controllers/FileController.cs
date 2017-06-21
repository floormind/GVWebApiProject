using System;
using System.Collections.Generic;
using System.Web.Http;
using GrandVisualFileReader.DataModel;
using GrandVisualFileReader.DAL;
using GrandVisualFileReader.Logger;

namespace GrandVisualFileReader.Web.Controllers
{
    public class FileController : ApiController
    {
        private IReaderRepository ReaderRepository { get; set; }
        private IDalLogger Logger { get; set; }
        public FileController(IReaderRepository readerRepository, IDalLogger logger)
        {
            ReaderRepository = readerRepository;
            Logger = logger;
        }

        [Route("file/GetAllDevelopers")]
        public IList<Developer> GetAllDevelopers()
        {
            try
            {
                return ReaderRepository.GetAllDevelopers();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }


        [Route("file/GetHighLevelDevelopers")]
        public IList<Developer> GetHighLevelDevelopers()
        {
            try
            {
                return ReaderRepository.GetHighLevelDevelopers();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
