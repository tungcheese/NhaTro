public class NguoiMoiGioi: Nguoi
{
    //Unique information
    CongTy congty;

    //Get set
    public CongTy CT 
    { 
        get { return congty; } 
        set { congty = value; }
    }

    //Constructor
    public NguoiMoiGioi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, CongTy congty = null) 
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.congty = congty;
        if (congty != null)
        {
            congty.NMG.Add(this);
        }
    }

    public override void In()
    {
        base.In();
        Console.WriteLine("Lam viec tai cong ty: {0}", congty.Ten);
    }

    public void NhanTien(int sotiennhan)
    {
        if (this.CT != null)
        {
            this.Tien += sotiennhan / 10;
        }
        else
        {
            this.Tien += sotiennhan * 6 / 100;
            CT.TienHoaHong += sotiennhan * 4 / 100;
        }
    }
}