public class NguoiThue: Nguoi
{
    //Unique information
    int sophong;
    HopDong hopdong;
    NguoiGiamHo ngh;

    //Get set
    public int SoPhong { get { return sophong; } }
    public HopDong HD { get { return hopdong; } }
    public NguoiGiamHo NGH { get { return ngh; } }

    //Constructor
    public NguoiThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, NguoiGiamHo ngh = null)
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.ngh = ngh;
    }

    public override void In()
    {
        base.In();
        Console.WriteLine("Tro tai phong: {0}", sophong);
    }

    public override void HuyPhong(DateTime ngaytra, PhongTro phongtro)
    {
        int songaytra = DateTime.Compare(ngaytra, hopdong.HetHan);
        if (songaytra < 0)
        {
            Console.WriteLine("Boi thuong");
        }
        else if (songaytra == 0)
        {
            Console.WriteLine("Tra dung han");
        }
    }

    public bool NhapTro(DateTime ngaynhapphong, PhongTro phongtro, string yeucau, List<NguoiThue> nguoithue = null, NguoiMoiGioi nmg = null)
    {
        //Kiem tra dieu kien nhap tro
        if (!phongtro.Trong()) { return false; }
        //Check 18 tuoi co nguoi bao ho
        int tuoi = (int)DateTime.Now.Subtract(nguoithue[0].NgaySinh).TotalDays / 365;
        if (tuoi < 18 && this.NGH == null) { return false; }
        if (this.GioiTinh != phongtro.GioiTinh) { return false; }
        if (tuoi < 18)
        {
            if (this.NGH.Tien < 6000000 + phongtro.GiaPhong) { return false; }
        }
        else
        {
            if (this.Tien < 6000000 + phongtro.GiaPhong) { return false; }
        }

        //Khoi tao hopdong
        HopDong hopdong = new HopDong(this, phongtro.NCT, phongtro, phongtro.GiaPhong, ngaynhapphong, this.NGH);
        phongtro.HopDong = hopdong;
        if (nmg != null) //Cong tien cho Nguoi moi gioi (neu co)
        {
            nmg.NhanTien(600000);
            phongtro.NCT.Tien -= 600000;
        }
        //Them nguoi vao phong tro
        phongtro.NT = new List<NguoiThue> { this };
        phongtro.NT.AddRange(nguoithue);
        phongtro.SoNguoi = phongtro.NT.Count;
        return true;
    }

    public bool GiaHan()
    {
        if (hopdong == null) { return false; }
        return hopdong.GiaHan();
    }

    public bool ThanhToan()
    {
        if (hopdong != null)
        {
            PhongTro pt = hopdong.PhongTro;
            int tientong = pt.GiaPhong + pt.TienDien + pt.TienNuoc + pt.TienRac;
            if (this.Tien >= tientong)
            {
                CongCu.TruTien(this, hopdong.NCT, tientong);
                hopdong.NCT.tiennuocchung += pt.TienNuoc;
                hopdong.NCT.tienracchung += pt.TienRac;
                hopdong.NCT.tiendienchung += pt.TienDien;
                return true;
            }
        }
        return false;
    }

    public void YeuCau(string yeucau)
    {
        ///
    }
}