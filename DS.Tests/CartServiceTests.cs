using System.Collections.Generic;
using FluentAssertions;
using Models;
using NUnit.Framework;

namespace DS.Tests
{
	[TestFixture]
	public class CartServiceTests
	{
		private ICartService _service;
		
		[SetUp]
		public void Setup()
		{
			// TODO: IOC injections
			_service = new CartService();
		}

		[Test, TestCaseSource(nameof(AddInput))]
		public void GetTotalTest(IEnumerable<Item> items, double total)
		{
			foreach (var item in items)
			{
				_service.Add(item);
			}

			_service.GetTotal().Should().Be(total);
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