using System.Collections.Generic;
using System.Runtime;
using System.Runtime.CompilerServices;
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

    public static string? Nhap(string? input = null)
    {
        if (input != null) { Console.WriteLine(input); }
        Console.Write("----> ");
        return Console.ReadLine();
    }

    public static (string, string, DateTime, string) Menu_TaoNguoi ()
    {
        string? hoten = Nhap("Ten ban la: ");
        string? nghenghiep = Nhap("Nghe nghiep cua ban la: ");
        DateTime ngaysinh = new DateTime(Int32.Parse(Nhap("Nam sinh: ")), Int32.Parse(Nhap("Thang sinh: ")), Int32.Parse(Nhap("Ngay sinh")));
        string? quequan = Nhap("Que quan: ");
        //int tuoi = (int)DateTime.Now.Subtract(ngaysinh).TotalDays / 365;
        return (hoten, nghenghiep, ngaysinh, quequan);
    }

    public static void Menu_TaoNguoiThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int tuoi)
    {
        int tien = Int32.Parse(Nhap("So tien: "));
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
                        new DateTime(Int32.Parse(Nhap("Nam sinh: ")), Int32.Parse(Nhap("Thang sinh: ")), Int32.Parse(Nhap("Ngay sinh"))),
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
        CongTy ct = null;
        if (Nhap("Ban co thuoc cong ty moi gioi nao khong?\n Co || Khong:") == "Co")
        {
            int masothue = Int32.Parse(Nhap("Nhap ma so thue cong ty: "));
            if (LuuTru.congty.Exists(x => x.MaSoThue == masothue))
            {
                ct = LuuTru.congty.Find(x => x.MaSoThue == masothue);
            }
            else
            {
                ct = new CongTy(Nhap("Ten cong ty: "), Nhap("Dia chi cong ty: "), masothue);
            }
        }
        LuuTru.nguoimoigioi.Add(new NguoiMoiGioi(hoten, nghenghiep, cccd, ngaysinh, quequan));
    }
    public static void NguoiThue_TimPhong_DienTich_NhapTro(List<PhongTro> dsphongtro, NguoiThue nguoithue)
    {
        Console.WriteLine("Ban muon nhap phong tro nao: ?");
        int count = 0;
        foreach (PhongTro pt in dsphongtro)
        {
            Console.WriteLine(++count);
            pt.In();
        }
        Console.WriteLine("Ban muon nhap phong tro nao?");
        int input = Int32.Parse(Nhap("Nhap so thu tu cua phong hoac 0 de Huy: "));
        if (input != 0)
        {
            string? yeucau = Nhap("Ban co yeu cau gi ve phong khong?:\n Khong co yeu cau hay bo trong");
            string? nhaptro = Nhap("Ban co nhap tro chung voi ai khong?\nCo hoac khong: ");
            PhongTro phongTro = dsphongtro[input - 1];
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
                            NguoiThue? nt = LuuTru.nguoithue.Find(x => x.CCCD.Contains(cccd));
                            if (NguoiThue.KiemTraNhapPhong(nt, phongTro.GioiTinh)) { dsnguoithue.Add(nt); }
                            else { check = false; }
                        }
                        else
                        {
                            var inputnguoi = Menu_TaoNguoi();
                            Menu_TaoNguoiThue(inputnguoi.Item1, inputnguoi.Item2, cccd, inputnguoi.Item3, inputnguoi.Item4, (int)DateTime.Now.Subtract(inputnguoi.Item3).TotalDays / 365);
                        }
                    }
                }
            }
            Console.WriteLine(nguoithue.NhapTro(DateTime.Now, dsphongtro[input - 1], yeucau, dsnguoithue) ? "Nhap phong thanh cong" : "Khong du dieu kien nhap phong");
        }
    }
    public static void NguoiThue_TimPhong_DienTich(NguoiThue nguoithue)
    {
        Console.WriteLine("Dien tich ban mong muon: ");
        Console.WriteLine("1. 20m^2 \t2. 30m^2 \n3. 40m^2\t4. Thoat");
        int dientich = Int32.Parse(Nhap());
        List<PhongTro> dsphongtro = new List<PhongTro>();
        switch (dientich)
        {
            case 1:
                foreach (PhongTro pt in LuuTru.a)
                {
                    if (pt.DienTich == 20)
                    {
                        dsphongtro.Add(pt);
                    }
                }
                break;
            case 2:
                foreach (PhongTro pt in LuuTru.a)
                {
                    if (pt.DienTich == 30)
                    {
                        dsphongtro.Add(pt);
                    }
                }
                break;
            case 3:
                foreach (PhongTro pt in LuuTru.a)
                {
                    if (pt.DienTich == 40)
                    {
                        dsphongtro.Add(pt);
                    }
                }
                break;
            default:
                break;
        }
        if (dsphongtro != null)
        {
            NguoiThue_TimPhong_DienTich_NhapTro(dsphongtro, nguoithue);
        }
    }
    public static void NguoiThue_TimPhong(NguoiThue nguoithue)
    {
        Console.WriteLine("Nhap tieu chi tim phong cua ban:\nBo trong neu khong can: ");
        Console.WriteLine("1. Dien tich: ");
        string? dientich = Nhap("1. 20m^2 \t2. 30m^2 \n3. 40m^2\t4. 60m^2");
        Console.WriteLine("2. Gia phong: ");
        string? giaphong = Nhap("1. 2.850.000 \t2. 3.850.000 \n3. 4.850.000 \t4. 6.850.000");
        Console.WriteLine("3. Noi that: ");
        string? noithat = Nhap("1. Tu lanh \t2. May lanh \n3. May giat \t4. Tu quan ao \n5. Wifi \t6. Camera an ninh \n Nhap day so mong muon (vd tu lanh may giat <=> 13)");
        Console.WriteLine("4. Noi quy: ");
        string? noiquy = Nhap("1. 20m^2 \t2. 30m^2 \n3. 40m^2\t4. 60m^2");
        Console.WriteLine("5. Gioi tinh: ");
        string? gioitinh = Nhap("1. Nam \t2. Nu");
        switch(Int32.Parse(Nhap()))
        {
            case 1:
                NguoiThue_TimPhong_DienTich(nguoithue);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }
    }
    public static void Program_NguoiThue(NguoiThue nguoithue)
    {
        bool check = true;
        while (check)
        {
            Console.WriteLine("Ban muon lam gi?: ");
            Console.WriteLine("1. Tim phong: \n2. Quan ly phong: ");
            Console.WriteLine("3. In thong tin: \n4. Thoat: ");
            switch (Int32.Parse(Nhap()))
            {
                case 1:
                    NguoiThue_TimPhong(nguoithue);
                    break;
                case 2:
                    if (NguoiThuePT(nguoithue) != null)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Ban chua co phong tro nao!");
                    }    
                    break;
                case 3:
                    nguoithue.In();
                    continue;
                case 4:
                    check = false;
                    break;
                default:
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