using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Data;
using DataGenerator.Logic;

namespace DataGenerator.Logic.Test
{
    [TestFixture]
    class ScriptGeneratorTest
    {
        private IScriptGenerator _generator;
        [SetUp]
        public void Init()
        {
            _generator = null;
        }

        [Test]
        public void GenerateUser_NameRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string name = entity.Name;

            Assert.That(name, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_SurnameRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string surname = entity.Surname;

            Assert.That(surname, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_PatronymicRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string patronymic = entity.Patronymic;

            Assert.That(patronymic, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_LoginRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string login = entity.Login;

            Assert.That(login, Is.Not.Empty);
        }


        [Test]
        public void GenerateUser_PasswordRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string password = entity.Password;

            Assert.That(password, Is.Not.Empty);
        }

        [Test]
        public void GenerateUser_EmailRequired()
        {
            UserEntity entity = _generator.GenerateUser();
            string email = entity.Email;

            Assert.That(email, Is.Not.Empty);
        }


        [Test]
        public void GenerateUser_RegistrationDatePeriod()
        {
            UserEntity entity = _generator.GenerateUser();
            DateTime registrationDate = entity.RegistrationDate;

            Assert.That(registrationDate, Is.InRange(new DateTime(2010, 1, 1), new DateTime(2017, 1, 29)));
        }

        [Test]
        public void GenerateUser_GetValueLine()
        {
            UserEntity user = new UserEntity() { Name = "AD", Surname = "ADad", Patronymic = "ADasd", Login = "ADasd@gmail.com", Password = "AASDASDSDD", Email = "ADd@gmail.com", RegistrationDate = new DateTime(2015, 1, 1) };
            const string EXPECTED_RESULT = @"VALUES ('AD', 'ADad', 'ADasd', 'ADasd@gmail.com', 'AASDASDSDD', 'ADd@gmail.com', '20150101')";

            string result = _generator.GetValueLine(user);

            Assert.That(result, Is.EqualTo(EXPECTED_RESULT));
        }

        [Test]
        public void GenerateUser_GetInsertLine()
        {
            const string EXPECTED_RESULT = @"INSERT INTO BlogUser ('Name', 'Surname', 'Patronymic', 'Login', 'Password', 'Email', 'RegistrationDate')";

            string result = _generator.GenInsertLine();

            Assert.That(result, Is.EqualTo(EXPECTED_RESULT));
        }
    }
}
