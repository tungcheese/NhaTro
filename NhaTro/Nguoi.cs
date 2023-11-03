public class Nguoi
{
    //Basic information
    string hoten;
    string nghenghiep;
    string cccd;
    DateTime ngaysinh;
    string quequan;

    //Get set
    public string HoTen { get { return hoten; } }
    public string NgheNghiepj { get { return nghenghiep; } }
    public string CCCD { get { return cccd; } }
    public DateTime NgaySinh { get { return ngaysinh; } }
    public string QueQuan { get { return quequan; } }

    //Constructor
    public Nguoi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan)
    {
        this.hoten = hoten;
        this.nghenghiep = nghenghiep;
        this.cccd = cccd;
        this.ngaysinh = ngaysinh;
        this.quequan = quequan;
    }
}