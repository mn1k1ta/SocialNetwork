using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomService:IRoomService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDetails> CreateRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
                return new OperationDetails(false, "Room is NULL!","Room");
            var room = await _database.roomRepository
                .GetWhereAsync(u =>
            (u.FirstUserId == roomDTO.FirstUserId && u.SecondUserId == roomDTO.SecondUserId) ||
            (u.FirstUserId == roomDTO.SecondUserId && u.SecondUserId == roomDTO.FirstUserId));
            if (room.Count != 0)
                return new OperationDetails(false, "Room already is created!", "Room");
            try
            {
                Room room1 = new Room { FirstUserId = roomDTO.FirstUserId, SecondUserId = roomDTO.SecondUserId, Name = roomDTO.Name };
                _database.roomRepository.Create(room1);
                await _database.SaveAsync();
            }
            catch(Exception ex) { }
            return new OperationDetails(true, "Room is created!", "Room");
        }

        public async Task<RoomDTO> GetRoom(string firstUserId,string secondUserId)
        {
            var room = await _database.roomRepository
                .GetWhereAsync(u =>
            (u.FirstUserId == firstUserId && u.SecondUserId == secondUserId) ||
            (u.FirstUserId == secondUserId && u.SecondUserId == firstUserId));
            if (room.Count == 0)
                return null;
            return _mapper.Map<RoomDTO>(room.First());
        }
    }
}
