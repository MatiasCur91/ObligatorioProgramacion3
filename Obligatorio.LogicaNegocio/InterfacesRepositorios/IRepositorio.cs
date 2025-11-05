using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {

        int Add(T nuevo);
        T FindById(int id);

        List<T> FindAll();

        void Remove(int id);

        void Update(T obj);


    }
}
