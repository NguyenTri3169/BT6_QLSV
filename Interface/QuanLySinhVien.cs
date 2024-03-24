using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT6_QLSV.Interface
{
    public class QuanLySinhVien : IQuanLySinhVien
    {
        public List<SinhVien> danhSachSV = new List<SinhVien>();

        public int ThemSinhVien(SinhVien sv)
        {
            try
            {
                if (sv == null
                    || string.IsNullOrEmpty(sv.Ten)
                    || string.IsNullOrEmpty(sv.GioiTinh)
                    || sv.Tuoi <= 0
                    || sv.DiemHoa <= 0
                    || sv.DiemLy <= 0
                    || sv.DiemToan <= 0
                    || sv.Tuoi <= 0)
                {
                    Console.WriteLine("Không có điểm âm");
                    return -1;   
                }
                if (CommonLibs1.Sercurity.HasXssFilterChars(sv.Ten))
                {
                    Console.WriteLine("Lỗi bảo mật");
                    return -2;
                }
                danhSachSV.Add(sv);
                return 1;
            }

            catch (Exception)
            {

                throw;
            }

        }

        public bool CapNhatThongTinSV(Guid id, SinhVien svMoi)
        {
            foreach (var sv in danhSachSV)
            {
                if (sv.Id == id)
                {
                    sv.Ten = svMoi.Ten;
                    sv.GioiTinh = svMoi.GioiTinh;
                    sv.Tuoi = svMoi.Tuoi;
                    sv.DiemToan = svMoi.DiemToan;
                    sv.DiemLy = svMoi.DiemLy;
                    sv.DiemHoa = svMoi.DiemHoa;
                    return true;
                }
            }
            return false;
        }

        public bool XoaSinhVien(Guid id)
        {
            for (int i = 0; i < danhSachSV.Count; i++)
            {
                if (danhSachSV[i].Id == id)
                {
                    danhSachSV.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<SinhVien> TimKiemTheoTen(string ten)
        {
            List<SinhVien> ketQua = new List<SinhVien>();
            foreach (var sv in danhSachSV)
            {
                if (sv.Ten.Contains(ten))
                {
                    ketQua.Add(sv);
                }
            }
            return ketQua;
        }

        public void SapXepTheoDiemTB()
        {
            danhSachSV.Sort(delegate (SinhVien sv1, SinhVien sv2)
            {
                return sv2.DiemTB.CompareTo(sv1.DiemTB);
            });
        }

        public void SapXepTheoTen()
        {
            danhSachSV.Sort(delegate (SinhVien sv1, SinhVien sv2)
            {
                return String.Compare(sv1.Ten, sv2.Ten);
            });
        }

        public void SapXepTheoId()
        {
            danhSachSV.Sort(delegate (SinhVien sv1, SinhVien sv2)
            {
                return sv1.Id.CompareTo(sv2.Id);
            });
        }

        public void HienThiDanhSach()
        {
            foreach (var sv in danhSachSV)
            {
                Console.WriteLine($"{sv.Id} - {sv.Ten} - {sv.GioiTinh} - {sv.Tuoi} - DiemTB: {sv.DiemTB:F2} - HocLuc: {sv.HocLuc()}");
            }
        }
    }
}
