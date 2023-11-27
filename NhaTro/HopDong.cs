public class HopDong
{
    //Nguoi
    List<string> noithat;
    public List<string> NoiThat
    {
        get { return noithat; }
        set { noithat = value; }
    }
    List<NguoiThue> nguoithue;
    public List<NguoiThue> NguoiThue
    { 
        get { return nguoithue; } 
        set { nguoithue = value; }
    }

    //Info
    int tiendatcoc = 6000000;
    int tienthue;
    public int TienDatCoc 
    { 
        get { return tiendatcoc; } 
        set { tiendatcoc = value; }
    }
    public int TienThue 
    { 
        get { return tienthue; } 
        set { tienthue = value; }
    }

    //ThoiHan
    DateTime batdau;
    DateTime hethan;
    public DateTime HetHan 
    { 
        get { return hethan; }
        set { hethan = value; }
    }
    public DateTime BatDau 
    { 
        get { return batdau; } 
        set { batdau = value; } 
    }

    //Constructor
    public HopDong(List<NguoiThue> nguoithue, PhongTro phongtro, int tienthue, DateTime batdau)
    {
        this.nguoithue = nguoithue;
        this.tienthue = tienthue;
        this.noithat = phongtro.NoiThat;

        //Thoi han
        this.batdau = batdau;
        this.hethan = batdau.AddMonths(6);

        //tinh tien
        if (nguoithue[0].NguoiGiamHo == null)
        {
            CongCu.TruTien(nguoithue[0], phongtro.NguoiChoThue, tiendatcoc + tienthue);
        }
        else
        {
            CongCu.TruTien(nguoithue[0].NguoiGiamHo, phongtro.NguoiChoThue, tiendatcoc + tienthue);
        }
        LuuTru.hopdong.Add(this);
    }

    public bool GiaHan()
    {
        hethan = HetHan.AddMonths(6);
        Console.WriteLine("Gia han den {0} thanh cong!", hethan.ToString("d"));
        return true;
    }

    public void In()
    {
        Console.WriteLine("|Nguoi thue: {0}", string.Join(";", nguoithue.Select(x=>x.HoTen)));
        Console.WriteLine("|Ngay bat dau: {0}", BatDau.ToString("d"));
        Console.WriteLine("|Ngay het han: {0}", HetHan.ToString("d"));
    }
}