using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class Villa
    {

        public int ID { get; set; }
        [Display(Name = "نام ویلا")]
        [StringLength(30)]
        public required string Name { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "قیمت برای هرشب")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Display(Name = "مساحت")]
        [Range(10, 10000)]
        public int Sqft { get; set; }
        [Display(Name = "تعداد اتاق")]
        [Range(0, 10)]
        public int Occupancy { get; set; }

        public string? ImageUrl { get; set; }
        [MaxLength(30)]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [DataType(DataType.DateTime)]
        [MaxLength(30)]
        public DateTime? UpdateDate { get; set; }
        public bool Jacuzzi { get; set; } = false;
        public bool Swimmingpool { get; set; } = false;
        public bool Parking { get; set; } = false;
        public bool Guestroom { get; set; } = false;

    }
}
