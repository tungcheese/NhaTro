public class Nguoi
{
    //Basic information
    string hoten;
    string nghenghiep;
    string cccd;
    bool gioitinh;
    DateTime ngaysinh;
    string quequan;
    int tien;

    //Get set
    public string HoTen { get { return hoten; } }
    public string NgheNghiepj { get { return nghenghiep; } }
    public string CCCD { get { return cccd; } }
    public bool GioiTinh { get { return gioitinh; } }
    public DateTime NgaySinh { get { return ngaysinh; } }
    public string QueQuan { get { return quequan; } }
    public int Tien
    {
        get { return tien; }
        set { tien = value; }
    }

    //Constructor
    public Nguoi(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int tien = 0)
    {
        this.hoten = hoten;
        this.nghenghiep = nghenghiep;
        this.cccd = cccd;
        this.gioitinh = CongCu.GioiTinh(cccd);
        this.ngaysinh = ngaysinh;
        this.quequan = quequan;
        this.tien = tien;
    }

    public virtual void HuyPhong(DateTime ngaytra, PhongTro phongtro)
    {
    }

    public virtual void In()
    {
        Console.WriteLine("Ho va ten: {0}", hoten);
        Console.WriteLine("Nghe nghiep: {0}", nghenghiep);
        Console.WriteLine("Can cuoc cong dan: {0}", cccd);
        Console.WriteLine("Gioi tinh: {0}", gioitinh);
        Console.WriteLine("Ngay sinh: {0}", ngaysinh.ToString("d"));
        Console.WriteLine("Que quan: {0}", quequan);
        Console.WriteLine("Tien hien co: {0}", tien);
    }
}