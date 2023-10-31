public class PhongTro
{
    int songuoi;
    string yeucau;

    ///
    int sophong;
    int giaphong;
    string[] noithat;
    bool gioitinh;
    int dientich;
    ///
    int tien = 0;
    int tiendien;
    int tiennuoc;
    int tienrac;
    public PhongTro(int sophong, string[] noithat, bool gioitinh, int dientich = 20)
    {
        this.sophong = sophong;
        this.noithat = noithat;
        this.gioitinh = gioitinh;
        this.dientich = dientich;
    }

    public void DienNuoc()
    {
        this.tienrac = 17000 * songuoi;
        Random rd = new Random();
        this.tiendien = (50000 + rd.Next(-10, 10) * 10000) * songuoi;
        this.tiennuoc = 17750 * songuoi;
    }

    public void In()
    {
        Console.WriteLine();
    }
}
