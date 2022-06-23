using BusinessLayes.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Concreate
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }
        
        public List<Message> GetListInbox(string receiver)
        {
            return _messageDal.List(x => x.ReceiverMail == receiver);
        }

       

        public List<Message> GetListSendbox(string sender)
        {
            return _messageDal.List(x => x.SenderMail == sender);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }
        

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
