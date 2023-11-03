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
    public NguoiThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int sophong, NguoiGiamHo ngh = null)
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.sophong = sophong;
        this.ngh = ngh;
    }
}