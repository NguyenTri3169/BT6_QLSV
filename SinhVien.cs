using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT6_QLSV
{
    public class SinhVien
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public double DiemToan { get; set; }
        public double DiemLy { get; set; }
        public double DiemHoa { get; set; }
        public double DiemTB => (DiemToan + DiemLy + DiemHoa) / 3;

        public string HocLuc()
        {
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung Bình";
            return "Yếu";
        }
    }
}
