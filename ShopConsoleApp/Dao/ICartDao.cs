﻿using ShopConsoleApp.Models;

namespace ShopConsoleApp.Dao;

public interface ICartDao
{
    public void AddCart(CartModel cart);
    public void AddProduct(CartModel cart, ProductModel product, int count);
    public CartModel GetCart(Guid userId);
}