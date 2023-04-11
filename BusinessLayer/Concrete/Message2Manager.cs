using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        private readonly IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public List<Message2> GetInboxListByAuthor(int id)
        {
            return _message2Dal.GetMessageListWithByAuthor(id);
        }

        public List<Message2> GetSendboxByAuthor(int id)
        {
            return _message2Dal.GetSendboxByAuthor(id);
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetByID(int id)
        {
            return _message2Dal.GetByID(id);
        }

        public List<Message2> TGetList()
        {
            return _message2Dal.GetListAll();
        }

        public void TInsert(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void TUpdate(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
