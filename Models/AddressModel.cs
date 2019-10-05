using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICoreMiniProject
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        public PersonModel Person { get; set; }
        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
