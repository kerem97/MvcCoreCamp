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
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void TDelete(NewsLetter t)
        {
            throw new NotImplementedException();
        }

        public NewsLetter TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(NewsLetter t)
        {
            _newsLetterDal.Insert(t);
        }

        public void TUpdate(NewsLetter t)
        {
            throw new NotImplementedException();
        }
    }
}
