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
        private ScriptGenerator _generator;
        [SetUp]
        public void Init()
        {
            IRepository repository = new RepositoryMock();
            _generator = new ScriptGenerator(repository);
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
        [Repeat(10000)]
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
        [Repeat(10000)]
        public void GenerateUser_RegistrationDatePeriod()
        {
            UserEntity entity = _generator.GenerateUser();
            DateTime registrationDate = entity.RegistrationDate;

            Assert.That(registrationDate, Is.InRange(new DateTime(2010, 1, 1), new DateTime(2016, 2, 29)));
        }

        [Test]
        public void GenerateUser_GetValueLine()
        {
            UserEntity user = new UserEntity() { Name = "Вася", Surname = "Васильев", Patronymic = "Васильевич", Login = "vasya", Password = "4566", Email = "vasya@test.ru", RegistrationDate = new DateTime(2015, 01, 01) };
            const string EXPECTED_RESULT = @"VALUES ('Вася', 'Васильев', 'Васильевич', 'vasya', '4566', 'vasya@test.ru', '20150101')";

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

        [Test]
        public void MergeLines_Test()
        {
            const string INSERT_LINE = "INSERT LINE";
            string[] valueLines = { "VALUE LINE 1", "VALUE LINE 2" };
            string expectedResult = $"INSERT LINE{Environment.NewLine}VALUE LINE 1{Environment.NewLine},VALUE LINE 2{Environment.NewLine}";

            string result = _generator.MergeLines(valueLines, INSERT_LINE);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
