using System;

public class NguoiChoThue: Nguoi
{
    //Thong tin ve phong tro
    List<PhongTro> phongtro = new List<PhongTro>();
    public List<PhongTro> PhongTro
    {
        get { return phongtro; }
        set { phongtro = value; }
    }

    //Constructor
    public NguoiChoThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan)
        :base (hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
    }
    public void ThuHoi(PhongTro phongtro, int index)
    {
        if (phongtro.HopDong != null)
        {
            HopDong hopdong = phongtro.HopDong;
            DateTime ngaytra = hopdong.HetHan;
            if (index == 1) { ngaytra = ngaytra.AddDays(-1); }

            int songaytra = DateTime.Compare(ngaytra, hopdong.HetHan);
            if (songaytra < 0)
            {
                hopdong.TienDatCoc += hopdong.TienThue / 20 * songaytra;
            }
            phongtro.HuyPhong();
            Console.WriteLine("*\tThu hoi phong thanh cong!");
        }
        else
        {
            Console.WriteLine("*\tPhong tro trong!");
        }
    }
    public void DienNuoc()
    {
        foreach(PhongTro pt in phongtro)
        {
            pt.DienNuoc();
        }
    }
    public override void In()
    {
        int tiendien = 0, tiennuoc = 0, tienrac = 0, tienwifi = 0;
        foreach (PhongTro phongtro in this.phongtro)
        {
            tiendien += phongtro.TienDien;
            tiennuoc += phongtro.TienNuoc;
            tienrac += phongtro.TienRac;
            tienwifi += phongtro.TienWifi;
        }
        base.In();
        Console.WriteLine("Tien dien thang nay: {0}", tiendien);
        Console.WriteLine("Tien nuoc thang nay: {0}", tiennuoc);
        Console.WriteLine("Tien rac thang nay: {0}", tienrac);
        Console.WriteLine("Tien wifi thang nay: {0}", tienwifi);
        Console.WriteLine("---------------------------");
    }
    public List<string>? KiemTra(PhongTro phongtro) //return danh sach bi hong
    {
        return phongtro.HopDong.NoiThat.Except(phongtro.NoiThat).ToList();
    }

    public void KiemTraYeuCau()
    {
        if (phongtro != null)
        {
            bool check = true;
            foreach (PhongTro pt in phongtro)
            {
                if (pt.KienNghi?.Any() ?? false)
                {
                    if (check) check = false;
                    Console.WriteLine("Phong tro: {0}",pt.SoPhong);
                    Console.WriteLine("Co yeu cau: {0}", pt.KienNghi);
                    int input = CongCu.NhapSo("Co chap thuan hay khong?\n1. Co\t2. Khong", 1, 2);
                    if (input == 1)
                    {
                        pt.YeuCau = pt.KienNghi;
                        pt.KienNghi = null;
                        Console.WriteLine("*\tYeu cau duoc chap thuan!");
                    }
                    else
                    {
                        Console.WriteLine("*\tHuy bo yeu cau!");
                        pt.KienNghi = null;
                    }
                }
            }
            if (check) { Console.WriteLine("*\tKhong co yeu cau nao!"); }
        }
        else Console.WriteLine("*\tBan khong co phong tro!");
    }
}