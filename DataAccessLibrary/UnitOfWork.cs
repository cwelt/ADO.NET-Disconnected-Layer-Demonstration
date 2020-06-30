using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataSet _dataSet;

        public IStudentRepository Students { get; private set; }

        public UnitOfWork(DataSet dataSet)
        {
            _dataSet = dataSet;

            Students = new StudentRepository(_dataSet);
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
