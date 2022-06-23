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
    public class ImageFilesManager : IimageService
    {
        IimageFileDal _ıimageFileDal;

        public ImageFilesManager(IimageFileDal ıimageFileDal)
        {
            _ıimageFileDal = ıimageFileDal;
        }

        public List<ImageFile> GetList()
        {
            return _ıimageFileDal.List();
        }
    }
}
