using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpaceRequestDataModel
{
  public  class viewuserid
    {
        [Key]
        public string SSN { get; set; }
        public string Userid { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string username { get; set; }
        public string ghcuserid { get; set; }

    }
}
