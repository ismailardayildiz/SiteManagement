using SiteManagement.Entity.DTOs.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Sites
{
    public class SiteAddDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ManagerAddDto? Manager { get; set; }
    }
}
