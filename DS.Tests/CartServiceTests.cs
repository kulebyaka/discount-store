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
		public void GetTotalTest(decimal total)
		{
			var service = _container.Resolve<ICartService>();

			service.Add((int)ItemType.Mug);
			service.Add((int)ItemType.Mug);
			service.Add((int)ItemType.Mug);
			service.Add((int)ItemType.Vase);
			service.Add((int)ItemType.Mug);

			service.GetTotal().Should().Be(total);
		}
		
		// TestCaseData
		private static IEnumerable<TestCaseData> AddInput()
		{
			yield return null; //new TestCaseData(x, 9);
		}
	}
	
}