using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        readonly GenericRepository<Person> _genericRepository = new GenericRepository<Person>(new PersonsContext());

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}


        public List<Person> GetAll()
        {
         return _genericRepository.GetAll().ToList();
        }
        public Person GetDataUsingDataContract(Person composite)
        {
            
            return composite;
        }

        public List<Person> GetBooksList()
        {
            throw new NotImplementedException();
        }

        public Person GetBookById(int id)
        {
            var res = _genericRepository.GetById(id);
            return res;
        }

        public void AddBook(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(string id, string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(string id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetBooksNames()
        {
            throw new NotImplementedException();
        }

        //public string GetAll(int value)
        //{
        //    try
        //    {
        //        return _genericRepository.GetAll().ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
            
        //}
    }
}
