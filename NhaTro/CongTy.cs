public class CongTy
{
    //Basic information
    string ten;
    int masothue;
    string diachi;
    int tienhoahong;

    //Get set
    public string Ten { get { return ten; } }
    public int MaSoThue { get { return masothue; } }
    public string DiaChi { get { return diachi; } }
    public int TienHoaHong { get { return tienhoahong; } }

    //Constructor
    public CongTy(string diachi, int masothue)
    {
        this.diachi = diachi;
        this.masothue = masothue;
    }
}