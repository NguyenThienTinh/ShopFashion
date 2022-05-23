using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopFashion.Data;
using System;
using System.Linq;
namespace ShopFashion.Models
{
    public static class KhoHang
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopFashionContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<ShopFashionContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.Fashion.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.Fashion.AddRange(
                new Fashion
                {
                    MatHang = "Quần Jean",
                    NgayDatHang = DateTime.Parse("2018-10-16"),
                    NgayGiaoHang = DateTime.Parse("2022-10-16"),
                    LoaiHang = "Nike",
                    Gia = 100M
                },
                new Fashion
                {
                    MatHang = "Váy",
                    NgayDatHang = DateTime.Parse("2018-10-16"),
                    NgayGiaoHang = DateTime.Parse("2019-10-16"),
                    LoaiHang = "Adidas",
                    Gia = 150M
                },
                new Fashion
                {
                    MatHang = "Áo",
                    NgayDatHang = DateTime.Parse("2018-10-16"),
                    NgayGiaoHang = DateTime.Parse("2019-10-16"),
                    LoaiHang = "Puma",
                    Gia = 140M
                }
                ); 
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}
