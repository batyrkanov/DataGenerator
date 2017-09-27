using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Data;

namespace DataGenerator.Logic
{
    public class ScriptGenerator : IScriptGenerator
    {
#region Инъекция зависимостей методом создания конструктора

        private readonly IRepository _repository;
        private Random _random = new Random();

        public ScriptGenerator(IRepository repository)
        {
            _repository = repository;
        }
        #endregion

#region method MergeLines generated users, get values and insert that values to method CreateScript
        public string CreateScript(int entityCount)
        {
            IEnumerable<UserEntity> users = Enumerable.Repeat(GenerateUser(), entityCount);
            IEnumerable<string> valueLines = users.Select(GetValueLine);
            string insertLine = GetInsertLine();

            string result = MergeLines(valueLines, insertLine);
             
            return result;

        }

        internal string MergeLines(IEnumerable<string> valueLines, string insertLine)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(insertLine);

            int i = 0;
            foreach ( var valueLine in valueLines)
            {
                if (i > 0) builder.Append(",");
                builder.AppendLine(valueLine);
                i++;
            }

            return builder.ToString();
        }
#endregion

        public UserEntity GenerateUser()
        {
            UserEntity entity = new UserEntity();

            entity.Login = _repository.GetRandomUniqLogin();
            entity.Name = _repository.GetRandomEmailDomain();
            entity.Surname = _repository.GetRandomSurname();
            entity.Patronymic = _repository.GetRandomPatronymic();
            
            string randomEmailDomain = _repository.GetRandomEmailDomain();

            entity.Email = $"{entity.Login}@{randomEmailDomain}";
            entity.Password = _random.Next(1000, 10000).ToString();

            int year = _random.Next(2010, 2017);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, 29);
            if (year == 2016 && month > 2) month = 2;
            entity.RegistrationDate = new DateTime(year, month, day);

            return entity;

        }

        public string GetInsertLine()
        {
            return @"INSERT INTO BlogUser ('Name', 'Surname', 'Patronymic', 'Login', 'Password', 'Email', 'RegistrationDate')";
        }

        public string GetValueLine(UserEntity entity)
        {
            string registrationDate = entity.RegistrationDate.ToString("yyyyMMdd");
            string result = $"VALUES ('{entity.Name}', '{entity.Surname}', '{entity.Patronymic}', '{entity.Login}', '{entity.Password}', '{entity.Email}', '{registrationDate}')";
            return result;
        }
    }
}
