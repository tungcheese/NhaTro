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

    public void TraPhong(int index)
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
        {
            if (!ThanhToan()) phongtro.HopDong.TienNo += phongtro.TienDien + phongtro.TienNuoc + phongtro.TienRac + phongtro.TienWifi;
            HopDong hopdong = phongtro.HopDong;
            DateTime ngaytra = hopdong.HetHan;
            if (index == 1) { ngaytra = ngaytra.AddDays(-1); }
            else if (index == 3) { ngaytra = ngaytra.AddDays(1); }

            int songaytra = DateTime.Compare(ngaytra, hopdong.HetHan);
            if (songaytra < 0) //truoc
            {
                phongtro.NguoiChoThue.Tien += hopdong.TienDatCoc;
                hopdong.TienDatCoc = 0;
                Console.WriteLine("*\tBan da mat tien coc");
            }
            else if (songaytra > 0) //sau
            {
                
                int tienphat = hopdong.TienThue / 20 * songaytra;
                if (hopdong.TienDatCoc > tienphat)
                {
                    hopdong.TienDatCoc -= tienphat;
                    tienphat = 0;
                }
                else
                {
                    tienphat -= hopdong.TienDatCoc;
                    hopdong.TienDatCoc = 0;
                    hopdong.TienNo += tienphat;
                }

                if (hopdong.TienNo != 0)
                {
                    if (this.Tien < hopdong.TienNo)
                    {
                        phongtro.HuyPhong();
                        return;
                    }
                    else
                    {
                        CongCu.TruTien(this, phongtro.NguoiChoThue, hopdong.TienNo);
                        hopdong.TienNo = 0;
                        Console.WriteLine("*\tThanh toan no thanh cong!");
                    }
                }
            }
            phongtro.HuyPhong();
            Console.WriteLine("*\tTra phong thanh cong!");
        }
    }

    public static bool KiemTraNhapPhong(NguoiThue nguoithue, bool gioitinh)
    {
        return !(nguoithue == null || nguoithue.GioiTinh != gioitinh);
    }

    public bool NhapTro(DateTime ngaynhapphong, PhongTro phongtro, string? yeucau = "", List<NguoiThue>? nguoithue = null, NguoiMoiGioi? nguoimoigioi = null)
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
                if (this.NguoiGiamHo.Tien < 6000000 + 6 * phongtro.GiaPhong) { return false; }
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
        HopDong hopdong = new HopDong(dsnguoithue, phongtro, phongtro.GiaPhong, ngaynhapphong, nguoimoigioi);
        phongtro.HopDong = hopdong;
        if (yeucau != null) phongtro.KienNghi = yeucau;
        else phongtro.YeuCau = "";
        this.sophong = phongtro.SoPhong;

        //Tinh so nguoi trong phong
        phongtro.SoNguoi = dsnguoithue.Count;

        if (nguoimoigioi != null) //Cong tien cho Nguoi moi gioi (neu co)
        {
            nguoimoigioi.SoHopDong++;
            nguoimoigioi.NhanTien(600000);
            phongtro.NguoiChoThue.Tien -= 600000;
        }
        return true;
    }

    public void GiaHan()
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
        {
            DateTime temp = phongtro.HopDong.HetHan;
            Console.WriteLine("Ngay het han: {0}", temp.ToString("dd/MM/yyyy"));
            Console.WriteLine("Gia han den: {0}", temp.AddMonths(6).ToString("dd/MM/yyyy"));
            Console.WriteLine("Tong cong: {0}", 6 * phongtro.HopDong.TienThue + phongtro.HopDong.TienNo);
            int input = CongCu.NhapSo("Ban muon gia han hay khong?\n1. Co\t2.Khong: ", 1, 2);
            if (input == 1)
            {
                if (6 * phongtro.HopDong.TienThue < this.Tien)
                {
                    CongCu.TruTien(this, phongtro.NguoiChoThue, 6 * phongtro.HopDong.TienThue + phongtro.HopDong.TienNo);
                    phongtro.HopDong.TienNo = 0;
                }
                else Console.WriteLine("*\tBan khong du tien de gia han");
            }
            else Console.WriteLine("*\tHuy gia han");
            
        }
        else Console.WriteLine("*\tBan chua co phong tro");
    }

    public bool ThanhToan()
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
                Console.WriteLine("*\tKhong co gi de thanh toan!");
                return true;
            }
            int input = CongCu.NhapSo("Ban co muon thanh toan khong?\n1. Co\t2.Khong", 1, 2);
            if (this.Tien >= tientong)
                if (input == 1)
                {
                    CongCu.TruTien(this, phongtro.NguoiChoThue, tientong);
                    phongtro.TienDien = 0;
                    phongtro.TienNuoc = 0;
                    phongtro.TienRac = 0;
                    phongtro.TienWifi = 0;
                    Console.WriteLine("*\tThanh toan thanh cong!");
                    return true;
                }
                else Console.WriteLine("*\tDa huy thanh toan");
            else
            {
                Console.WriteLine("*\tBan khong du tien de thanh toan");
                return false;
            }
        }
        return true;
    }

    public void YeuCau(string yeucau)
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
        {
            phongtro.KienNghi = yeucau;
        }
        Console.WriteLine("*\tDa gui yeu cau thanh cong!");
    }

    public void LamHong()
    {
        PhongTro? phongtro = CongCu.NguoiThuePT(this);
        if (phongtro != null)
            if (phongtro.NoiThat != null)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, phongtro.NoiThat.Count);
                phongtro.NoiThat.RemoveAt(index);
            }
    }
   
}