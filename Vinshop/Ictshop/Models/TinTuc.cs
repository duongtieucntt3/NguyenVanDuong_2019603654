namespace Ictshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("TinTuc")]
    public partial class TinTuc
    {        

        [Key]
        public int maTinTuc { get; set; }

        [StringLength(225)]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề bắt buộc nhập")]

        public string tieuDe { get; set; }        
        
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Nội dung bắt buộc nhập")]
        [AllowHtml]

        public string noiDung { get; set; }
        [Display(Name = "Ngày phát hành")]

        public DateTime? ngayphatHanh { get; set; }

        [Display(Name = "Ảnh")]

       
        public string anh { get; set; }
    }
}
