﻿using System;
using System.Collections.Generic;

#nullable disable

namespace p0.StoreApplication.Domain.Models
{
    public partial class Store
    {
        public Store()
        {
            StoreOrders = new HashSet<StoreOrder>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public short StoreId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }


        public override string ToString()
        {
            return Name + ": " + City + ", " + State;
        }
    }
}
