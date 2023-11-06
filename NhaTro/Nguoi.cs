public class Nguoi
{
    //Basic information
    string hoten;
    string nghenghiep;
    int cccd;
    bool gioitinh;
    DateTime ngaysinh;
    string quequan;

    //Get set
    public string HoTen { get { return hoten; } }
    public string NgheNghiepj { get { return nghenghiep; } }
    public int CCCD { get { return cccd; } }
    public bool GioiTinh { get { return gioitinh; } }
    public DateTime NgaySinh { get { return ngaysinh; } }
    public string QueQuan { get { return quequan; } }

    //Constructor
    public Nguoi(string hoten, string nghenghiep, int cccd, bool gioitinh, DateTime ngaysinh, string quequan)
    {
        this.hoten = hoten;
        this.nghenghiep = nghenghiep;
        this.cccd = cccd;
        this.gioitinh = gioitinh;
        this.ngaysinh = ngaysinh;
        this.quequan = quequan;
    }
}