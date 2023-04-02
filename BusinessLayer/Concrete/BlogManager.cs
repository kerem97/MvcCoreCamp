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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogByCategory()
        {
            return _blogDal.GetListbyCategory();
        }
        public List<Blog> TGetListCategoryByAuthor(int id)
        {
            return _blogDal.GetListCategoryByAuthor(id);
        }
        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public Blog TGetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> TGetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public List<Blog> TGetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }
        public void TInsert(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetBlogListByAuthor(int id)
        {
            return _blogDal.GetListAll(x => x.AuthorID == id);
        }
    }
}
