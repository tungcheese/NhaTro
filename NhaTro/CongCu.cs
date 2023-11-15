static class CongCu
{
    public static string Tao()
    {
        Random rnd = new Random();
        int mavung = rnd.Next(97);
        int gioitinh = rnd.Next(4);
        int namsinh = rnd.Next(100);
        int socuoi = rnd.Next(100000);
        return "0" + mavung.ToString() + gioitinh.ToString() + namsinh.ToString() + "0" + socuoi.ToString();
    }

    public static bool GioiTinh(string cccd)
    {
        int gioitinh = Int32.Parse(cccd.Substring(3, 1));
        return gioitinh % 2 == 0;
    }

    public static bool TruTien(Nguoi a, Nguoi b, int sotien)
    {
        if (a.Tien >= sotien)
        {
            a.Tien -= sotien;
            b.Tien += sotien;
            return true;
        }
        return false;
    }
}