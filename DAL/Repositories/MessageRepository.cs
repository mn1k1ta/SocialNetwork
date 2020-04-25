using DAL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class MessageRepository : BaseRepository<Message>,IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {

        }
    }
}
