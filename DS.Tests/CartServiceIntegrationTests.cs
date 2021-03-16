using System.Collections.Generic;
using DryIoc;
using FluentAssertions;
using DS.BusinessLogic;
using DS.BusinessLogic.DiscountRules;
using DS.BusinessLogic.Repositories;
using DS.BusinessLogic.Services;
using NUnit.Framework;

namespace DS.Tests
{
	[TestFixture]
	[Parallelizable(ParallelScope.All)]
	public class CartServiceIntegrationTests : TestBase
	{
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			Container.Register<ICartService, CartService>();
			Container.Register<ICartItemsRepository, InMemoryCartItemsRepository>(Reuse.Singleton);
			Container.Register<IProductsRepository, InMemoryProductsRepository>(Reuse.Singleton);
			// compile-time known type
			var inMemoryProductsRepository = new InMemoryProductsRepository(new List<Product>()
			{
				new((int) ItemType.Vase, "Vase", 1.2m),
				new((int) ItemType.Mug, "Big mug", 1m, new PromotionXForYRule(2, 1.5m)),
				new((int) ItemType.Napkins, "Napkins pack", 0.45m, new PromotionXForYRule(3, 0.9m)),
			});
			Container.Use<IProductsRepository>(inMemoryProductsRepository);
			Container.RegisterInstance(inMemoryProductsRepository);

			Container.Register<IDiscountCalculator, RulesDiscountCalculator>();

			Container.Register<IRulesRepository, RulesRepository>(Reuse.Singleton);
			var inMemoryRules = new RulesRepository(new Dictionary<int, ICalculationRule<CartItem>>
			{
				{(int) ItemType.Mug, new PromotionXForYRule(2, 1.5m)},
				{(int) ItemType.Napkins, new PromotionXForYRule(3, 0.9m)}
			});
			Container.Use<IRulesRepository>(inMemoryRules);
			Container.RegisterInstance(inMemoryRules);
		}

		[Test, TestCaseSource(nameof(AddInput))]
		public void GetTotalTest(int[] productIds, decimal total)
		{
			var service = Container.Resolve<ICartService>();

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
			yield return new TestCaseData(new[] {(int) ItemType.Mug, (int) ItemType.Mug, (int) ItemType.Mug}, 2.5m);
			yield return new TestCaseData(new[] {(int) ItemType.Mug}, 1m);
			yield return new TestCaseData(new[] {(int) ItemType.Vase, (int) ItemType.Mug, (int) ItemType.Mug}, 2.7m);
		}
	}
}