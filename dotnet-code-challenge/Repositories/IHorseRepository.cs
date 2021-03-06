﻿using dotnet_code_challenge.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Repositories
{
    public interface IHorseRepository
    {
        /// <summary>
        /// load all horses from source
        /// </summary>
        /// <returns>horses from one source</returns>
        Task<IEnumerable<Horse>> LoadAllHorsesAsync();
    }
}
