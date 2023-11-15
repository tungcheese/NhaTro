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
    public NguoiThue NT { get { return nt; } }
    public NguoiChoThue NCT { get { return nct; } }
    public NguoiGiamHo NGH { get { return ngh; } }

    //Info
    PhongTro phongtro;
    int tiendatcoc = 6000000;
    int tienthue;
    public PhongTro PhongTro { get { return phongtro; } }
    public int TienDatCoc { get { return tiendatcoc; } }
    public int TienThue { get { return tienthue; } }

    //ThoiHan
    DateTime batdau;
    DateTime hethan;
    public DateTime HetHan { get { return hethan; } }
    public DateTime BatDau { get { return batdau; } }

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