using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class OrgUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? DepartmentId { get; set; }
        [NotMapped]
        public OrgUnit Department { get; set; }

        public int? BusinessUnitId { get; set; }

        [NotMapped]
        public OrgUnit BusinessUnit { get; set; }

        public List<Furniture> Furnitures { get; set; } = new List<Furniture>();
    }
}
