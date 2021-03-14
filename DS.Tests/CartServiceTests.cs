using System.Collections.Generic;
using DryIoc;
using FluentAssertions;
using Models;
using Models.DiscountRules;
using Models.Repositories;
using NUnit.Framework;

namespace DS.Tests
{
	[TestFixture]
	public class CartServiceTests
	{
		private IContainer _container;
		
		[SetUp]
		public void Setup()
		{
			_container = new Container();
			_container.Register<ICartService, CartService>();
			_container.Register<ICartItemsRepository, InMemoryCartItemsRepository>(Reuse.Singleton);
			_container.Register<IProductsRepository, InMemoryProductsRepository>(Reuse.Singleton);
			
			// compile-time known type
			var inMemoryProductsRepository = new InMemoryProductsRepository(new List<Product>(){
				new((int)ItemType.Vase, "Vase", 1.2m),
				new((int)ItemType.Mug, "Big mug", 1m),
				new((int)ItemType.Napkins, "Napkins pack", 0.45m),
			});
			_container.Use<IProductsRepository>(inMemoryProductsRepository);
			_container.RegisterInstance(inMemoryProductsRepository);
			
			_container.Register<IDiscountCalculator, RulesDiscountCalculator>();
			_container.Register<IRulesRepository, RulesRepository>(Reuse.Singleton);

		}

		[Test, TestCaseSource(nameof(AddInput))]
		public void GetTotalTest(int[] productIds, decimal total)
		{
			var service = _container.Resolve<ICartService>();

			foreach (int productId in productIds)
			{
				service.Add(productId);
			}

			var serviceTotal = service.GetTotal();
			serviceTotal.Should().Be(total);
		}
		
		// TestCaseData
		private static IEnumerable<TestCaseData> AddInput()
		{
			yield return new TestCaseData( new int[]{(int)ItemType.Mug, (int)ItemType.Mug, (int)ItemType.Mug}, 2.5m);
			yield return new TestCaseData( new int[]{(int)ItemType.Mug}, 1m);
			yield return new TestCaseData( new int[]{(int)ItemType.Vase, (int)ItemType.Mug, (int)ItemType.Mug}, 2.7m);
		}
	}
	
}