using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using TaskList_Service.Model;

namespace TaskList_Service
{
    public class TaskService : ITaskService
    {
        private readonly GenericRepository<Person> _genericRepository;

        public TaskService()
        {
            _genericRepository = new GenericRepository<Person>(new PersonsContext());
        }

        public List<Person> GetAllTask()
        {
            List<Person> restPersons;
            try
            {
                restPersons = _genericRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
               throw e;
            }
            return restPersons;
        }


        public Person GetTaskById(int id)
        {
            var res = _genericRepository.GetById(id);
            return res;
        }


      
        public bool AddNew(Person task)
        {
            try
            {
                _genericRepository.InsertAsync(task);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                    (ex.Message);
            }
            return true;
        }

        public void UpdateTask(Person task)
        {
            try
            {
                _genericRepository.EditAsync(task);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                    (ex.Message);
            }
        }

        public void DeleteTask(Person task)
        {
            try
            {
                _genericRepository.DeleteAsync(task);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                    (ex.Message);
            }
        }
    }
}
