﻿using System;
using System.Collections.Generic;

#nullable disable

namespace p0.StoreApplication.Domain.Models
{
    public partial class OrderProduct
    {
        public int OrderProductId { get; set; }
        public short OrderId { get; set; }
        public short ProductId { get; set; }
        public short Quantity { get; set; }

        public virtual StoreOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
