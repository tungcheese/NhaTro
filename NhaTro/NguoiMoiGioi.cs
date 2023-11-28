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
}