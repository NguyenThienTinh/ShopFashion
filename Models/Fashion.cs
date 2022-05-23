using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopFashion.Models
{
    public class Fashion
    {
        public int Id { get; set; }
        public string MatHang { get; set; }
        [Display(Name = "Ngày Đặt Hàng")]       
        [DataType(DataType.Date)]
        public DateTime NgayDatHang { get; set; }
        [Display(Name = "Ngày Giao Hàng")]
        public DateTime NgayGiaoHang { get; set; }
        public string LoaiHang { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Gia { get; set; }
    }
}
