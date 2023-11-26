public class NguoiChoThue: Nguoi
{
    //Thong tin ve phong tro
    List<PhongTro> phongtro = new List<PhongTro>();
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
    public override void In()
    {
        int tiendien = 0, tiennuoc = 0, tienrac = 0, tienwifi = 0;
        foreach (PhongTro phongtro in this.phongtro)
        {
            tiendien += phongtro.TienDien;
            tiennuoc += phongtro.TienNuoc;
            tienrac += phongtro.TienRac;
            tienwifi += phongtro.TienWifi;
        }
        base.In();
        Console.WriteLine("Tien dien thang nay: {0}", tiendien);
        Console.WriteLine("Tien nuoc thang nay: {0}", tiennuoc);
        Console.WriteLine("Tien rac thang nay: {0}", tienrac);
        Console.WriteLine("Tien wifi thang nay: {0}", tienwifi);
        Console.WriteLine("---------------------------");
    }
    public List<string> KiemTra(PhongTro phongtro) //return danh sach bi hong
    {
        var hong = phongtro.HopDong.NoiThat.Except(phongtro.NoiThat).ToList();
        return hong;
    }
}