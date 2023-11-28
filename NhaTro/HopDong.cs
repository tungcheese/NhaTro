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
    NguoiMoiGioi? nguoimoigioi;
    public NguoiMoiGioi? NguoiMoiGioi
    {
        get { return nguoimoigioi; }
        set { nguoimoigioi = value; }
    }

    //Info
    int tiendatcoc = 6000000;
    int tienthue;
    int tienno = 0;
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
    public int TienNo
    {
        get { return tienno; }
        set { tienno = value; }
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
    public HopDong(List<NguoiThue> nguoithue, PhongTro phongtro, int tienthue, DateTime batdau, NguoiMoiGioi? nguoimoigioi = null)
    {
        this.nguoithue = nguoithue;
        this.tienthue = tienthue;
        this.noithat = phongtro.NoiThat;

        //Thoi han
        this.batdau = batdau;
        this.hethan = batdau.AddMonths(6);
        this.nguoimoigioi = nguoimoigioi;

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

    public void In()
    {
        Console.WriteLine("|Nguoi thue: {0}", string.Join(";", nguoithue.Select(x=>x.HoTen)));
        Console.WriteLine("|Ngay bat dau: {0}", BatDau.ToString("dd/MM/yyyy"));
        Console.WriteLine("|Ngay het han: {0}", HetHan.ToString("dd/MM/yyyy"));
    }
}