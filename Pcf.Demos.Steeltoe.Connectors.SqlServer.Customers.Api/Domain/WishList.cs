﻿namespace Pcf.Demos.Steeltoe.Connectors.SqlServer.Customers.Api.Domain
{
    public class WishList
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}