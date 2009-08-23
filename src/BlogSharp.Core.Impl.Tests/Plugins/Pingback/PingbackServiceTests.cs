namespace BlogSharp.Core.Impl.Tests.Plugins.Pingback
{
	using System;
	using System.Collections;
	using System.Net.NetworkInformation;
	using System.Runtime.Remoting;
	using System.Runtime.Remoting.Channels;
	using System.Runtime.Remoting.Channels.Http;
	using CookComputing.XmlRpc;
	using Core.Services.Http;
	using Core.Services.Post;
	using Event.PostEvents;
	using Impl.Plugins.Pingback;
	using Model;
	using NUnit.Framework;
	using Rhino.Mocks;

	public class FakePingbackService : SystemMethodsBase
	{
		public static string TargetUri { get; set; }
		public static string SourceUri { get; set; }


		[XmlRpcMethod("pingback.ping", Description = "Pingback server implementation")] 
		public string Notify(string source,string target)
		{
			SourceUri = source;
			TargetUri = target;
			return "Thank you";
		}

	}
	[TestFixture]
	public class PingbackServiceTests
	{
		private IPingbackService pingbackService;
		private HttpChannel channel;
		private IPostService postService;
		private IHttpClient httpClient;
		[SetUp]
		public void SetUp()
		{
			FakePingbackService.SourceUri = "";
			FakePingbackService.TargetUri = "";
			this.postService = MockRepository.GenerateMock<IPostService>();
			this.httpClient = MockRepository.GenerateMock<IHttpClient>();
			this.pingbackService = new PingbackService(this.postService, this.httpClient);

			IDictionary props = new Hashtable();
			props["name"] = "MyHttpChannel";
			props["port"] = 2011;
			channel = new HttpChannel(props,null,new XmlRpcServerFormatterSinkProvider());
			ChannelServices.RegisterChannel(channel, false);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof (FakePingbackService),"pingback.rem",WellKnownObjectMode.Singleton);
		}

		[TearDown]
		public void TearDown()
		{
			ChannelServices.UnregisterChannel(channel);
		}

		[Test, TestCaseSource("regexCases")]
		public void RegEx_is_correct(string text,bool result)
		{
			var regex = PingbackService.UriRegEx;
			Assert.That(regex.IsMatch(text), Is.EqualTo(result));
		}

		private object[] regexCases = new object[]
		                                  	{
		                                  		new object[] {"http://tunatoksoz.com/", true},
		                                  		new object[] {"http://tunatoksoz.com/tuna.aspx", true},
		                                  		new object[] {"http://tunatoksoz", false}
		                                  	};

		[Test]
		public void Ping_throws_exception_on_empty_parameters()
		{
			var uri = new Uri("http://google.com");
			Assert.Throws<ArgumentNullException>(() => this.pingbackService.SendPingback(null, uri, uri));
			Assert.Throws<ArgumentNullException>(() => this.pingbackService.SendPingback(uri, null, uri));
			Assert.Throws<ArgumentNullException>(() => this.pingbackService.SendPingback(uri, uri, null));
		}

		[Test]
		public void Can_send_ping()
		{
			var pingbackUri = new Uri("http://localhost:2011/pingback.rem");
			var sourceUri = new Uri("http://google.com/a");
			var targetUri = new Uri("http://google.com/b");
			pingbackService.SendPingback(pingbackUri, sourceUri, targetUri);
			Assert.That(FakePingbackService.SourceUri,Is.EqualTo("http://google.com/a"));
			Assert.That(FakePingbackService.TargetUri, Is.EqualTo("http://google.com/b"));
		}

		[Test]
		public void Can_handle_new_post()
		{
			var post = new Post {Content = "this web site is cool: http://google.com"};
			httpClient.Expect(x => x.DownloadString("http://google.com"))
				.Return("<link rel=\"pingback\" href=\"http://localhost:2011/pingback.rem\"/>");

			pingbackService.HandleNewPost(new PostAddedEventArgs(null,post));

			httpClient.AssertWasCalled(x => x.DownloadString(Arg<string>.Is.Anything));
			Assert.That(FakePingbackService.SourceUri,Is.Not.Null.Or.Not.Empty);
			Assert.That(FakePingbackService.TargetUri, Is.Not.Null.Or.Not.Empty);
		}

		[Test,Ignore]
		public void Can_process_pingback()
		{
			var mysite = "http://mysite.com/hello-world.aspx";
			var yoursite = "http://yoursite.com/hello-world";
			this.httpClient.Expect(x => x.DownloadString(mysite)).Return("bla bla <a href=\"http://yoursite.com/hello-world\">hello</a>");
			pingbackService.ProcessPingback("http://mysite.com/hello-world.aspx","http://yoursite.com/hello-world");
		}


	}
}
