using System.Collections.Generic;
using System.Linq;
using DryIoc;
using FluentAssertions;
using DS.BusinessLogic.DiscountRules;
using DS.BusinessLogic.Repositories;
using DS.BusinessLogic.Services;
using Moq;
using NUnit.Framework;

namespace DS.Tests
{
	[TestFixture]
	public class PriceCalculatorTestFixture : TestBase
	{
		private Dictionary<int, ICalculationRule<CartItem, decimal>> _rules = new();

		[SetUp]
		public override void Setup()
		{
			base.Setup();
			Container.Register<IPriceCalculator, PriceCalculator>();
			Mock<IRulesRepository> rulesRepository = new Mock<IRulesRepository>();
			rulesRepository.Setup(calculator => calculator.GetByProductId(It.IsAny<int>()))
				.Returns((int a) =>
				{
					bool exist = _rules.TryGetValue(a, out var retValue);
					return exist ? retValue : null;
				});
			Container.Use(rulesRepository.Object);
			Container.RegisterInstance(rulesRepository.Object);

			var logger = CreateLogger<PriceCalculator>(a => logMessages.Add(a));
			Container.Use(logger.Object);
			Container.RegisterInstance(logger.Object);
		}

		[Test, TestCaseSource(nameof(AddInput))]
		public void CalculateDiscountedPriceTest(IEnumerable<CartItem> items, Dictionary<int, ICalculationRule<CartItem, decimal>> rules, decimal result)
		{
			var service = Container.Resolve<IPriceCalculator>();
			_rules = rules;

			decimal total = service.Calculate(items.ToList());

			result.Should().Be(total);
			logMessages.Should().HaveCountGreaterThan(0);
		}

		private static IEnumerable<TestCaseData> AddInput()
		{
			//OrdinaryRule Test
			yield return new TestCaseData(
				new[]
				{
					new CartItem() {ProductId = 1, Price = 2, Quantity = 2}
				},
				new Dictionary<int, ICalculationRule<CartItem, decimal>>
				{
					{1, new OrdinaryCalculationRule()}
				},
				4m);

			//Empty RuleStorage Test
			yield return new TestCaseData(
				new[]
				{
					new CartItem() {ProductId = 1, Price = 2, Quantity = 2}
				},
				new Dictionary<int, ICalculationRule<CartItem, decimal>>
				{
				},
				4m);

			// costs adding test
			yield return new TestCaseData(
				new[]
				{
					new CartItem()
					{
						ProductId = 1,
						Price = 2,
						Quantity = 2
					},
					new CartItem()
					{
						ProductId = 2,
						Price = 2,
						Quantity = 2
					}
				},
				new Dictionary<int, ICalculationRule<CartItem, decimal>>
				{
				},
				8m);

			//Test XForYRule Quantity is divided by X
			yield return new TestCaseData(
				new[]
				{
					new CartItem()
					{
						ProductId = 1,
						Price = 2,
						Quantity = 6
					},
				},
				new Dictionary<int, ICalculationRule<CartItem, decimal>>
				{
					{1, new PromotionXForYRule(3, 1)},
				},
				2m);

			//Test XForYRule Quantity is not divided by X
			yield return new TestCaseData(
				new[]
				{
					new CartItem()
					{
						ProductId = 1,
						Price = 2,
						Quantity = 7
					},
				},
				new Dictionary<int, ICalculationRule<CartItem, decimal>>
				{
					{1, new PromotionXForYRule(3, 1)},
				},
				4m);
		}
	}
}