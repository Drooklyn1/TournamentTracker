using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Person
    {
        /// <summary>
        /// Unique ID of the Person
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// First name of the Person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the Person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the Person
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Cellphone number of the Person
        /// </summary>
        public string Cellphone { get; set; }

        /// <summary>
        /// Full name of the Person
        /// </summary>
        public string FullName { 
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }

        public Person()
        {

        }

        public Person(string firstName, string lastName, string email, string cellphone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Cellphone = cellphone;
        }

    }
}
