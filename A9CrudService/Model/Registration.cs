using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A9CrudService.Model
{
    /// <summary>
    /// // This tutrial is created by DotNettechy YouTube Channel
    ///  Video Link : https://youtu.be/4gYHNA9jkK0
    ///  Channel Link : https://www.youtube.com/channel/UCw_Sh-hhpXtF6lLLelhXIzg/videos
    ///
    /// </summary>
    public class Registration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }

    }
}
