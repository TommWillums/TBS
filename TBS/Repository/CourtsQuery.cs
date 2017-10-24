﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBS.Domain;
using TBS.Persistence;

namespace TBS.Repository
{
    public class CourtsQuery
    {
        public async Task<List<Court>> GetAll(int clubId)
        {
            return await CourtsDb.GetAll(clubId);
        }

        public async Task<List<Court>> GetActive(int clubId)
        {
            List<Court> list = await GetAll(clubId);
            return list.FindAll(c => c.Active);
        }

    }

}
