﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Data;

namespace DataGenerator.Logic
{
    public interface IScriptGenerator
    {
        UserEntity GenerateUser();
        string GetValueLine(UserEntity entity);
        string GetInsertLine();
        string CreateScript(int entityCount); 
    }
}
