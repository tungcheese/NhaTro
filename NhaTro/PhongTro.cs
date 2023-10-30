public class PhongTro
{
    //Info
    int sophong;
    int songuoi = 0;
    int dientich;
    int giaphong = 2500000;
    string[] noithat;
    string yeucau;
    bool gioitinh;
    DateTime hanthue;
    Nguoi nguoia; Nguoi nguoib; Nguoi nguoic; Nguoi nguoid;

    //Tien
    int tiendien;
    int tiennuoc;
    int tienrac = 30000;

    //Constructor
    public PhongTro(int sophong, string yeucau, bool gioitinh, string[] noithat, int dientich = 20)
    {
        this.sophong = sophong;
        int bonus = 0;

        //Bonus
        foreach (string a in noithat) { bonus++; }
        this.giaphong = giaphong + (dientich - 20) * 100000 + bonus * 100000;
        this.yeucau = yeucau;
        this.gioitinh = gioitinh;
        this.noithat = noithat;
        this.dientich = dientich;
    }

    public void In()
    {
        Console.WriteLine("So phong: {0}", sophong);
        Console.WriteLine("Phong cho: {0}", (gioitinh) ? "nam" : "nu");
        Console.WriteLine("So nguoi: {0}", songuoi);
        Console.WriteLine("Dien tich: {0}", dientich);
        Console.WriteLine("Gia phong: {0}", giaphong);
        Console.Write("Noi that: ");
        foreach (string a in noithat) { Console.Write(a + ", "); }
        Console.WriteLine("Yeu cau rieng: {0}", yeucau);
    }

    public void DienNuoc()
    {
        Random rnd = new Random();
        this.tiendien = (50000 + rnd.Next(-10, 10)) * songuoi;
        this.tiennuoc = 10000 * songuoi;
    }

    public void NhapTro(Nguoi nguoia, Nguoi nguoib = null, Nguoi nguoic = null, Nguoi nguoid = null)
    {
        this.nguoia = nguoia;
        this.nguoib = nguoib;
        this.nguoic = nguoic;
        this.nguoid = nguoid;
    }
}