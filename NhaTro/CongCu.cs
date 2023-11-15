static class CongCu
{
    public static string Tao()
    {
        Random rnd = new Random();
        int mavung = rnd.Next(97);
        string smavung = (mavung < 10) ? "00" : "0";
        int gioitinh = rnd.Next(4);
        int namsinh = rnd.Next(100);
        string snamsinh = (namsinh < 10) ? "0" : "";
        string socuoi = "";
        for (int i = 0; i<5;i++)
        {
            socuoi+=rnd.Next(10).ToString();
        }
        return smavung + mavung.ToString() + gioitinh.ToString() + snamsinh + namsinh.ToString() + "0" + socuoi;
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