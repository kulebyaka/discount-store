using System.Collections.Generic;
using DryIoc;
using FluentAssertions;
using Models;
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