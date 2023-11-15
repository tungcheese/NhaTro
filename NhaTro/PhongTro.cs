﻿public class PhongTro
{
    //Info
    int sophong;
    int songuoi = 0;
    public int SoNguoi
    { 
        get { return songuoi; }
        set { songuoi = value; }
    }
    int dientich;
    int giaphong = 2500000;
    public int GiaPhong
    { 
        get { return giaphong; } 
        set { giaphong = value; }
    }
    List<string> noithat;
    public List<string> NoiThat
    {
        get { return noithat; }
        set { noithat = value; }
    }
    string yeucau;
    bool gioitinh;
    public bool GioiTinh
    { 
        get { return gioitinh; } 
        set { gioitinh = value;}
    }

    //HopDong
    HopDong hopdong; 
    public HopDong HopDong 
    { 
        get { return hopdong; }
        set { hopdong = value; }
    }

    //Nguoi
    NguoiChoThue nct;
    public NguoiChoThue NCT 
    { 
        get { return nct; } 
        set { nct = value; }
    }
    List<NguoiThue> nt;
    public List<NguoiThue> NT
    { 
        get { return nt; }
        set { nt = value; }
    }

    //Tien
    int tiendien;
    public int TienDien
    {
        get { return tiendien; }
        set { tiendien = value; }
    }
    int tiennuoc;
    public int TienNuoc
    {
        get { return tiennuoc; }
        set { tiennuoc = value; }
    }
    int tienrac;
    public int TienRac
    {
        get { return tienrac; }
        set { tienrac = value; }
    }

    //Constructor
    public PhongTro(NguoiChoThue nct, int sophong, string yeucau, bool gioitinh, List<string> noithat, int dientich = 20)
    {
        this.sophong = sophong;
        this.nct = nct;
        int tiennoithat = 0;

        //Luu phong tro
        nct.PhongTro.Add(this);

        //Tinh tien noi that
        foreach (string a in noithat) { tiennoithat++; }
        this.giaphong = giaphong + (dientich - 20) * 100000 + tiennoithat * 50000;
        
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
        this.tienrac = 17000 * songuoi;
        Random rnd = new Random();
        this.tiendien = (50000 + rnd.Next(-10, 10)) * songuoi;
        this.tiennuoc = 17750 * songuoi;
    }

    public bool Trong()
    {
        return (songuoi == 0);
    }
}