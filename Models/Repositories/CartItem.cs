﻿namespace Models.Repositories
{
	public class CartItem
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}