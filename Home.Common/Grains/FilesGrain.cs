using System;
using System.Collections.Generic;
using System.Linq;
using Home.Common.DAL;
using Home.Common.Models;

namespace Home.Common.Grains
{
    public class FilesGrain : IFilesGrain
    {
        private List<Files> files;
        private IDAL dal;

        public FilesGrain(IDAL pDal)
        {
            this.dal = pDal;
            this.files = dal.FindAll<Files>();
        }

        public void Delete(int id)
        {
            this.dal.Delete<Files>(id);

            var salesOrder = this.files.FirstOrDefault(p => p.Id.Equals(id));
            if (salesOrder != null)
                this.files.Remove(salesOrder);
        }

        public Files Find(int id)
        {
            var file = this.files.FirstOrDefault(p => p.Id.Equals(id));

            return file;
        }

        public List<Files> FindAll()
        {
            return this.files;
        }

        public void Insert(Files t)
        {
            if (this.files.Exists(p => p.Id.Equals(t.Id)) && t.Id > 0)
                throw new Exception("This file already exists");
            int newId = this.dal.Insert<Files>(t);
            t.Id = newId;
            this.files.Add(t);
        }
    }
}