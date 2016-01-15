using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicus.Finder.Models.DataObjects
{
    public class CubicalLocation
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CubicalLocationId { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [Required(ErrorMessage = "Building can't be blank")]
        public string Building { get; set; }

        //[Key]
        //[Column(Order = 2)]
        [Required(ErrorMessage = "Floor Number can't be blank")]
        [Display(Name = "Floor Number")]
        public int FloorNumber { get; set; }

        //[Key]
        //[Column(Order = 3)]
        [Required(ErrorMessage = "Desk Number can't be blank")]
        [StringLength(15, ErrorMessage = "Desk Number should contain less than 15 characters")]
        [Display(Name = "Desk Number")]
        public string DeskNumber { get; set; }

    //    public virtual Employee Employee { get; set; }
    }
}