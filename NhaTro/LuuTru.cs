using CsvHelper;
using System.Globalization;
using System.Threading.Channels;

static class LuuTru
{
    public static List<NguoiThue> nguoithue = new List<NguoiThue>();
    public static List<NguoiGiamHo> nguoigiamho = new List<NguoiGiamHo>();
    public static List<NguoiChoThue> nguoichothue = new List<NguoiChoThue>();
    public static List<NguoiMoiGioi> nguoimoigioi = new List<NguoiMoiGioi>();
    public static List<CongTy> congty = new List<CongTy>();
    public static List<PhongTro> a = new List<PhongTro>();
    public static List<PhongTro> b = new List<PhongTro>();
    public static List<HopDong> hopdong = new List<HopDong>();
    static LuuTru()
    {
        //Nguoi Cho Thue
        nguoichothue.Add(new NguoiChoThue("Le Hien L", "Doanh nhan", "079172090545", new DateTime(1789, 5, 2), "Binh Duong"));
        nguoichothue.Add(new NguoiChoThue("Pham Trung M", "Buon ban", "012051046107", new DateTime(1897, 9, 15), "Dong Nai"));

        //Phong tro
        a.Add(new PhongTro(nguoichothue[0], 101, "", true, 20, new List<string> { "Camera an ninh" }));
        a.Add(new PhongTro(nguoichothue[0], 102, "", true, 30, new List<string> { "May lanh", "Tu lanh" }));
        a.Add(new PhongTro(nguoichothue[0], 103, "", false, 30, new List<string> { "May lanh", "Tu lanh" }));
        a.Add(new PhongTro(nguoichothue[0], 104, "", false, 20, new List<string> { "Camera an ninh" }));
        a.Add(new PhongTro(nguoichothue[0], 105, "", true, 20, new List<string> { "Tu lanh" }));
        a.Add(new PhongTro(nguoichothue[0], 106, "", true, 30, new List<string> { "May lanh", "Tu lanh" }));
        a.Add(new PhongTro(nguoichothue[0], 107, "", false, 20, null, new List<string> { "Gac xep" }));
        a.Add(new PhongTro(nguoichothue[0], 108, "", false, 60, new List<string> { "May lanh", "Tu lanh", "May giat", "Tu quan ao", "Camera an ninh" }, new List<string> { "Nuoi thu cung", "Gac xep" }));

        b.Add(new PhongTro(nguoichothue[1], 1101, "", false));
        b.Add(new PhongTro(nguoichothue[1], 1102, "", false, 20, new List<string> { "Nuoi thu cung" }));
        b.Add(new PhongTro(nguoichothue[1], 1103, "", true, 30, new List<string> { "Nuoi thu cung" }));
        b.Add(new PhongTro(nguoichothue[1], 1104, "", true, 40, new List<string> { "Nuoi thu cung" }));
        b.Add(new PhongTro(nguoichothue[1], 1105, "", false, 20, new List<string> { "Nuoi thu cung" }));
        b.Add(new PhongTro(nguoichothue[1], 1106, "", false, 40));
        b.Add(new PhongTro(nguoichothue[1], 1107, "", true));

        //Nguoi giam ho
        nguoigiamho.Add(new NguoiGiamHo("Le Thi T", "Giao vien", "018383000622", new DateTime(1987, 08, 15), "Can Tho", 10000000));
        nguoigiamho.Add(new NguoiGiamHo("Nguyen Bao A", "Ky su", "070396064958", new DateTime(1975, 06, 07), "Dong Thap", 100000000));

        //NguoiThue
        nguoithue.Add(new NguoiThue("Nguyen Van A", "Sinh vien", "001332012194", new DateTime(2006, 4, 12), "Lam Dong", 10000000, nguoigiamho[0]));
        nguoithue.Add(new NguoiThue("Huynh Thi B", "Giang vien", "014275050964", new DateTime(1979, 7, 23), "Dak Nong", 10000000));
        nguoithue.Add(new NguoiThue("Tran Thanh C", "Hoc sinh", "040213044156", new DateTime(2008, 10, 4), "Hau Giang", 10000000, nguoigiamho[1]));
        nguoithue.Add(new NguoiThue("Bui Viet D", "Sinh vien", "003089092906", new DateTime(2001, 3, 18), "Quy Nhon", 10000000));
        nguoithue.Add(new NguoiThue("Le Cho E", "Sinh vien", "011269097896", new DateTime(2003, 12, 30), "Vinh Long", 10000000));
        nguoithue.Add(new NguoiThue("La Van F", "Sinh vien", "076235012491", new DateTime(2000, 2, 25), "Binh Phuoc", 10000000));
        nguoithue.Add(new NguoiThue("Nguyen Cong G", "Hoc sinh", "065180036737", new DateTime(2010, 9, 15), "Da Nang", 10000000, nguoigiamho[1]));
        nguoithue.Add(new NguoiThue("Nguyen Le Phuong H", "Giang vien", "015076097493", new DateTime(1958, 3, 9), "Tien Giang", 10000000));
        nguoithue.Add(new NguoiThue("Tran Van I", "That nghiep", "054032049093", new DateTime(1994, 1, 31), "Ha Noi", 10000000));
        nguoithue.Add(new NguoiThue("Tran Minh K", "Hoc sinh", "025225034164", new DateTime(2000, 7, 1), "Bac Can", 10000000));

        //Cong ty
        congty.Add(new CongTy("Minh Long", "2 Vo Van Ngan, phuong Linh Trung, quan Thu Duc, thanh pho Ho Chi Minh", 44332211));

        //Nguoi Moi Gioi
        nguoimoigioi.Add(new NguoiMoiGioi("Hai Tequila N", "", "058070068497", new DateTime(1802, 1, 20), "An Giang", congty[0]));
        nguoimoigioi.Add(new NguoiMoiGioi("Vu Minh O", "", "077256012180", new DateTime(1780, 5, 23), "Can Tho"));
        nguoimoigioi.Add(new NguoiMoiGioi("Lac Troi P", "", "021083092306", new DateTime(1982, 2, 19), "Long Bien", congty[0]));
    
        //Hop dong

    }

