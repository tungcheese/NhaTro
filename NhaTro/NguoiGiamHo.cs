public class NguoiGiamHo: Nguoi
{
    public NguoiGiamHo(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int tien = 0)
    : base(hoten, nghenghiep, cccd, ngaysinh, quequan, tien)
    {
    }

    public override void In()
    {
        base.In();
        Console.WriteLine("---------------------------");
    }
}