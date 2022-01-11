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
    public class MessageManager : IMessageServices
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public Message GetById(int id)
        {
            return _messageDAL.Get(x=>x.MessageId == id);
        }

        public List<Message> GetListInbox(string p)
        {
            //burada tek bir kişiye göre işlem yapmak yerine kullanıcıya göre işlem yapmalıyız
            //buradaki p parametresini kullanabilmek için IMessageServices tarafındada değiştirmemiz gerekli
            return _messageDAL.List(x=>x.ReciverMail == p); //alıcı
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDAL.List(x => x.SenderMail == p); //göderen
        }

        public void MessageAdd(Message message)
        {
            _messageDAL.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDAL.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDAL.Update(message);
        }
    }
}
