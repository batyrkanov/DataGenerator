using DataGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Logic.Test
{
    /// <summary>
    /// fake class for IRepository
    /// </summary>
    public class RepositoryMock : IRepository
    {
        public string GetRandomEmailDomain()
        {
            return "test.ru";
        }

        public string GetRandomName()
        {
            return "Василий";
        }

        public string GetRandomPatronymic()
        {
            return "Васильевич";
        }

        public string GetRandomSurname()
        {
            return "Васильев";
        }

        public string GetRandomUniqLogin()
        {
            return "vasya";
        }

        public void Init()
        {
        }
    }
}
