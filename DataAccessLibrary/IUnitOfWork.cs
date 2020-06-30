using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }

        int Update();
    }
}
