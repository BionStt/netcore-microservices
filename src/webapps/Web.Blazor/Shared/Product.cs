﻿namespace Web.Blazor.Shared;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ImgUrl { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }
}