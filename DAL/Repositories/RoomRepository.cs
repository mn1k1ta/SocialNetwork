using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RoomRepository:BaseRepository<Room>,IRoomRepository 
    {
        public RoomRepository(DbContext context) : base(context)
        {

        }
    }
}
