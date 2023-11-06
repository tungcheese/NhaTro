public class NguoiMoiGioi: Nguoi
{
    //Unique information
    int tienhoahong;
    CongTy congty;

    //Get set
    public int TienHoaHong { get { return tienhoahong; } }
    public CongTy CT { get { return congty; } }

    //Constructor
    public NguoiMoiGioi(string hoten, string nghenghiep, int cccd, bool gioitinh, DateTime ngaysinh, string quequan, CongTy congty = null) 
        : base(hoten, nghenghiep, cccd, gioitinh, ngaysinh, quequan)
    {
        this.congty = congty;
    }
}