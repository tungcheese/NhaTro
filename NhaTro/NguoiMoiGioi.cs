public class NguoiMoiGioi: Nguoi
{
    //Unique information
    CongTy? congty;
    int sohopdong = 0;

    //Get set
    public CongTy? CT
    {
        get { return congty; }
        set { congty = value; }
    }
    public int SoHopDong
    {
        get { return sohopdong; }
        set { sohopdong = value; }
    }

    //Constructor
    public NguoiMoiGioi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, CongTy? congty = null) 
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.NgheNghiep = "Nguoi moi gioi";
        this.congty = congty;
        if (congty != null)
        {
            congty.NMG.Add(this);
        }
    }

    public override void In()
    {
        base.In();
        if (congty != null) { Console.WriteLine("Lam viec tai cong ty: {0}", congty.Ten); Console.WriteLine("Ma so thue: ", congty.MaSoThue); }
        Console.WriteLine("---------------------------");
    }

    public void NhanTien(int sotiennhan)
    {
        if (this.CT == null)
        {
            this.Tien += sotiennhan / 10;
        }
        else
        {
            this.Tien += sotiennhan * 6 / 100;
            CT.TienHoaHong += sotiennhan * 4 / 100;
        }
    }

    public void GiaNhap(CongTy congty)
    {
        congty.NMG.Add(this);
        this.congty = congty;
        Console.WriteLine("*\tGia nhap cong ty {0} thanh cong!", congty.Ten);
    }

    public void Roi()
    {
        if (congty != null)
        {
            congty.NMG.Remove(this);
            this.congty = null;
            Console.WriteLine("*\tRoi cong ty thanh cong!");
        }
        else
        {
            Console.WriteLine("*\tBan chua thuoc cong ty nao!");
        }
    }

    /// <summary>
    /// MENU Nguoi moi gioi
    /// </summary>
    /// <param name="nguoimoigioi"></param>
    public void DanhSachMoiGioi()
    {
        int count = 0;
        Console.WriteLine("----------------------------");
        Console.WriteLine("|So hop dong da moi gioi: {0}|", this.SoHopDong);
        Console.WriteLine("----------------------------");
        foreach (PhongTro phongtro in LuuTru.a)
        {
            if (phongtro.HopDong != null)
                if (phongtro.HopDong.NguoiMoiGioi == this)
                {
                    Console.WriteLine("--< {0} >--", ++count);
                    phongtro.In();
                }
        }
    }
    public void TienHoaHong()
    {
        int tienhoahong = this.SoHopDong * 600000;
        Console.WriteLine("*\tTien hoa hong: {0}", (this.CT == null) ? tienhoahong : tienhoahong - tienhoahong * 4 / 10);
    }
    public static void CongTy(NguoiMoiGioi nguoimoigioi)
    {
        if (nguoimoigioi.CT == null)
        {
            Console.WriteLine("*\tBan chua thuoc cong ty nao!");
            int input = CongCu.NhapSo("Ban co muon tim kiem cong ty khong?\n1. Co\t2. Khong", 1, 2);
            if (input == 1) CongTy_GiaNhap(nguoimoigioi);
        }
        else
        {
            nguoimoigioi.CT.In();
            int input = CongCu.NhapSo("Ban con muon tiep tuc voi cong ty:\n1. Co:\t2. Khong: ", 1, 2);
            if (input != 1)
            {
                nguoimoigioi.Roi();
            }
        }
    }
    public static void CongTy_GiaNhap(NguoiMoiGioi nguoimoigioi)
    {
        int count = 0;
        foreach (CongTy congty in LuuTru.congty)
        {
            Console.WriteLine("--< {0} >--", ++count);
            congty.In();
        }
        int index = CongCu.NhapSo("Nhap so thu tu cong ty ban muon gia nhap:\nNhap 0 de huy", 0, LuuTru.congty.Count);
        if (index != 0)
        {
            nguoimoigioi.GiaNhap(LuuTru.congty[--index]);
        }
        else
        {
            Console.WriteLine("*\tHuy gia nhap!");
        }
    }
}