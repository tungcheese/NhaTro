public class NguoiChoThue: Nguoi
{
    //Thong tin ve phong tro
    List<PhongTro> phongtro = new List<PhongTro>();
    //Tien chung
    public int tiendienchung = 0;
    public int tiennuocchung = 0;
    public int tienracchung = 0;
    public List<PhongTro> PhongTro
    {
        get { return phongtro; }
        set { phongtro = value; }
    }

    //Constructor
    public NguoiChoThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan) 
        :base (hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
    }

    public override void HuyPhong(DateTime ngaytra, PhongTro phongtro)
    {
        int songaytra = DateTime.Compare(ngaytra, phongtro.HopDong.HetHan);
        if (songaytra < 0)
        {
            Console.WriteLine("Boi thuong");
        }
        else if (songaytra == 0)
        {
            Console.WriteLine("Tra dung han");
        }
    }

    public void DienNuoc()
    {
        foreach(PhongTro pt in phongtro)
        {
            pt.DienNuoc();
        }
    }
}