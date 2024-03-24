using BT6_QLSV.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT6_QLSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding=Encoding.UTF8;
            QuanLySinhVien qlsv = new QuanLySinhVien();
            string luaChon;
            do
            {
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Cập nhật thông tin sinh viên theo ID");
                Console.WriteLine("3. Xóa sinh viên theo ID");
                Console.WriteLine("4. Tìm kiếm sinh viên theo tên");
                Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình");
                Console.WriteLine("6. Sắp xếp sinh viên theo tên");
                Console.WriteLine("7. Sắp xếp sinh viên theo ID");
                Console.WriteLine("8. Hiển thị danh sách sinh viên");
                Console.WriteLine("9. Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");

                luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        SinhVien svMoi = new SinhVien();
                        Console.Write("Nhập tên sinh viên: ");
                        svMoi.Ten = Console.ReadLine();
                        Console.Write("Nhập giới tính sinh viên: ");
                        svMoi.GioiTinh = Console.ReadLine();
                        Console.Write("Nhập tuổi sinh viên: ");
                        svMoi.Tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm toán: ");
                        svMoi.DiemToan = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm lý: ");
                        svMoi.DiemLy = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm hóa: ");
                        svMoi.DiemHoa = double.Parse(Console.ReadLine());
                        qlsv.ThemSinhVien(svMoi);
                        Console.WriteLine("Đã thêm sinh viên thành công.");
                        break;
                    case "2":
                        // Code cập nhật thông tin sinh viên từ ID và thông tin mới nhập vào
                        Console.Write("Nhập ID của sinh viên cần cập nhật: ");
                        Guid idCanCapNhat = Guid.Parse(Console.ReadLine());
                        SinhVien svCapNhat = new SinhVien();
                        Console.Write("Nhập tên mới: ");
                        svCapNhat.Ten = Console.ReadLine();
                        Console.Write("Nhập giới tính mới: ");
                        svCapNhat.GioiTinh = Console.ReadLine();
                        Console.Write("Nhập tuổi mới: ");
                        svCapNhat.Tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm toán mới: ");
                        svCapNhat.DiemToan = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm lý mới: ");
                        svCapNhat.DiemLy = double.Parse(Console.ReadLine());
                        Console.Write("Nhập điểm hóa mới: ");
                        svCapNhat.DiemHoa = double.Parse(Console.ReadLine());
                        if (qlsv.CapNhatThongTinSV(idCanCapNhat, svCapNhat))
                        {
                            Console.WriteLine("Cập nhật thông tin sinh viên thành công.");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sinh viên với ID đã nhập.");
                        }
                        break;
                    case "3":
                        // Code xóa sinh viên từ ID nhập vào
                        Console.Write("Nhập ID của sinh viên cần xóa: ");
                        Guid idCanXoa = Guid.Parse(Console.ReadLine());
                        if (qlsv.XoaSinhVien(idCanXoa))
                        {
                            Console.WriteLine("Sinh viên đã được xóa thành công.");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sinh viên với ID đã nhập.");
                        }
                        break;
                    case "4":
                        // Code tìm kiếm sinh viên từ tên nhập vào và hiển thị kết quả
                        Console.Write("Nhập tên của sinh viên cần tìm kiếm: ");
                        string tenCanTim = Console.ReadLine();
                        var sinhVienTimDuoc = qlsv.TimKiemTheoTen(tenCanTim);
                        if (sinhVienTimDuoc.Count > 0)
                        {
                            foreach (var sv in sinhVienTimDuoc)
                            {
                                Console.WriteLine($"{sv.Id} - {sv.Ten} - {sv.GioiTinh} - {sv.Tuoi} - DiemTB: {sv.DiemTB:F2} - HocLuc: {sv.HocLuc()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sinh viên.");
                        }
                        break;
                    case "5":
                        qlsv.SapXepTheoDiemTB();
                        qlsv.HienThiDanhSach();
                        break;
                    case "6":
                        qlsv.SapXepTheoTen();
                        qlsv.HienThiDanhSach();
                        break;
                    case "7":
                        qlsv.SapXepTheoId();
                        qlsv.HienThiDanhSach();
                        break;
                    case "8":
                        qlsv.HienThiDanhSach();
                        break;
                    case "9":
                        Console.WriteLine("Chương trình kết thúc.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại:");
                        break;
                }
            } while (luaChon != "9");
            Console.ReadLine();
        }
    }
}
