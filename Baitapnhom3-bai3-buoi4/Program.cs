using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitapnhom3_bai3_buoi4
{
     public struct HoaDon
        {
            public string MaHoaDon;
            public DateTime NgayPhatHanh;
            public float TongTien;
            public float SoTienConNo;
            public int TrangThaiNo { get { return SoTienConNo == 0 ? 0 : 1; } }
            public string TenKhachHang;
        }
    internal class Program
    {
        static  List<HoaDon> NhapDanhSachHoaDon(List<HoaDon>danhSachHoaDon)
        {
            Console.Write("Nhập số lượng hóa đơn: ");
            string HoaDonnhap = Console.ReadLine();
            int Tonghd;
            bool Tonghdlaso = int.TryParse(HoaDonnhap, out Tonghd);
            while (Tonghdlaso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                HoaDonnhap = Console.ReadLine();
                Tonghdlaso = int.TryParse(HoaDonnhap, out Tonghd);
                if ((Tonghd < 0) && (Tonghd > 2147483647) && (Tonghdlaso == true))
                {
                    Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                    Tonghdlaso = false;
                }
            }
            for (int i = 0; i < Tonghd; i++)
            {
                HoaDon hoaDon = new HoaDon();
                Console.Write("Nhập mã hóa đơn: ");
                hoaDon.MaHoaDon = Console.ReadLine();
                Console.Write("Nhập ngày phát hành (dd/MM/yyyy): ");
                string ngaynhap=Console.ReadLine();
                DateTime ngayphathanh;
                bool langay=DateTime.TryParseExact(ngaynhap, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out ngayphathanh);
                while (langay == false)
                {
                    Console.WriteLine("ban nhap khong dung dinh dang, xin moi nhap lai!");
                    ngaynhap = Console.ReadLine();
                    langay = DateTime.TryParseExact(ngaynhap, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out ngayphathanh);
                }
                hoaDon.NgayPhatHanh = ngayphathanh;
                Console.Write("Nhập tổng tiền: ");
                string TongTienNhap = Console.ReadLine();
                float Tongtien;
                bool Nhaplaso = float.TryParse(TongTienNhap, out Tongtien);
                while (Nhaplaso == false) 
                {
                    Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                    TongTienNhap = Console.ReadLine();
                    Nhaplaso = float.TryParse(TongTienNhap, out Tongtien);
                    if ((Tongtien < -2147483648) && (Tongtien > 2147483647) && (Nhaplaso == true))
                    {
                        Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                        Nhaplaso = false;
                    }
                }
                hoaDon.TongTien = Tongtien;
                Console.Write("Nhập số tiền còn nợ: ");
                string TiennoNhap = Console.ReadLine();
                float Tienno;
                bool Nhapso = float.TryParse(TiennoNhap, out Tienno);
                while (Nhapso == false)
                {
                    Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                    TiennoNhap = Console.ReadLine();
                    Nhapso = float.TryParse(TiennoNhap, out Tienno);
                    if ((Tienno < -2147483648) && (Tienno > 2147483647) && (Nhapso == true))
                    {
                        Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                        Nhapso = false;
                    }
                }
                hoaDon.SoTienConNo=Tienno;
                Console.Write("Nhập tên khách hàng: ");
                hoaDon.TenKhachHang = Console.ReadLine();
                danhSachHoaDon.Add(hoaDon);
            }
            return danhSachHoaDon;
        }
        static void XoaNo(List<HoaDon> danhSachHoaDon )
        {
            Console.WriteLine("Nhập mã hóa đơn cần xóa : ");
            string maHoaDon = Console.ReadLine();
            for (int i = 0; i < danhSachHoaDon.Count; i++)
            {
                if (danhSachHoaDon[i].MaHoaDon == maHoaDon)
                {
                    HoaDon hoaDon = danhSachHoaDon[i];
                    hoaDon.SoTienConNo = 0;
                    danhSachHoaDon[i] = hoaDon;
                    Console.WriteLine("Đã xóa nợ cho hóa đơn có mã: " + maHoaDon);
                }
            }
            Console.WriteLine("Không tìm thấy hóa đơn có mã: " + maHoaDon);
        }
        static void XuatDanhSachHoaDon(List<HoaDon> danhSachHoaDon)
        {
            Console.Write("Nhập mã hóa đơn (để trống để lấy tất cả): ");
            string maHoaDon = Console.ReadLine();
            if (maHoaDon == "")
            {
                Console.WriteLine("Đang lấy tất cả danh sách hóa đơn!");
                foreach (HoaDon hoaDon in danhSachHoaDon )
                {   if (hoaDon.SoTienConNo > 0)
                    {
                        Console.Write("Hóa đơn còn nợ! ");
                        Console.WriteLine($"Mã hóa đơn: {hoaDon.MaHoaDon}, Ngày phát hành: {hoaDon.NgayPhatHanh}, Tổng tiền: {hoaDon.TongTien}, Số tiền còn nợ: {hoaDon.SoTienConNo}, Tên khách hàng: {hoaDon.TenKhachHang}");
                    }
                    else if(hoaDon.SoTienConNo>0)
                    {
                        Console.Write("Hóa đơn hết nợ! ");
                        Console.WriteLine($"Mã hóa đơn: {hoaDon.MaHoaDon}, Ngày phát hành: {hoaDon.NgayPhatHanh}, Tổng tiền: {hoaDon.TongTien}, Số tiền còn nợ: {hoaDon.SoTienConNo}, Tên khách hàng: {hoaDon.TenKhachHang}");
                    }
                }
            }else{
                int dem = 0;
                foreach (HoaDon hoadontim in danhSachHoaDon)
                {
                    if(hoadontim.MaHoaDon==maHoaDon){
                        if (hoadontim.SoTienConNo > 0)
                        {
                            Console.Write("Hóa đơn còn nợ! ");
                            Console.WriteLine($"Mã hóa đơn: {hoadontim.MaHoaDon}, Ngày phát hành: {hoadontim.NgayPhatHanh}, Tổng tiền: {hoadontim.TongTien}, Số tiền còn nợ: {hoadontim.SoTienConNo}, Tên khách hàng: {hoadontim.TenKhachHang}");
                        }
                        else if (hoadontim.SoTienConNo > 0)
                        {
                            Console.Write("Hóa đơn hết nợ! ");
                            Console.WriteLine($"Mã hóa đơn: {hoadontim.MaHoaDon}, Ngày phát hành: {hoadontim.NgayPhatHanh}, Tổng tiền: {hoadontim.TongTien}, Số tiền còn nợ: {hoadontim.SoTienConNo}, Tên khách hàng: {hoadontim.TenKhachHang}");
                        }
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    Console.WriteLine("Không tìm thấy mã hóa đơn !");
                }
            }
        }
        static void HienThiHoaDonConNo(List<HoaDon> danhSachHoaDon)
            {
            Console.WriteLine("Nhập số ngày theo các mốc cần kiểm tra : 30,60,90");
            string Mocnhap = Console.ReadLine();
            int soNgay;
            bool Mocnhaplaso = int.TryParse(Mocnhap, out soNgay);
            while (Mocnhaplaso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                Mocnhap = Console.ReadLine();
                Mocnhaplaso = int.TryParse(Mocnhap, out soNgay);
                if ((soNgay!=30) && (soNgay != 60) && (soNgay!=90))
                {
                    Console.WriteLine("ban nhap so khong trong moc, xin moi nhap lai.");
                    Mocnhaplaso = false;
                }
            }
            do {
                if ((soNgay != 30) && (soNgay != 60) && (soNgay != 90))
                {
                    Console.WriteLine("ban nhap so khong trong moc, xin moi nhap lai.");
                    Mocnhaplaso = false;
                } 
            }while(Mocnhaplaso==false);
            DateTime ngayHienTai = DateTime.Now;
            DateTime ngayCanKiemTra = ngayHienTai.AddDays(-soNgay);
            var hoaDonConNo = danhSachHoaDon.Where(hd => hd.TrangThaiNo == 1 && hd.NgayPhatHanh <= ngayCanKiemTra);
            Console.WriteLine($"Danh sách hóa đơn còn nợ sau {soNgay} ngày:");
            foreach (var hoaDon in hoaDonConNo)            {
                Console.WriteLine($"Mã hóa đơn: {hoaDon.MaHoaDon}, Ngày phát hành: {hoaDon.NgayPhatHanh}, Tổng tiền: {hoaDon.TongTien}, Số tiền còn nợ: {hoaDon.SoTienConNo}, Tên khách hàng: {hoaDon.TenKhachHang}");
            }
        }
        static void XuatHoaDonKhongConNoRaFile(List<HoaDon> danhSachHoaDon, string tenFile)
        {
            var hoaDonKhongConNo = danhSachHoaDon.Where(hd => hd.TrangThaiNo == 0);
            using (StreamWriter sw = new StreamWriter(tenFile))            {
                foreach (var hoaDon in hoaDonKhongConNo)
                {
                    sw.WriteLine($"Mã hóa đơn: {hoaDon.MaHoaDon}, Ngày phát hành: {hoaDon.NgayPhatHanh}, Tổng tiền: {hoaDon.TongTien}, Số tiền còn nợ: {hoaDon.SoTienConNo}, Tên khách hàng: {hoaDon.TenKhachHang}");
                }
            }

            Console.WriteLine($"Đã xuất {hoaDonKhongConNo.Count()} hóa đơn không còn nợ ra file {tenFile}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<HoaDon> list = new List<HoaDon>();
            Console.WriteLine("Nhập danh sách hóa đơn.");
            NhapDanhSachHoaDon(list);
            Console.WriteLine("************************ MENU ***********************");
            Console.WriteLine("       **********      ");
            Console.WriteLine("1. xóa nợ cho 1 hóa đơn.");
            Console.WriteLine("2.Xuất danh sách N hóa đơn theo các tiêu chí :\r\n    - Nếu nhập vào mã hóa đơn thì lấy theo mã hóa đơn, không thì lấy tất cả danh sách\r\n    - Các hóa đơn theo trạng thái nợ của hóa đơn ( còn nợ / hết nợ ");
            Console.WriteLine("3.hiển thị các hóa đơn đang còn nợ theo các mốc: \r\n    -30 ngày (ngày hiện tại trừ đi ngày phát hành hóa đơn = 30 ngày )\r\n    -60 ngày (ngày hiện tại trừ đi ngày phát hành hóa đơn = 60 ngày )\r\n     -90 ngày (ngày hiện tại trừ đi ngày phát hành hóa đơn = 90 ngày )");
            Console.WriteLine("4.Xuất danh sách N hóa đơn ra file text các hóa đơn không còn nợ");
            Console.WriteLine("******************************************************");
            Console.WriteLine("\nEnter choice: ");
            string text = Console.ReadLine();
            int chon;
            bool cholaso = int.TryParse(text, out chon);
            while (cholaso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                text = Console.ReadLine();
                cholaso = int.TryParse(text, out chon);
                if ((chon < 1) && (chon > 4) && (cholaso == true))
                {
                    Console.WriteLine("ban nhap so khong trong khoang MENU, xin moi nhap lai.");
                    cholaso = false;
                }
            }
            switch (chon)
            {
                case 1:
                    XoaNo(list);
                    break;
                case 2:
                    XuatDanhSachHoaDon(list);
                    break;
                case 3:
                    HienThiHoaDonConNo(list);   
                    break;
                case 4:
                    XuatHoaDonKhongConNoRaFile(list, "Hóa đơn đã hết nợ.txt");
                    break;
                default: break;
            }   
            Console.ReadKey();
        }
    }
}
