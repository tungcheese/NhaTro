public class NguoiMoiGioi: Nguoi
{
    CongTy congty;
    public NguoiMoiGioi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, CongTy congty) 
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.congty = congty;
    }
}