using System.Data.Entity;
using TaskList_Service.Model;

namespace TaskList_Service
{
    public class PersonsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
      
        public PersonsContext() : base("name=PersonsContext")
        {
        }

        public DbSet<Person> People { get; set; }

    }
}