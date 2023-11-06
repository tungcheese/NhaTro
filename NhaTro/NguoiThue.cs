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
    public NguoiThue(string hoten, string nghenghiep, int cccd, bool gioitinh, DateTime ngaysinh, string quequan, NguoiGiamHo ngh = null)
        : base(hoten, nghenghiep, cccd, gioitinh, ngaysinh, quequan)
    {
        this.ngh = ngh;
    }
}