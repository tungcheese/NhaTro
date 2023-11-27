using System.Runtime;
/// Tung Cheese
static class CongCu
{
    public static PhongTro? NguoiThuePT(NguoiThue nguoithue)
    {
        foreach (PhongTro pt in LuuTru.a)
        {
            if (pt.HopDong != null) 
            {
                if (pt.HopDong.NguoiThue != null)
                {
                    foreach (NguoiThue nt in pt.HopDong.NguoiThue)
                    {
                        if (nt == nguoithue)
                        {
                            return pt;
                        }
                    }
                }
            }
        }
        return null;
    }
    public static string Tao()
    {
        Random rnd = new();
        int mavung = rnd.Next(97);
        string smavung = (mavung < 10) ? "00" : "0";
        int gioitinh = rnd.Next(4);
        int namsinh = rnd.Next(100);
        string snamsinh = (namsinh < 10) ? "0" : "";
        string socuoi = "";
        for (int i = 0; i < 5; i++)
        {
            socuoi += rnd.Next(10).ToString();
        }
        return smavung + mavung.ToString() + gioitinh.ToString() + snamsinh + namsinh.ToString() + "0" + socuoi;
    }

    public static bool GioiTinh(string cccd)
    {
        int gioitinh = Int32.Parse(cccd.Substring(2, 1));
        return gioitinh % 2 == 0;
    }

    public static bool TruTien(Nguoi a, Nguoi b, int sotien)
    {
        if (a.Tien >= sotien)
        {
            a.Tien -= sotien;
            b.Tien += sotien;
            return true;
        }
        return false;
    }

    public static string Nhap(string? input = null)
    {
        if (input != null) { Console.WriteLine(input); }
        string? output = null;
        while (output == null)
        {
            Console.Write("----> ");
            output = Console.ReadLine();
        }
        return output;
    }

    public static int NhapSo(string? input = null, int start = -1, int end = -1)
    {
        int b;
        if (start == end)
        {
            while (true)
            {
                try
                {
                    string? a = Nhap(input);
                    b = Int32.Parse(a);
                    break;
                }
                catch
                {
                    Console.WriteLine("Vui long nhap lai");
                }
            }
        }
        else if (start == 0 && end == -1)
        {
            b = start - 1;
            while(b < start)
            {
                try
                {
                    Console.Write("[{0}, {1}]\t", start, end);
                    string? a = Nhap(input);
                    b = Int32.Parse(a);
                }
                catch
                {
                    Console.WriteLine("Vui long nhap lai");
                }
            }
        }
        else
        {
            b = start - 1;
            while (b < start || b > end)
            {
                try
                {
                    string? a = Nhap(input);
                    b = Int32.Parse(a);
                }
                catch
                {
                    Console.WriteLine("Vui long nhap lai");
                }
            }
        }
        return b;
    }

    public static (string, string, DateTime, string, int) Menu_TaoNguoi ()
    {
        string? hoten = Nhap("Ten ban la: ");
        string? nghenghiep = Nhap("Nghe nghiep cua ban la: ");
        DateTime ngaysinh = new DateTime(NhapSo("Nam sinh: "), NhapSo("Thang sinh: "), NhapSo("Ngay sinh"));
        string? quequan = Nhap("Que quan: ");
        int tuoi = (int)DateTime.Now.Subtract(ngaysinh).TotalDays / 365;
        return (hoten, nghenghiep, ngaysinh, quequan, tuoi);
    }

