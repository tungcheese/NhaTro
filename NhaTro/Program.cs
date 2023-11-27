using CsvHelper;
using System.Globalization;
using static LuuTru;
using static CongCu;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        //nguoithue[0].NhapTro(DateTime.Now, a[0], "Phong thong thoang", 
        //    new List<NguoiThue> { nguoithue[1], nguoithue[2], nguoithue[3] }, nguoimoigioi[0]);
        //nguoithue[4].NhapTro(DateTime.Now, a[1], "", 
        //    new List<NguoiThue> { nguoithue[5], nguoithue[6] }, nguoimoigioi[1]);
        //nguoithue[7].NhapTro(DateTime.Now, b[2], "Khong on ao", 
        //    new List<NguoiThue> { nguoithue[8] }, nguoimoigioi[2]);
        //nguoithue[9].NhapTro(DateTime.Now, a[3], "", null, nguoimoigioi[0]);
        //nguoithue[2].NhapTro(DateTime.Now, a[6]);
        a.AddRange(b);
        nguoithue[0].NhapTro(DateTime.Now, a[3]);

        foreach (PhongTro pt in a)
        {
            if (pt.HopDong != null) pt.DienNuoc();
        }

        Console.WriteLine("Giao dien quan ly nha tro");
        while (true)
        {            
            Console.WriteLine("Nhap CCCD:");
            string? cccd = Nhap("Nhap 0 de thoat");
            if (cccd == "0")
            {
                break;
            }
            else if (nguoithue.Exists(x => x.CCCD == cccd))
            {
                Program_NguoiThue(nguoithue.Find(x=> x.CCCD.Contains(cccd)));
                break;
            }
            else if (nguoichothue.Exists(x => x.CCCD == cccd)) 
            {
                Program_NguoiChoThue(nguoichothue.Find(x => x.CCCD.Contains(cccd)));
                break;
            }
            else if (nguoimoigioi.Exists(x => x.CCCD == cccd))
            {
                Program_NguoiMoiGioi(nguoimoigioi.Find(x => x.CCCD.Contains(cccd)));
                break;
            }
            else
            {
                if (cccd != null)
                {
                    Console.WriteLine("CCCD khong ton tai trong he thong");
                    Console.WriteLine("Ban co muon tao tai khoan moi?\nNhap \"Co\" de tao tai khoan");
                    if (Console.ReadLine() == "Co")
                    {
                        var input = Menu_TaoNguoi();
                        string hoten = input.Item1;
                        string nghenghiep = input.Item2;
                        DateTime ngaysinh = input.Item3;
                        string quequan = input.Item4;
                        int tuoi = input.Item5;
                        Console.WriteLine("Ban la:\n1. Nguoi thue:\n2. Nguoi cho thue:\n3. Nguoi moi gioi:");
                        switch (NhapSo())
                        {
                            case 1:
                                Menu_TaoNguoiThue(hoten, nghenghiep, cccd, ngaysinh, quequan, tuoi);
                                break;
                            case 2:
                                Menu_TaoNguoiChoThue(hoten, nghenghiep, cccd, ngaysinh, quequan);
                                break;
                            case 3:
                                Menu_TaoNguoiMoiGioi(hoten, nghenghiep, cccd, ngaysinh, quequan);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        Menu_GhiFile();
    }
}