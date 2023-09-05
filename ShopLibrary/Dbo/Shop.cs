﻿namespace ShopLibrary.Dbo;

public class Shop : EntityWithId
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Product> Products { get; set; }
}