using CsvHelper.Configuration;

public class NguoiThueMap : ClassMap<NguoiThue>
{
    public NguoiThueMap()
    {
        Map(m => m.HoTen).Index(0).Name("Ho ten");
        Map(m => m.NgheNghiep).Index(1).Name("Nghe nghiep");
        Map(m => m.CCCD).Index(2).Name("CCCD");
        Map(m => m.GioiTinh).Index(3).Name("Gioi tinh");
        Map(m => m.NgaySinh).Index(4).Name("Ngay sinh");
        Map(m => m.QueQuan).Index(5).Name("Que quan");
        Map(m => m.Tien).Index(6).Name("Tien");
        Map(m => m.SoPhong).Index(7).Name("So phong");
        Map(m => m.HD).Index(8).Name("Hop dong");
        Map(m => m.NGH.HoTen).Index(9).Name("Nguoi giam ho");
    }
}