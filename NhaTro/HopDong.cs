public class HopDong
{
    //Nguoi
    List<string> noithat;
    NguoiThue nt;
    NguoiChoThue nct;
    NguoiGiamHo ngh;
    public List<string> NoiThat
    {
        get { return noithat; }
        set { noithat = value; }
    }
    public NguoiThue NT 
    { 
        get { return nt; } 
        set {  nt = value; }
    }
    public NguoiChoThue NCT 
    {
        get { return nct; }
        set {  nct = value; }
    }
    public NguoiGiamHo NGH 
    { 
        get { return ngh; } 
        set {  ngh = value; }
    }

    //Info
    PhongTro phongtro;
    int tiendatcoc = 6000000;
    int tienthue;
    public PhongTro PhongTro 
    { 
        get { return phongtro; } 
        set { phongtro = value; }
    }
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
    public HopDong(NguoiThue nt, NguoiChoThue nct, PhongTro phongtro, int tienthue, DateTime batdau, NguoiGiamHo ngh = null)
    {
        this.nt = nt;
        this.nct = nct;
        this.phongtro = phongtro;
        this.tienthue = tienthue;
        this.noithat = phongtro.NoiThat;

        //Thoi han
        this.batdau = batdau;
        this.hethan = batdau.AddMonths(6);

        //tinh tien
        if (ngh == null)
        {
            CongCu.TruTien(nt, nct, tiendatcoc + tienthue);
        }
        else
        {
            CongCu.TruTien(ngh, nct, tiendatcoc + tienthue);
        }
    }

    public bool GiaHan()
    {
        hethan.AddMonths(6);
        return true;
    }
}