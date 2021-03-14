using System.Collections.Generic;
using DryIoc;
using Models.Repositories;
using Models.Services;
using NUnit.Framework;

namespace DS.Tests
{
	[TestFixture]
	public class DiscountCalculatorTestFixture : TestBase
	{
		[SetUp]
		public override void Setup()
		{
			 base.Setup();
			 Container.Register<IDiscountCalculator, RulesDiscountCalculator>();
		}
		
		[Test]
		public void GetTotalTest(int[] productIds, decimal total)
		{
			var service = Container.Resolve<IDiscountCalculator>();
			service.CalculateDiscountedPrice(new List<CartItem>());
		}
	}
}