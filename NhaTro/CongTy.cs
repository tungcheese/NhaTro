public class CongTy
{
    //Basic information
    string ten;
    int masothue;
    string diachi;
    int tienhoahong;
    List<NguoiMoiGioi> nmg = new List<NguoiMoiGioi>();

    //Get set
    public string Ten { get { return ten; } }
    public int MaSoThue { get { return masothue; } }
    public string DiaChi { get { return diachi; } }
    public int TienHoaHong 
    { 
        get { return tienhoahong; } 
        set { tienhoahong = value; }
    }
    public List<NguoiMoiGioi> NMG
    {
        get { return nmg; }
        set { nmg = value; }
    }

    //Constructor
    public CongTy(string diachi, int masothue)
    {
        this.diachi = diachi;
        this.masothue = masothue;
    }
    
    public void In()
    {
        Console.WriteLine("Ten cong ty: {0}", ten);
        Console.WriteLine("Ma so thue: {0}", masothue);
        Console.WriteLine("Dia chi: {0}", diachi);
        Console.WriteLine("Tien hoa hong: {0}", tienhoahong);
    }

    public void InNhanVien()
    {
        Console.WriteLine("Cac nguoi moi gioi thuoc cong ty: \n");
        foreach(NguoiMoiGioi nguoimoigioi in nmg)
        {
            Console.WriteLine("Nguoi moi gioi: {0}", nguoimoigioi.HoTen);
        }
    }
}