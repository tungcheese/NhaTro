public class NguoiThue: Nguoi
{
    //Unique information
    int sophong = 0;
    NguoiGiamHo? nguoigiamho;

    //Get set
    public int SoPhong 
    { 
        get { return sophong; }
        set { sophong = value; }
    }
    public NguoiGiamHo? NguoiGiamHo
    { 
        get { return nguoigiamho; } 
        set { nguoigiamho = value; }
    }

    //Constructor
    public NguoiThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int tien = 0, NguoiGiamHo? nguoigiamho = null)
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan, tien)
    {
        this.nguoigiamho = nguoigiamho;
    }

    public override void In()
    {
        base.In();
        Console.WriteLine("Tro tai phong: {0}", sophong);
        Console.WriteLine("---------------------------");
    }

    public void InPhong()
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
        {
            phongtro.In();
        }
    }

    public override void HuyPhong(DateTime ngaytra, PhongTro phongtro)
    {
        int songaytra = DateTime.Compare(ngaytra, phongtro.HopDong.HetHan);
        if (songaytra < 0)
        {
            Console.WriteLine("Boi thuong");
        }
        else if (songaytra == 0)
        {
            Console.WriteLine("Tra dung han");
        }
    }

    public static bool KiemTraNhapPhong(NguoiThue nguoithue, bool gioitinh)
    {
        return !(nguoithue == null || nguoithue.GioiTinh != gioitinh);
    }

    public bool NhapTro(DateTime ngaynhapphong, PhongTro phongtro, string? yeucau = "", List<NguoiThue>? nguoithue = null, NguoiMoiGioi? nmg = null)
    {
        //Kiem tra dieu kien nhap tro
        if (!phongtro.Trong()) { return false; }
        //check gioi tinh
        if (this.GioiTinh != phongtro.GioiTinh) { return false; }
        //Check 18 tuoi co nguoi bao ho
        int tuoi = (int)DateTime.Now.Subtract(this.NgaySinh).TotalDays / 365;
        if (tuoi < 18 && this.NguoiGiamHo == null) { return false; }
        if (tuoi < 18)
        {
            //duoi 18 tuoi tru tien nguoi giam ho
            if (this.NguoiGiamHo != null) 
                if (this.NguoiGiamHo.Tien < 6000000 + phongtro.GiaPhong) { return false; }
        }
        else
        {
            //tren 18 tuoi tu tru tien
            if (this.Tien < 6000000 + phongtro.GiaPhong) { return false; }
        }
        //kiem tra gioi tinh nguoi cung phong
        if (nguoithue != null) foreach (NguoiThue nt in nguoithue)
        {
            if (!KiemTraNhapPhong(nt, phongtro.GioiTinh)) { return false; }
        }

        //danh sach nguoi nhap tro
        List<NguoiThue> dsnguoithue = new List<NguoiThue> { this };
        if (nguoithue != null) { dsnguoithue.AddRange(nguoithue); }
        //Khoi tao hopdong
        HopDong hopdong = new HopDong(dsnguoithue, phongtro, phongtro.GiaPhong, ngaynhapphong);
        phongtro.HopDong = hopdong;
        if (yeucau != null) phongtro.YeuCau = yeucau;
        else phongtro.YeuCau = "";
        this.sophong = phongtro.SoPhong;

        //Tinh so nguoi trong phong
        phongtro.SoNguoi = dsnguoithue.Count;

        if (nmg != null) //Cong tien cho Nguoi moi gioi (neu co)
        {
            nmg.NhanTien(600000);
            phongtro.NguoiChoThue.Tien -= 600000;
        }
        return true;
    }

    public bool GiaHan()
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro == null) { return false; }
        return phongtro.HopDong.GiaHan();
    }

    public void ThanhToan()
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
        {
            int tientong = 0 + phongtro.TienDien + phongtro.TienNuoc + phongtro.TienRac + phongtro.TienWifi;
            if (tientong != 0)
            {
                Console.WriteLine("So tien can thanh toan: {0}", tientong);
                Console.WriteLine("- Tien dien:\t{0}", phongtro.TienDien);
                Console.WriteLine("- Tien nuoc:\t{0}", phongtro.TienNuoc);
                Console.WriteLine("- Tien rac:\t{0}", phongtro.TienRac);
                Console.WriteLine("- Tien wifi:\t{0}", phongtro.TienWifi);
            }
            else
            {
                Console.WriteLine("Khong co gi de thanh toan!");
                return;
            }
            int input = CongCu.NhapSo("Ban co muon thanh toan khong?\n1. Co\t2.Khong", 1, 2);
            if (this.Tien >= tientong)
                if (input == 1)
                {
                    CongCu.TruTien(this, phongtro.NguoiChoThue, tientong);
                    Console.WriteLine("Thanh toan thanh cong!");
                }
                else Console.WriteLine("Da huy thanh toan");
            else Console.WriteLine("Ban khong du tien de thanh toan");
        }
    }

    public void YeuCau(string yeucau)
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
        {
            phongtro.YeuCau = yeucau;
        }
        Console.WriteLine("Da gui yeu cau thanh cong!");
    }

    public void LamHong()
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
            if (phongtro.NoiThat != null)
            {
                Random rnd = new Random();
                foreach (string item in phongtro.NoiThat)
                {
                    for (int i = 1; i < rnd.Next(3); i++)
                    {
                        phongtro.NoiThat.RemoveAt(rnd.Next(phongtro.NoiThat.Count()));
                    }
                }
            }
    }
   
}