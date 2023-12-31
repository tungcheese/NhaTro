﻿﻿public class PhongTro
{
    //Info
    int sophong;
    public int SoPhong
    {
        get { return sophong; }
        set { sophong = value; }
    }
    int songuoi = 0;
    public int SoNguoi
    { 
        get { return songuoi; }
        set { songuoi = value; }
    }
    int dientich;
    public int DienTich
    {
        get { return dientich; }
        set { dientich = value; }
    }
    int giaphong = 2500000;
    public int GiaPhong
    { 
        get { return giaphong; }
        set { giaphong = value; }
    }
    List<string> noithat = new List<string> { "Giuong", "Quat", "Tu do", "Den", "Rem", "Wifi" };
    //"ban", "ghe", "tu lanh", "nem", "tu do", "den", "quat"
    public List<string> NoiThat
    {
        get { return noithat; }
        set { noithat = value; }
    }
    List<string> noiquy = new List<string> { "Gio giac tu do", "Loi di rieng" };
    public List<string> NoiQuy
    {
        get { return noiquy; }
        set { noiquy = value; }
    }
    string yeucau;
    public string YeuCau
    {
        get { return yeucau;}
        set { yeucau = value; }
    }
    string? kiennghi = null;
    public string? KienNghi
    {
        get { return kiennghi; } //check
        set { kiennghi = value; }
    }
    bool gioitinh;
    public bool GioiTinh
    { 
        get { return gioitinh; } 
        set { gioitinh = value;}
    }

    //HopDong
    HopDong? hopdong = null; 
    public HopDong? HopDong 
    { 
        get { return hopdong; }
        set { hopdong = value; }
    }
    //Nguoi
    NguoiChoThue nguoichothue;
    public NguoiChoThue NguoiChoThue 
    { 
        get { return nguoichothue; } 
        set { nguoichothue = value; }
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
    int tienwifi;
    public int TienWifi
    {
        get { return tienwifi; }
        set { tienwifi = value; }
    }

    //Constructor
    public PhongTro(NguoiChoThue nguoichothue, int sophong, string yeucau, bool gioitinh, int dientich = 20, List<string>? noithat = null, List<string>? noiquy = null)
    {
        this.sophong = sophong;
        this.nguoichothue = nguoichothue;

        //Luu phong tro
        nguoichothue.PhongTro.Add(this);

        //Tinh tien noi that
        int sonoithat = 0;
        if (noithat != null)
        {
            this.noithat.AddRange(noithat);
            foreach (string a in noithat) { sonoithat++; }
        }
        this.giaphong = giaphong + (dientich - 20) * 100000 + sonoithat * 50000;

        //Noi quy
        if (noiquy != null)
        {
            this.noiquy.AddRange(noiquy);
        }
        this.yeucau = yeucau;
        this.gioitinh = gioitinh;
        this.dientich = dientich;
    }

    public void In()
    {
        Console.WriteLine("|So phong: {0}", sophong);
        Console.WriteLine("|Nguoi cho thue: {0}", NguoiChoThue.HoTen);
        Console.WriteLine("|Phong cho: {0}", (gioitinh) ? "Nam" : "Nu");
        Console.WriteLine("|So nguoi: {0}", songuoi);
        if (hopdong != null) hopdong.In();
        Console.WriteLine("|Dien tich: {0}", dientich);
        Console.WriteLine("|Gia phong: {0}", giaphong);
        Console.Write("|Noi that: ");
        foreach (string a in noithat) { Console.Write(a + ", "); }
        Console.Write("\n|Noi quy: ");
        foreach (string a in noiquy) { Console.Write(a + ", "); }
        Console.WriteLine("\n|Yeu cau rieng: {0}", yeucau);
        Console.WriteLine("---------------------------");
    }

    public void DienNuoc()
    {
        this.tienrac = 17000 * songuoi;
        Random rnd = new Random();
        this.tiendien = (50000 + rnd.Next(-10, 10)) * songuoi;
        this.tiennuoc = 17750 * songuoi;
        this.tienwifi = 40 * songuoi;
    }

    public void HuyPhong()
    {
        if (hopdong != null)
        {
            CongCu.TruTien(nguoichothue, hopdong.NguoiThue[0], hopdong.TienDatCoc);
            this.hopdong = null;
            this.songuoi = 0;
            this.yeucau = "";
        }
        else
        {
            Console.WriteLine("*\tPhong trong!");
        }
    }

    public bool Trong()
    {
        return (songuoi == 0);
    }
}