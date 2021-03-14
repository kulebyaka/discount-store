﻿using Models.DiscountRules;
using Models.Repositories;

namespace Models
{
	public class Product : IDbEntity
	{
		public int Id { get;}
		public string Name { get; }
		public decimal Price { get; }
		
		public ICalculationRule<CartItem> CalculationRule { get; }

		public Product(int id, string name, decimal price, ICalculationRule<CartItem>  calculationRule)
		{
			Id = id;
			Name = name;
			Price = price;
			CalculationRule = calculationRule;
		}
		
		public Product(int id, string name, decimal price)
		{
			Id = id;
			Name = name;
			Price = price;
		}
	}
}