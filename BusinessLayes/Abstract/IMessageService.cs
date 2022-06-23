using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Abstract
{
   public interface IMessageService
    {

        List<Message> GetListInbox(string receiver);
        List<Message> GetListSendbox(string sender);
        void MessageAdd(Message message);

        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
