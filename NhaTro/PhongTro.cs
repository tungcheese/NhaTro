﻿public class PhongTro
{
    //Info
    int sophong;
    int songuoi = 0;
    int dientich;
    int giaphong = 2500000;
    string[] noithat;
    string yeucau;
    bool gioitinh;

    //HopDong
    HopDong hopdong;

    //ThoiHan
    DateTime hanthue;

    //Nguoi
    NguoiChoThue nct;
    NguoiThue[] nt;

    //Tien
    int tiendien;
    int tiennuoc;
    int tienrac;

    //Constructor
    public PhongTro(NguoiChoThue nct, int sophong, string yeucau, bool gioitinh, string[] noithat, int dientich = 20)
    {
        this.sophong = sophong;
        int tiennoithat = 0;

        //Bonus
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

    public bool NhapTro(DateTime ngaynhapphong, NguoiThue[] nguoithue, NguoiMoiGioi nmg = null)
    {
        HopDong hopdong = new HopDong(nguoithue[0], nct, nmg, sophong, giaphong, ngaynhapphong);
        int count = 0;
        foreach (NguoiThue nthue in nguoithue) 
        {
            if (nthue.GioiTinh != gioitinh) { return false; }
            count++; 
        }
        this.songuoi = count;
        this.hopdong = hopdong;
        this.nt = nguoithue;
        return true;
    }

    public void HuyPhong(DateTime ngayhuy)
    {
        int songayhuy = DateTime.Compare(ngayhuy, hopdong.HetHan);
        if (songayhuy < 0)
        {
            Console.WriteLine("Boi thuong");
        }
        else if (songayhuy == 0)
        {
            Console.WriteLine("Tra dung han");
        }
        else
        {
            Console.WriteLine("Tiep tuc gia han");
        }
    }
}