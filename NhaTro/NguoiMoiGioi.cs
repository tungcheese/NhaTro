public class NguoiMoiGioi: Nguoi
{
    //Unique information
    int tienhoahong;
    CongTy congty;

    //Get set
    public int TienHoaHong { get { return tienhoahong; } }
    public CongTy CT { get { return congty; } }

    //Constructor
    public NguoiMoiGioi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, CongTy congty) 
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.congty = congty;
    }
}