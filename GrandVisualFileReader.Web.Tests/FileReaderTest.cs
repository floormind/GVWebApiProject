using System.Collections.Generic;
using GrandVisualFileReader.DataModel;
using GrandVisualFileReader.DAL;
using GrandVisualFileReader.Logger;
using GrandVisualFileReader.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace GrandVisualFileReader.Web.Tests
{
    [TestFixture]
    public class FileReaderTest
    {
        private Mock<IReaderRepository> _readerRepo;
        private Mock<IDalLogger> _logger; 
        private FileController _fileController;
        private List<Developer> _allPeople;

        [OneTimeSetUp]
        public void SetUp()
        {
            _readerRepo = new Mock<IReaderRepository>();
            _logger = new Mock<IDalLogger>();

            _fileController = new FileController(_readerRepo.Object, _logger.Object);
        }

        [Test]
        public void GetAllData_Returns_All_People_From_File_With_Data()
        {
            //arrange
            _allPeople = new List<Developer>()
            {
                new Developer()
                {
                    FirstName = "Ife",
                    LastName = "Ayelabola",
                    Age = 16,
                    Skills = new List<Skill>()
                    {
                        new Skill()
                        {
                            Level = 9,
                            Type = "backend",
                            Name = "C#"
                        },
                        new Skill()
                        {
                            Level = 9,
                            Type = "frontend",
                            Name = "javascript"
                        }
                    }
                },
                new Developer()
                {
                    FirstName = "Oliver",
                    LastName = "Dowler",
                    Age = 20,
                    Skills = new List<Skill>()
                    {
                        new Skill()
                        {
                            Level = 10,
                            Type = "backend",
                            Name = "C#"
                        },
                        new Skill()
                        {
                            Level = 10,
                            Type = "frontend",
                            Name = "javascript"
                        }
                    }
                }
            };

            _readerRepo
                .Setup(r => r.GetAllDevelopers())
                .Returns(_allPeople);

            //act
            var people = _fileController.GetAllDevelopers();

            //assert
            Assert.That(people, Has.None.Null);
            Assert.That(people.Count, Is.EqualTo(2));
        }


        [Test]
        public void GetAllData_Returns_All_People_From_File_Without_Data()
        {
            //arrange 
            _allPeople = null;

            _readerRepo
                .Setup(r => r.GetAllDevelopers())
                .Returns(_allPeople);

            //act
            var people = _fileController.GetAllDevelopers();

            //assert
            Assert.That(people, Is.Null);
        }

        //repeat similar test for GetHighLevelPeople
    }
}
