using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDDongHo.Models
{
    public class Cart
    {
        public DONG_HO Dongho { get; set; }

        public int Soluong { get; set; }

        public Cart(DONG_HO dongho, int soluong)
        {
            Dongho = dongho;
            Soluong = soluong;
        }
    }
}