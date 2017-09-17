using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CodeFirstDemo.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }

        public string _Tags { get; set; }
        public string[] Tags
        {
            get { return _Tags == null ? null : JsonConvert.DeserializeObject<string[]>(_Tags); }
            set { _Tags = JsonConvert.SerializeObject(value); }
        }
        public string _Owner { get; set; }
        
        public Person[] Owner
        {
            get { return (this._Owner == null) ? null : JsonConvert.DeserializeObject<Person[]>(this._Owner); }
            set { _Owner = JsonConvert.SerializeObject(value); }
        }
    }

    public class Person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }

        public Person()
        {
            
        }
        
    }
}