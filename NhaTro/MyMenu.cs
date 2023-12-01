using static CongCu;
static class MyMenu
{
    /// <summary>
    /// Program cho nguoithue, nguoichothue va nguoimoigioi quan ly cac muc tieu
    /// </summary>
    /// <param name="nguoithue"></param>
    public static void Program_NguoiThue(NguoiThue nguoithue)
    {
        bool check = true;
        while (check)
        {
            switch (NhapSo("Ban muon lam gi?: \n" +
                "1. Tim phong: \t\t2. Quan ly phong: \n" +
                "3. In thong tin: \t4. Nap tien: \n" +
                "0. Dang xuat: ", 0, 4))
            {
                case 1:
                    if (NguoiThuePT(nguoithue) == null) NguoiThue_TimPhong(nguoithue);
                    else Console.WriteLine("*\tBan da so huu mot phong tro roi");
                    break;
                case 2:
                    if (NguoiThuePT(nguoithue) != null) NguoiThue_QuanLy(nguoithue);
                    else Console.WriteLine("*\tBan chua co phong tro nao!");
                    break;
                case 3:
                    nguoithue.In();
                    continue;
                case 4:
                    nguoithue.NapTien(NhapSo("Nhap so tien can nap: ", 0));
                    Console.WriteLine("*\tNap tien thanh cong!");
                    continue;
                case 0:
                    Console.WriteLine("*\tDang xuat thanh cong!");
                    check = false;
                    break;
            }
        }
    }
    public static void Program_NguoiChoThue(NguoiChoThue nguoichothue)
    {
        bool check = true;
        while (check)
        {
            switch (NhapSo("Ban muon lam gi?: \n" +
                "1. Kiem tra yeu cau: \t2. Quan ly nha tro: \n" +
                "3. In thong tin: \t4. Nap tien: \n" +
                "0. Dang xuat: ", 0, 4))
            {
                case 1:
                    if (nguoichothue.PhongTro.Any()) nguoichothue.KiemTraYeuCau();
                    break;
                case 2:
                    if (nguoichothue.PhongTro.Any()) NguoiChoThue_QuanLy(nguoichothue);
                    else Console.WriteLine("Ban chua co phong tro nao!");
                    break;
                case 3:
                    nguoichothue.In();
                    continue;
                case 4:
                    nguoichothue.NapTien(NhapSo("Nhap so tien can nap: ", 0));
                    Console.WriteLine("*\tNap tien thanh cong!");
                    continue;
                case 0:
                    Console.WriteLine("*\tDang xuat thanh cong!");
                    check = false;
                    break;
            }
        }
    }
    public static void Program_NguoiMoiGioi(NguoiMoiGioi nguoimoigioi)
    {
        bool check = true;
        while (check)
        {
            switch (NhapSo("Ban muon lam gi?: \n" +
                "1. Danh sach moi gioi: \t2. In tien hoa hong: \n" +
                "3. In thong tin: \t4. Cong ty hien tai: \n" +
                "0. Dang xuat: ", 0, 4))
            {
                case 1:
                    nguoimoigioi.DanhSachMoiGioi();
                    break;
                case 2:
                    nguoimoigioi.DanhSachMoiGioi();
                    break;
                case 3:
                    nguoimoigioi.In();
                    break;
                case 4:
                    nguoimoigioi.DanhSachMoiGioi();
                    break;
                case 0:
                    Console.WriteLine("*\tDang xuat thanh cong!");
                    check = false;
                    break;
            }
        }
    }
}