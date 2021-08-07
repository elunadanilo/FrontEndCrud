using PersonaFrontEnd.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaFrontEnd.Dao
{
    interface ICRUD<T>
    {
        Task<OperationResponse> GetAll();
        Task<OperationResponse> GetById(int id);
        Task<OperationResponse> Save(T t);
        Task<OperationResponse> Delete(int id);
        Task<OperationResponse> Update(int id, T t);
    }
}