    public static void Menu_GhiFile()
    {
        var records_pt = a.Select(x => new
        {
            SoPhong = x.SoPhong,
            SoNguoi = x.SoNguoi,
            DienTich = x.DienTich,
            GiaPhong = x.GiaPhong,
            NoiThat = string.Join(";", x.NoiThat),
            NoiQuy = (x.NoiQuy == null) ? "" : string.Join(";", x.NoiQuy),
            YeuCau = x.YeuCau,
            GioiTinh = (x.GioiTinh) ? "Nam" : "Nu",
            NguoiChoThue = x.NguoiChoThue.HoTen,
            NguoiThue = (x.HopDong == null) ? "" : string.Join(";", x.HopDong.NguoiThue.Select(y => y.HoTen)),
            TienDien = x.TienDien,
            TienNuoc = x.TienNuoc,
            TienRac = x.TienRac,
            TienWifi = x.TienWifi,
        }).ToList();
        var records_ngh = nguoigiamho.Select(x => new
        {
            Hoten = x.HoTen,
            Gioitinh = (x.GioiTinh) ? "Nam" : "Nu",
            CCCD = x.CCCD,
            NgheNghiep = x.NgheNghiep,
            NgaySinh = x.NgaySinh.ToString("d"),
            QueQuan = x.QueQuan,
            Tien = x.Tien,
        }).ToList();
        var records_nct = nguoichothue.Select(x => new
        {
            Hoten = x.HoTen,
            Gioitinh = (x.GioiTinh) ? "Nam" : "Nu",
            CCCD = x.CCCD,
            NgheNghiep = x.NgheNghiep,
            NgaySinh = x.NgaySinh.ToString("d"),
            QueQuan = x.QueQuan,
            Tien = x.Tien,
            PhongTro = string.Join(";", x.PhongTro.Select(y => y.SoPhong)),
        }).ToList();
        var records_nt = nguoithue.Select(x => new
        {
            Hoten = x.HoTen,
            Gioitinh = (x.GioiTinh) ? "Nam" : "Nu",
            CCCD = x.CCCD,
            NgheNghiep = x.NgheNghiep,
            NgaySinh = x.NgaySinh.ToString("d"),
            QueQuan = x.QueQuan,
            Tien = x.Tien,
            //HopDong = !(x.HD == null),
            NguoiGiamHo = (x.NguoiGiamHo == null) ? "" : x.NguoiGiamHo.HoTen,
            SoPhong = (x.SoPhong != 0) ? "" : x.SoPhong.ToString()
        }).ToList();
        var records_ct = congty.Select(x => new
        {
            Ten = x.Ten,
            MaSoThue = x.MaSoThue,
            DiaChi = x.DiaChi,
            TienHoaHong = x.TienHoaHong,
            NguoiMoiGioi = string.Join(";", x.NMG.Select(y => y.HoTen))
        });
        var records_nmg = nguoimoigioi.Select(x => new
        {
            Hoten = x.HoTen,
            Gioitinh = (x.GioiTinh) ? "Nam" : "Nu",
            CCCD = x.CCCD,
            NgheNghiep = x.NgheNghiep,
            NgaySinh = x.NgaySinh.ToString("d"),
            QueQuan = x.QueQuan,
            Tien = x.Tien,
            CongTy = (x.CT == null) ? "" : x.CT.Ten
        }).ToList();

        using (var csv1 = new CsvWriter(new StreamWriter("phongtro.csv"), CultureInfo.InvariantCulture))
        {
            csv1.WriteRecords(records_pt);
        }
        using (var csv2 = new CsvWriter(new StreamWriter("nguoigiamho.csv"), CultureInfo.InvariantCulture))
        {
            csv2.WriteRecords(records_ngh);
        }
        using (var csv3 = new CsvWriter(new StreamWriter("nguoichothue.csv"), CultureInfo.InvariantCulture))
        {
            csv3.WriteRecords(records_nct);
        }
        using (var csv4 = new CsvWriter(new StreamWriter("nguoithue.csv"), CultureInfo.InvariantCulture))
        {
            csv4.WriteRecords(records_nt);
        }
        using (var csv5 = new CsvWriter(new StreamWriter("congty.csv"), CultureInfo.InvariantCulture))
        {
            csv5.WriteRecords(records_ct);
        }
        using (var csv6 = new CsvWriter(new StreamWriter("nguoimoigioi.csv"), CultureInfo.InvariantCulture))
        {
            csv6.WriteRecords(records_nmg);
        }
    }
}