using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Complaints
{
    public class ComplaintAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Eğer şikayeti sisteme admin giriyorsa hangi kullanıcıya ait olduğunu seçmek isteyebilir.
        public Guid? UserId { get; set; }
    }
}
