﻿namespace Models.Repositories
{
	public class CartItem
	{
		public int ProductId { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}