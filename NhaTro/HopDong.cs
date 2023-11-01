public class HopDong
{
    //Nguoi
    NguoiThue nt;
    NguoiChoThue nct;
    NguoiMoiGioi nmg;

    //Info
    int sophong;
    int tiendatcoc = 6000000;
    int tienthue;

    //ThoiHan
    DateTime batdau;
    DateTime hethan;
    public DateTime HetHan { get { return hethan; } }
    
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