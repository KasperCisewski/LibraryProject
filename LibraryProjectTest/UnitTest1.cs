using System;
using System.Collections.Generic;
using LibraryProject.Builders;
using LibraryProject.Model;
using LibraryProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace LibraryProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IBookValidator> _bookValidator;
        private Mock<IPersonRepository> _personRepository;
        private Mock<IPersonValidator> _personValidator;
        private LibraryService libraryService;

        public void Init()
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookValidator = new Mock<IBookValidator>();
            _personRepository = new Mock<IPersonRepository>();
            _personValidator = new Mock<IPersonValidator>();
            libraryService = new LibraryService(_bookRepository.Object,_bookValidator.Object,_personRepository.Object,_personValidator.Object);
        }

    }
}
