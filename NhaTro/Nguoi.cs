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
    public string HoTen
    {
        get { return hoten; }
        set { hoten = value; }
    }
    public string NgheNghiep
    {
        get { return nghenghiep; }
        set { nghenghiep = value; }
    }
    public string CCCD
    {
        get { return cccd; }
        set { cccd = value; }
    }
    public bool GioiTinh
    {
        get { return gioitinh; }
        set { gioitinh = value; }
    }
    public DateTime NgaySinh
    {
        get { return ngaysinh; }
        set { ngaysinh = value; }
    }
    public string QueQuan
    {
        get { return quequan; }
        set { quequan = value; }
    }
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

    public virtual void In()
    {
        Console.WriteLine("Ho va ten: {0}", hoten);
        Console.WriteLine("Nghe nghiep: {0}", nghenghiep);
        Console.WriteLine("Can cuoc cong dan: {0}", cccd);
        Console.WriteLine("Gioi tinh: {0}", gioitinh ? "Nam" : "Nu");
        Console.WriteLine("Ngay sinh: {0}", ngaysinh.ToString("dd/MM/yyyy"));
        Console.WriteLine("Que quan: {0}", quequan);
        Console.WriteLine("Tien hien co: {0}", tien);
    }

    public void NapTien(int sotien)
    {
        this.tien += sotien;
    }
}