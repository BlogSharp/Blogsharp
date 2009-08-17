using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Impl.Tests.Plugins.Pingback
{
	using Core.Services.Post;
	using Impl.Plugins.Pingback;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class PingbackHandlerTests
	{
		private PingbackHandler handler;
		private IPingbackService pingbackService;

		[SetUp]
		public void SetUp()
		{
			this.pingbackService = MockRepository.GenerateMock<IPingbackService>();
			this.handler = new PingbackHandler(this.pingbackService);
		}

		[Test]
		public void Handler_forwards_request_to_service()
		{
			handler.Ping("hello", "hello");
			pingbackService.AssertWasCalled(x=>x.ProcessPingback("hello","hello"));
		}
	}
}
