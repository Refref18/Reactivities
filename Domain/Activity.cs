using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    { // Activites database with all below columns
        public Guid Id { get; set; } //prop yazarak direk oluşturduk: adına Id demezsen bunu primary olarak alamıyor ve hiç primary olmadığı için error alıuyoruz. 
        //Guid: if we create the id on client side we dont have to wait for the DB to create it we can only create it in client side
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }

    }
}