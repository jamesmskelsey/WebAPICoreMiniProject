using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICoreMiniProject
{
    public class PersonModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool isActive { get; set; }

        public int Id { get; set; }

        public ICollection<AddressModel> Addresses { get; set; }
    }
}
