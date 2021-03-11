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
		public void GetTotalTest(IEnumerable<Item> items, double total)
		{
			var service = _container.Resolve<ICartService>();
			
			foreach (var item in items)
			{
				service.Add(item);
			}

			service.GetTotal().Should().Be(total);
		}
		
		// TestCaseData
		private static IEnumerable<TestCaseData> AddInput()
		{
			var x = new List<Item>();
			x.Add(new Item(3));
			x.Add(new Item(4));
			x.Add(new Item(1));
			yield return new TestCaseData(x, 8);
		}
	}
	
}