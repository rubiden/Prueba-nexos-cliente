using Moq;
using Nexos.Cliente.Domain.Core.Models;
using Nexos.Cliente.Domain.Core.Services;
using Nexos.Cliente.Domain.Core.Services.InterfaceRepository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Test
{
    [TestFixture]
    public class AutorTest
    {
        private Mock<IWriteableAutorRepository> _mockWriteableAutorRepository;
        private Mock<IReadableAutorRepository> _mockReadableAutorRepository;
        private Mock<IRemovableAutorRepository> _mockRemovableAutorRepository;
        private Autor autor;
        private IEnumerable<Autor> autores;
        private int id;

        [SetUp]
        public void Setup()
        {
            _mockWriteableAutorRepository = new Mock<IWriteableAutorRepository>();
            _mockReadableAutorRepository = new Mock<IReadableAutorRepository>();
            _mockRemovableAutorRepository = new Mock<IRemovableAutorRepository>();

            autor = new Autor()
            {
                Id = 1,
                NombreCompleto = "Nombre test",
                CiudadNacimiento = "Ciudad test",
                Email = "email@mail.com",
                FechaNacimiento = DateTime.Now.Date
            };

            autores = new List<Autor>()
            {
                autor
            };
            id = 1;
        }

        [Test]
        public void GetAutoresTest()
        {
            _mockReadableAutorRepository.Setup(x => x.GetAutores()).Returns(Task.FromResult(autores));
            AutorService autorService = new AutorService(_mockWriteableAutorRepository.Object, _mockReadableAutorRepository.Object, _mockRemovableAutorRepository.Object);
            Task<IEnumerable<Autor>> respuesta = autorService.GetAutores();
            Assert.IsInstanceOf(new object().GetType(), respuesta);
            Assert.IsTrue(respuesta != null);
            Assert.IsTrue(respuesta.Result.Any());
        }

        [Test]
        public void GetAutorByIdTest()
        {
            _mockReadableAutorRepository.Setup(x => x.GetAutorById(id)).Returns(Task.FromResult(autor));
            AutorService autorService = new AutorService(_mockWriteableAutorRepository.Object, _mockReadableAutorRepository.Object, _mockRemovableAutorRepository.Object);
            Task<Autor> respuesta = autorService.GetAutorById(id);
            Assert.IsInstanceOf(new object().GetType(), respuesta);
            Assert.IsTrue(respuesta != null);
            Assert.IsTrue(respuesta.Result != null);
        }

        [Test]
        public void PostAutorTest()
        {
            _mockWriteableAutorRepository.Setup(x => x.PostAutor(autor)).Returns(Task.FromResult(id));
            AutorService autorService = new AutorService(_mockWriteableAutorRepository.Object, _mockReadableAutorRepository.Object, _mockRemovableAutorRepository.Object);
            Task<int> respuesta = autorService.PostAutor(autor);
            Assert.IsInstanceOf(new object().GetType(), respuesta);
            Assert.IsTrue(respuesta != null);
            Assert.IsTrue(respuesta.Result > 0);
        }

        [Test]
        public void PutAutorTest()
        {
            _mockWriteableAutorRepository.Setup(x => x.PutAutor(autor)).Returns(Task.FromResult(id));
            AutorService autorService = new AutorService(_mockWriteableAutorRepository.Object, _mockReadableAutorRepository.Object, _mockRemovableAutorRepository.Object);
            Task<int> respuesta = autorService.PostAutor(autor);
            Assert.IsInstanceOf(new object().GetType(), respuesta);
            Assert.IsTrue(respuesta != null);
            Assert.IsTrue(respuesta.Result == 0);
        }

        [Test]
        public void DeleteAutorTest()
        {
            _mockRemovableAutorRepository.Setup(x => x.DeleteAutor(autor)).Returns(Task.FromResult(id));
            AutorService autorService = new AutorService(_mockWriteableAutorRepository.Object, _mockReadableAutorRepository.Object, _mockRemovableAutorRepository.Object);
            Task<int> respuesta = autorService.DeleteAutor(id);
            Assert.IsInstanceOf(new object().GetType(), respuesta);
            Assert.IsTrue(respuesta != null);
            Assert.IsTrue(respuesta.Result == 0);
        }
    }
}
