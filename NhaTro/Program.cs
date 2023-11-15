using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Nguoi Cho Thue
        NguoiChoThue[] nct = new NguoiChoThue[4];
        nct[0] = new NguoiChoThue("Le Hien L", "Doanh nhan", CongCu.Tao(), new DateTime(1789, 5, 2), "Binh Duong");
        nct[1] = new NguoiChoThue("Pham Trung M", "Buon ban", CongCu.Tao(), new DateTime(1897, 9, 15), "Dong Nai");

        //Phong tro
        PhongTro[] a = new PhongTro[20];
        a[0] = new PhongTro(nct[0], 101, "", true);
        a[1] = new PhongTro(nct[0], 102, "", true, 30);
        a[2] = new PhongTro(nct[0], 103, "", true, 30);
        a[3] = new PhongTro(nct[0], 104, "", true);
        a[4] = new PhongTro(nct[0], 105, "", true);
        a[5] = new PhongTro(nct[0], 106, "", true, 30);
        a[6] = new PhongTro(nct[0], 107, "", true);
        a[7] = new PhongTro(nct[0], 108, "", true);

        PhongTro[] b = new PhongTro[20];
        b[0] = new PhongTro(nct[1], 101, "", true);
        b[1] = new PhongTro(nct[1], 102, "", true, 20, new List<string> { "Nuoi thu cung" });
        b[2] = new PhongTro(nct[1], 103, "", true, 30, new List<string> { "Nuoi thu cung" });
        b[3] = new PhongTro(nct[1], 104, "", true, 20, new List<string> { "Nuoi thu cung" });
        b[4] = new PhongTro(nct[1], 105, "", true, 20, new List<string> { "Nuoi thu cung" });
        b[5] = new PhongTro(nct[1], 106, "", true);
        b[6] = new PhongTro(nct[1], 107, "", true);

        //Nguoi giam ho
        NguoiGiamHo[] ngh = new NguoiGiamHo[2];
        ngh[0] = new NguoiGiamHo ("Le Thi T", "Giao vien", CongCu.Tao(), new DateTime(1987, 08, 15), "Can Tho", 10000000);
        ngh[1] = new NguoiGiamHo("Nguyen Bao A", "Ky su", CongCu.Tao(), new DateTime(1975, 06, 07), "Dong Thap", 100000000);
        
        //NguoiThue
        NguoiThue[] nt = new NguoiThue[10];
        nt[0] = new NguoiThue("Nguyen Van A", "Sinh vien", CongCu.Tao() , new DateTime(2006, 4, 12), "Lam Dong", 10000000, ngh[0]);
        nt[1] = new NguoiThue("Huynh Thi B", "Giang vien", CongCu.Tao(), new DateTime(1979, 7, 23), "Dak Nong", 10000000);
        nt[2] = new NguoiThue("Tran Thanh C", "Hoc sinh", CongCu.Tao(), new DateTime(2008, 10, 4), "Hau Giang", 10000000, ngh[1]);
        nt[3] = new NguoiThue("Bui Viet D", "Sinh vien", CongCu.Tao(), new DateTime(2001, 3, 18), "Quy Nhon", 10000000);
        nt[4] = new NguoiThue("Le Cho E", "Sinh vien", CongCu.Tao(), new DateTime(2003, 12, 30), "Vinh Long", 10000000);
        nt[5] = new NguoiThue("La Van F", "Sinh vien", CongCu.Tao(), new DateTime(2000, 2, 25), "Binh Phuoc", 10000000);
        nt[6] = new NguoiThue("Nguyen Cong G", "Hoc sinh", CongCu.Tao(), new DateTime(2010, 9, 15), "Da Nang", 10000000, ngh[1]);
        nt[7] = new NguoiThue("Nguyen Le Phuong H", "Giang vien", CongCu.Tao(), new DateTime(1958, 3, 9), "Tien Giang", 10000000);
        nt[8] = new NguoiThue("Tran Van I", "That nghiep", CongCu.Tao(), new DateTime(1994, 1, 31), "Ha Noi", 10000000);
        nt[9] = new NguoiThue("Tran Minh K", "Hoc sinh", CongCu.Tao(), new DateTime(2000, 7, 1), "Bac Can", 10000000);

        //Cong ty
        CongTy[] ct = new CongTy[2];
        ct[0] = new CongTy("2 Vo Van Ngan, phuong Linh Trung, quan Thu Duc, thanh pho Ho Chi Minh", 44332211);

        //Nguoi Moi Gioi
        NguoiMoiGioi[] nmg = new NguoiMoiGioi[2];
        nmg[0] = new NguoiMoiGioi("Hai Tequila N", "Nguoi moi gioi", CongCu.Tao(), new DateTime(1802, 1, 20), "An Giang", ct[0]);
        nmg[1] = new NguoiMoiGioi("Vu Minh O", "Nguoi moi gioi", CongCu.Tao(), new DateTime(1780, 5, 23), "Can Tho");

        nt[0].NhapTro(DateTime.Now, a[0]);
        nt[1].NhapTro(DateTime.Now, a[1]);
        nt[2].NhapTro(DateTime.Now, a[2]);
        nt[3].NhapTro(DateTime.Now, a[3]);
        nt[4].NhapTro(DateTime.Now, a[4]);
        nt[5].NhapTro(DateTime.Now, a[5]);
        nt[6].NhapTro(DateTime.Now, a[6]);

        DocFile.Write<NguoiThue>("nguoithue.csv", nt.ToList());
        //List<Student> sts = ReadFile.Read2<Student>("student2.csv");
        //foreach (Student student in sts)
        //{
        //    student.Print();
        //}

    }
}