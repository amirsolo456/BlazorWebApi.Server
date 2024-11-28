using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface ICommentsService
    {
        public IEnumerable<Comments> getCommentsForVilla(int VillaID);
        public IEnumerable<Comments> getComentsForVillaByScore(int Score, int VillaID);

        //[Key]
        //public int ID { get; set; }
        //[Required]
        //public int VillaID { get; set; }
        //[ForeignKey(nameof(VillaNumber))]
        //public Villa villa { get; set; }
        //[Required]
        //[StringLength(200,ErrorMessage ="متن کامنت به درستی وارد نشده است")]
        //public string CommentText { get; set; }
        //[Required]
        //[Range(0,5,ErrorMessage ="مقدار امتیاز به درستی وارد نشده است")]
        //public int Score { get; set; }
        //[Required]
        //[Range(0,10,ErrorMessage ="نوع کاربر به درستی وارد نشده است")]
        //public int UserType { get; set; }
        //[Required]
        //[StringLength(30,ErrorMessage ="تاریخ ثبت به درستی وارد نشده است")]
        //public string CreateDate { get; set; }
        //[StringLength(30, ErrorMessage = "تاریخ بروزرسانی به درستی وارد نشده است")]
        //public string? UpdateDate { get; set; }

    }
}
