using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //NguoiThue
        NguoiThue[] a = new NguoiThue[10];
        a[0] = new NguoiThue("Nguyen Van A", "Sinh vien", 22110033, true, new DateTime(2004, 4, 12), "Lam Dong");
        a[1] = new NguoiThue("Huynh Thi B", "Giang vien", 21041325, false, new DateTime(1979, 7, 23), "Dak Nong");
        a[2] = new NguoiThue("Tran Thanh C", "Hoc sinh", 24123918, true, new DateTime(2008, 10, 4), "Hau Giang");
        a[3] = new NguoiThue("Bui Viet D", "Sinh vien", 12398120, true, new DateTime(2001, 3, 18), "Quy Nhon");
        a[4] = new NguoiThue("Le Cho E", "Sinh vien", 12832310, false, new DateTime(2003, 12, 30), "Vinh Long");
        a[5] = new NguoiThue("La Van F", "Sinh vien", 12309821, false, new DateTime(2000, 2, 25), "Binh Phuoc");
        a[6] = new NguoiThue("Nguyen Cong G", "Hoc sinh", 12903814, true, new DateTime(2010, 9, 15), "Da Nang");
        a[7] = new NguoiThue("Nguyen Le Phuong H", "Giang vien", 20391222, false, new DateTime(1958, 3, 9), "Tien Giang");
        a[8] = new NguoiThue("Tran Van I", "That nghiep", 41231232, true, new DateTime(1994, 1, 31), "Ha Noi");
        a[9] = new NguoiThue("Tran Minh K", "Hoc sinh", 12939182, true, new DateTime(2020, 7, 1), "Bac Can");

        //Nguoi Cho Thue
        NguoiChoThue[] b = new NguoiChoThue[4];
        b[0] = new NguoiChoThue("Le Hien L", "Doanh nhan", 21930123, false, new DateTime(1789, 5, 2), "Binh Duong");
        b[1] = new NguoiChoThue("Pham Trung M", "Buon ban", 12931233, true, new DateTime(1897, 9, 15), "Dong Nai");

        //Cong ty
        CongTy[] c = new CongTy[2];
        c[0] = new CongTy("2 Vo Van Ngan, phuong Linh Trung, quan Thu Duc, thanh pho Ho Chi Minh", 44332211);

        //Nguoi Moi Gioi
        NguoiMoiGioi[] d = new NguoiMoiGioi[2];
        d[0] = new NguoiMoiGioi("Hai Tequila N", "Nguoi moi gioi", 21321230, true, new DateTime(1802, 1, 20), "An Giang", c[0]);
        d[1] = new NguoiMoiGioi("Vu Minh O", "Nguoi moi gioi", 51298313, false, new DateTime(1780, 5, 23), "Can Tho");

        //Phong tro
        PhongTro[] e = new PhongTro[20];
        e[0] = new PhongTro(b[0], 101, "Cho", true, "");
    }
}