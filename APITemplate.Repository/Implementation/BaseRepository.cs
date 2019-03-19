using API.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITemplate.Repository.Implementation
{
  public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