    ///Menu tao nguoi
    public static void Menu_TaoNguoiThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int tuoi)
    {
        int tien = NhapSo("So tien: ");
        NguoiGiamHo ngh = null;
        if (tuoi < 18)
        {
            if (Nhap("Ban co nguoi giam ho khong?\n Co || Khong:") == "Co")
            {
                string cccd_ngh = Nhap("Nhap cccd cua nguoi giam ho");
                if (LuuTru.nguoigiamho.Exists(x => x.CCCD == cccd_ngh))
                {
                    ngh = LuuTru.nguoigiamho.Find(x => x.CCCD.Contains(cccd_ngh));

                }
                else
                {
                    ngh = new NguoiGiamHo(
                        Nhap("Ten nguoi giam ho: "), Nhap("Nghe nghiep: "), cccd_ngh,
                        new DateTime(NhapSo("Nam sinh: "), NhapSo("Thang sinh: "), NhapSo("Ngay sinh")),
                        Nhap("Que quan: "));
                }
            }
        }
        LuuTru.nguoithue.Add(new NguoiThue(hoten, nghenghiep, cccd, ngaysinh, quequan, tien, ngh));
    }
    public static void Menu_TaoNguoiChoThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan)
    {
        LuuTru.nguoichothue.Add(new NguoiChoThue(hoten, nghenghiep, cccd, ngaysinh, quequan));
    }
    public static void Menu_TaoNguoiMoiGioi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan)
    {
        CongTy? congty = null;
        if (Nhap("Ban co thuoc cong ty moi gioi nao khong?\n Co || Khong:") == "Co")
        {
            int masothue = NhapSo("Nhap ma so thue cong ty: ");
            if (LuuTru.congty.Exists(x => x.MaSoThue == masothue))
            {
                congty = LuuTru.congty.Find(x => x.MaSoThue == masothue);
            }
            else
            {
                congty = new CongTy(Nhap("Ten cong ty: "), Nhap("Dia chi cong ty: "), masothue);
            }
        }
        LuuTru.nguoimoigioi.Add(new NguoiMoiGioi(hoten, nghenghiep, cccd, ngaysinh, quequan, congty));
    }
    
    //Nguoi thue nhap tro
    public static void NguoiThue_TimPhong_NhapTro(PhongTro phongTro, NguoiThue nguoithue)
    {
        string? yeucau = Nhap("Ban co yeu cau gi ve phong khong?:\nKhong co yeu cau thi hay bo trong");
        string? nhaptro = Nhap("Ban co nhap tro chung voi ai khong?\nCo hoac khong: ");
        List<NguoiThue>? dsnguoithue = null;
        if (nhaptro == "Co")
        {
            bool check = true;
            dsnguoithue = new List<NguoiThue>();
            for (int i = 0; i < 3 && check; i++)
            {
                if (i != 0) { check = Nhap("Con nguoi khac khong?\nCo hoac Khong: ") == "Co"; }
                if (check)
                {
                    string? cccd = Nhap("Nhap cccd nguoi thue: ");
                    if (LuuTru.nguoithue.Exists(x => x.CCCD == cccd))
                    {
                        NguoiThue nt = LuuTru.nguoithue.Find(x => x.CCCD.Contains(cccd));
                        if (NguoiThue.KiemTraNhapPhong(nt, phongTro.GioiTinh)) { dsnguoithue.Add(nt); }
                        else { check = false; }
                    }
                    else
                    {
                        var inputnguoi = Menu_TaoNguoi();
                        Menu_TaoNguoiThue(inputnguoi.Item1, inputnguoi.Item2, cccd, inputnguoi.Item3, inputnguoi.Item4, inputnguoi.Item5);
                    }
                }
            }
        }
        Console.WriteLine(nguoithue.NhapTro(DateTime.Now, phongTro, yeucau, dsnguoithue) ? "Nhap phong thanh cong" : "Khong du dieu kien nhap phong");
    }

    /// <summary>
    /// Cac ham va chuc nang can thiet de nguoithue tim phong
    /// </summary>
    /// <returns></returns>
    public static int? NguoiThue_TimPhong_DienTich()
    {
        Console.WriteLine("* 1. Dien tich: ");
        string? dientich = Nhap("1. 20m^2 \t2. 30m^2 \n3. 40m^2\t4. 60m^2");
        if (dientich?.Any() ?? false)
        {
            switch (Int32.Parse(dientich))
            {
                case 1:
                    dientich = "20";
                    break;
                case 2:
                    dientich = "30";
                    break;
                case 3:
                    dientich = "40";
                    break;
                case 4:
                    dientich = "60";
                    break;
            }
        }
        return (dientich?.Any() ?? false) ? Int32.Parse(dientich) : null;
    }
    public static int? NguoiThue_TimPhong_GiaPhong()
    {
        Console.WriteLine("* 2. Gia phong: ");
        string? giaphong = Nhap("1. 2.850.000 \t2. 3.850.000 \n3. 4.850.000 \t4. 6.850.000");
        if (giaphong?.Any() ?? false)
        {
            switch (Int32.Parse(giaphong))
            {
                case 1:
                    giaphong = "2850000";
                    break;
                case 2:
                    giaphong = "3850000";
                    break;
                case 3:
                    giaphong = "4850000";
                    break;
                case 4:
                    giaphong = "6850000";
                    break;
            }
        }
        return (giaphong?.Any() ?? false) ? Int32.Parse(giaphong) : null;
    }
    public static List<string>? NguoiThue_TimPhong_NoiThat()
    {
        Console.WriteLine("* 3. Noi that: ");
        string? tempnoithat = Nhap("1. Tu lanh \t2. May lanh \n3. May giat \t4. Tu quan ao \n5. Gac xep \t6. Camera an ninh \n Nhap day so mong muon (vd tu lanh may giat <=> 13)");
        List<string>? noithat = null;
        List<int> explored = new List<int>();
        if (tempnoithat?.Any() ?? false)
        {
            noithat = new List<string>();
            foreach (char sub in tempnoithat)
            {
                int num = sub - '0';
                if (!explored.Contains(num))
                {
                    switch (num)
                    {
                        case 1:
                            noithat.Add("Tu lanh");
                            break;
                        case 2:
                            noithat.Add("May lanh");
                            break;
                        case 3:
                            noithat.Add("May giat");
                            break;
                        case 4:
                            noithat.Add("Tu quan ao");
                            break;
                        case 5:
                            noithat.Add("Gac xep");
                            break;
                        case 6:
                            noithat.Add("Camera an ninh");
                            break;
                    }
                    explored.Add(num);
                }
            }
        }
        return (noithat?.Any() ?? false) ? noithat : null;
    }
    public static List<string>? NguoiThue_TimPhong_NoiQuy()
    {
        Console.WriteLine("* 4. Noi quy: ");
        string? tempnoiquy = Nhap("1. Nuoi thu cung \t2. Cho tham nha \n3. Thu don rac hang tuan \t4. Khong on ao \n Nhap day so mong muon (vd tu lanh may giat <=> 13)");
        List<string>? noiquy = null;
        List<int> explored = new List<int>();
        if (tempnoiquy?.Any() ?? false)
        {
            noiquy = new List<string>();
            foreach (char sub in tempnoiquy)
            {
                int num = sub - '0';
                if (!explored.Contains(num))
                {
                    switch (num)
                    {
                        case 1:
                            noiquy.Add("Nuoi thu cung");
                            break;
                        case 2:
                            noiquy.Add("Cho tham nha");
                            break;
                        case 3:
                            noiquy.Add("Thu don rac hang tuan");
                            break;
                        case 4:
                            noiquy.Add("Khong on ao");
                            break;
                    }
                    explored.Add(num);
                }
            }
        }
        return (noiquy?.Any() ?? false) ? noiquy : null;
    }
    public static bool? NguoiThue_TimPhong_GioiTinh()
    {
        Console.WriteLine("* 5. Gioi tinh: ");
        string? gioitinh = Nhap("1. Nam \t2. Nu");
        return (gioitinh?.Any() ?? false) ? (gioitinh == "1") : null;
    }
    public static List<PhongTro> NguoiThue_TimPhong_PhongTro(int? dientich, int? giaphong, List<string>? noithat, List<string>? noiquy, bool? gioitinh)
    {
        List<PhongTro> dsphongtro = new List<PhongTro>();
        List<PhongTro> output = LuuTru.a;
        if (dientich != null)
        {
            output = output.Where(p => p.DienTich == dientich).ToList();
        }
        if (giaphong != null)
        {
            output = output.Where(p => p.GiaPhong == giaphong).ToList();
        }
        if (noithat != null) 
        {
            output = output.Where(p => noithat.Intersect(p.NoiThat).Count() == noithat.Count).ToList();
        }
        if (noiquy != null)
        {
            output = output.Where(p => noiquy.Intersect(p.NoiQuy).Count() == noiquy.Count).ToList();
        }
        if (gioitinh != null)
        {
            output = output.Where(p => p.GioiTinh == gioitinh).ToList();
        }
        return output;
    }
    public static void NguoiThue_TimPhong(NguoiThue nguoithue)
    {
        Console.WriteLine("Nhap tieu chi tim phong cua ban:\nBo trong neu khong can: ");
        int? dientich = NguoiThue_TimPhong_DienTich();
        int? giaphong = NguoiThue_TimPhong_GiaPhong();
        List<string>? noithat = NguoiThue_TimPhong_NoiThat();
        List<string>? noiquy = NguoiThue_TimPhong_NoiQuy();
        bool? gioitinh = NguoiThue_TimPhong_GioiTinh();
        List<PhongTro> dsphongtro = NguoiThue_TimPhong_PhongTro(dientich, giaphong, noithat, noiquy, gioitinh);
        if (dsphongtro.Any())
        {
            int count = 0;
            Console.WriteLine("Danh sach phong tro:");
            foreach (PhongTro pt in dsphongtro)
            {
                Console.WriteLine("--*< {0} >*--", ++count);
                pt.In();
                Console.WriteLine("-----------");
            }
            int index = NhapSo("Ban muon nhap tro phong nao? \nNhap so thu tu de chon \nHoac nhap 0 de huy:", 0, count);
            if (index == 0)
            {
                Console.WriteLine("Huy tim phong");
                return;
            }
            if (dsphongtro[index - 1].GioiTinh == nguoithue.GioiTinh)
                NguoiThue_TimPhong_NhapTro(dsphongtro[index - 1], nguoithue);
            else
            {
                Console.WriteLine("***! Gioi tinh khong phu hop");
            }
        }
        else
        {
            Console.WriteLine("Khong co phong tro thoa");
        }
    }

    public static void NguoiThue_QuanLy(NguoiThue nguoithue)
    {
        bool check = true;
        while (check)
        {
            Console.WriteLine("So phong cua ban la: {0}", nguoithue.SoPhong);
            Console.WriteLine("Ban muon lam gi?: ");
            int input = NhapSo("1. In phong: \t\t2. Gia han: \n3. Thanh toan tien: \t4. Yeu cau: \n5. Lam hong (dev): \t0. Thoat: ", 0, 5);
            switch (input)
            {
                case 1:
                    nguoithue.InPhong();
                    break;
                case 2: //chua co tinh tien gia han
                    nguoithue.GiaHan();
                    break;
                case 3:
                    nguoithue.ThanhToan();
                    break;
                case 4:
                    nguoithue.YeuCau(Nhap("Nhap yeu cau cua ban: "));
                    break;
                case 5:
                    nguoithue.LamHong();
                    break;
                case 0:
                    check = false;
                    break;
            }
        }
    }

    /// <summary>
    /// Program cho nguoithue, nguoichothue va nguoimoigioi quan ly cac muc tieu
    /// </summary>
    /// <param name="nguoithue"></param>
    public static void Program_NguoiThue(NguoiThue nguoithue)
    {
        bool check = true;
        while (check)
        {
            Console.WriteLine("Ban muon lam gi?: ");
            Console.WriteLine("1. Tim phong: \t\t2. Quan ly phong: ");
            Console.WriteLine("3. In thong tin: \t4. Nap tien: ");
            switch (NhapSo("0. Thoat: ", 0, 4))
            {
                case 1:
                    if (NguoiThuePT(nguoithue) == null) NguoiThue_TimPhong(nguoithue);
                    else Console.WriteLine("Ban da so huu mot phong tro roi");
                    break;
                case 2:
                    if (NguoiThuePT(nguoithue) != null) NguoiThue_QuanLy(nguoithue);
                    else Console.WriteLine("Ban chua co phong tro nao!");   
                    break;
                case 3:
                    nguoithue.In();
                    continue;
                case 4:
                    nguoithue.NapTien(NhapSo("Nhap so tien can nap: ", 0));
                    Console.WriteLine("Nap tien thanh cong!");
                    continue;
                case 0:
                    check = false;
                    break;
            }
        }
    }
    public static void Program_NguoiChoThue(NguoiChoThue nct)
    {

    }
    public static void Program_NguoiMoiGioi(NguoiMoiGioi nmg)
    {

    }
}