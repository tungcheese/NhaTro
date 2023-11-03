public class HopDong
{
    //Nguoi
    NguoiThue nt;
    NguoiChoThue nct;
    NguoiMoiGioi nmg;
    public NguoiThue NT { get { return nt; } }
    public NguoiChoThue NCT { get { return nct; } }
    public NguoiMoiGioi NMG { get { return nmg; } }

    //Info
    int sophong;
    int tiendatcoc = 6000000;
    int tienthue;
    public int SoPhong { get { return sophong; } }
    public int TienDatCoc { get { return tiendatcoc; } }
    public int TienThue { get { return tienthue; } }

    //ThoiHan
    DateTime batdau;
    DateTime hethan;
    public DateTime HetHan { get { return hethan; } }
    public DateTime BatDau { get { return batdau; } }
    
    //Constructor
    public HopDong(NguoiThue nt, NguoiChoThue nct, NguoiMoiGioi nmg, int sophong, int tienthue, DateTime batdau)
    {
        this.nt = nt;
        this.nct = nct;
        this.nmg = nmg;
        this.sophong = sophong;
        this.tienthue = tienthue;

        //Thoi han
        this.batdau = batdau;
        this.hethan = batdau.AddMonths(6);
    }
}