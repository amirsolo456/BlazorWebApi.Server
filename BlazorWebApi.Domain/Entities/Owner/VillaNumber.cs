using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شماره ویلا")]
        public int Villa_Number { get; set; }
        [ForeignKey("Villa")]
        public int VillaID { get; set; }
        public Villa Villa { get; set; }
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string? SpecialDetails { get; set; }
    }
}
