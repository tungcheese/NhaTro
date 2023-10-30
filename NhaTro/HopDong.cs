public class HopDong
{
    NguoiThue nt;
    NguoiChoThue nct;
    NguoiMoiGioi nmg;
    PhongTro phongtro;
    DateTime ngaythue;
    DateTime hanthue;
    int tiendatcoc;
    //int tienthue;
    public HopDong(NguoiThue nt, NguoiChoThue nct, NguoiMoiGioi nmg, PhongTro phongtro)
    {
        this.nt = nt;
        this.nct = nct;
        this.nmg = nmg;
        this.phongtro = phongtro;
        this.ngaythue = DateTime.Now;
        this.hanthue = DateTime.Now.AddMonths(6);
    }
}