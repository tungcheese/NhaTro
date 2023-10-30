<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTro
{
    internal class NguoiThue
    {
=======
﻿public class NguoiThue: Nguoi
{
    int sophong;
    HopDong hopdong;
    NguoiGiamHo ngh;
    public NguoiThue(string hoten, string nghenghiep, string cccd, DateTime ngaysinh, string quequan, int sophong, NguoiGiamHo ngh=null)
        : base(hoten, nghenghiep, cccd, ngaysinh, quequan)
    {
        this.sophong = sophong;
        this.ngh = ngh;
>>>>>>> Stashed changes
    }
}
