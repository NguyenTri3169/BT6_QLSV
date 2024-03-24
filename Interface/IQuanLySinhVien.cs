using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT6_QLSV.Interface
{
    public interface IQuanLySinhVien
    {
        int ThemSinhVien(SinhVien sv);
        bool CapNhatThongTinSV(Guid id, SinhVien svMoi);
        bool XoaSinhVien(Guid id);
        List<SinhVien> TimKiemTheoTen(string ten);
        void SapXepTheoDiemTB();
        void SapXepTheoTen();
        void SapXepTheoId();
        void HienThiDanhSach();
    }
}
