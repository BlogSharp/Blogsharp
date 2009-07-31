namespace BlogSharp.Core.Impl.Tests.Services.Http
{
	using System;
	using System.Threading;
	using Impl.Services.Http;
	using NUnit.Framework;

	[TestFixture,Explicit]
	public class HttpClientTests
	{
		private HttpClient client;
		private void WaitUntilTrue(Func<bool> item,int waitDuration)
		{
			while(!item())
				Thread.Sleep(waitDuration);
		}
		[SetUp]
		public void SetUp()
		{
			this.client=new HttpClient();
		}

		[Test, Timeout(5)]
		public void Can_get_string_data_sync()
		{
			string str = this.client.DownloadString("http://google.com");
			Assert.That(str, Is.Not.Empty.Or.Null);

			str = this.client.DownloadString(new Uri("http://google.com"));
			Assert.That(str, Is.Not.Empty.Or.Null);
		}

		[Test,Timeout(5000)]
		public void Can_get_string_data_async()
		{
			bool finished = false;
			this.client.DownloadStringAsync("http://google.com",
			                                             delegate(string result, object state)
			                                             	{
			                                             		finished = true;
			                                             		Assert.That(state, Is.EqualTo("osman"));
			                                             		Assert.That(result, Is.Not.Null.Or.Empty);
			                                             	}, "osman");
			WaitUntilTrue(() => finished, 1000);


			finished = false;
			this.client.DownloadStringAsync(new Uri("http://google.com"), 
											 delegate(string result, object state)
											 {
												 finished = true;
												 Assert.That(state, Is.EqualTo("osman"));
												 Assert.That(result, Is.Not.Null.Or.Empty);
											 }, "osman");
			WaitUntilTrue(() => finished, 1000);
		}




		[Test, Timeout(5)]
		public void Can_get_data_sync()
		{
			var data = this.client.DownloadData("http://google.com");
			Assert.That(data,Has.Length.GreaterThan(0));

			data = this.client.DownloadData(new Uri("http://google.com"));
			Assert.That(data, Has.Length.GreaterThan(0));
		}


		[Test, Timeout(5)]
		public void Can_get_data_async()
		{
			bool finished = false;
			this.client.DownloadDataAsync("http://google.com", delegate(byte[] result, object state)
			                                                              	{
			                                                              		finished = true;
			                                                              		Assert.That(state, Is.EqualTo("osman"));
			                                                              		Assert.That(result, Is.Not.Null.Or.Empty);
			                                                              	}, "osman");
			WaitUntilTrue(()=>finished,1000);


			this.client.DownloadDataAsync(new Uri("http://google.com"), delegate(byte[] result, object state)
			{
				finished = true;
				Assert.That(state, Is.EqualTo("osman"));
				Assert.That(result, Is.Not.Null.Or.Empty);
			}, "osman");
			WaitUntilTrue(() => finished, 1000);
		}

	}
}
