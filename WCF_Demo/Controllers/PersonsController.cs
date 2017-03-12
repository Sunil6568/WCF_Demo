using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using MVC5Demo.TaskServiceClient;
using Person = WCF_Demo.Models.Person;

namespace WCF_Demo.Controllers
{
    public class PersonsController : Controller
    {
        public TaskServiceClient StClient;

        public PersonsController()
        {
            //WCF web service client intialization.

            StClient = new TaskServiceClient();
        }

        //
        // GET: /Persons/
        public ActionResult Index()
        {
          var personlist = StClient.GetAllTask();

            var lstRecord = personlist.Select(item => new Person
            {
                Id = item.Id,
                Fullname = item.Fullname,
                Age = item.Age,
                Profession = item.Profession
            }).ToList();
         
         return View(lstRecord);
         
        }


        // GET: /Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            var newPerson = new MVC5Demo.TaskServiceClient.Person
            {
                Age = person.Age,
                Fullname = person.Fullname,
                Id = person.Id,
                Profession = person.Profession
            };
            StClient.AddNew(newPerson);
            return RedirectToAction("Index");
        }


        // GET: /Persons/Edit/5
        public ActionResult Edit(int Id)
        {
            var person = StClient.GetTaskById(Id);
            if (person == null)
                return HttpNotFound();
            var editPerson = new Person
            {
                Age = person.Age,
                Fullname = person.Fullname,
                Id = person.Id,
                Profession = person.Profession
            };
            return View(editPerson);
        }

        ////
        // POST: /Persons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                var editPerson = new MVC5Demo.TaskServiceClient.Person
                {
                    Age = person.Age,
                    Fullname = person.Fullname,
                    Id = person.Id,
                    Profession = person.Profession
                };

                StClient.UpdateTaskAsync(editPerson);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        //
        // GET: /Persons/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var person = StClient.GetTaskById(id);
            if (person == null)
                return HttpNotFound();
            var deletePerson = new Person
            {
                Age = person.Age,
                Fullname = person.Fullname,
                Id = person.Id,
                Profession = person.Profession
            };
            return View(deletePerson);
        }

        //
        // POST: /Persons/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var person = StClient.GetTaskById(id);
                if (person == null)
                    return HttpNotFound();

                 StClient.DeleteTask(person);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
    }
}