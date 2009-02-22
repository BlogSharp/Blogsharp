namespace BlogSharp.Db4o.Tests.Impl
{
	using Db4o.Impl;
	using Db4objects.Db4o;
	using Db4objects.Db4o.Ext;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class CastleObjectContainerWrapperTests
	{
		private CastleObjectContainerWrapper wrapper;

		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			wrapper = new CastleObjectContainerWrapper();
		}

		#endregion


		[Test]
		public void Calls_close_delegate_when_Close_is_called()
		{
			IExtObjectContainer container = MockRepository.GenerateMock<IExtObjectContainer>();
			IObjectContainerWrapper wrapper = new CastleObjectContainerWrapper();
			bool closeCalled = false, disposeCalled = false;
			IExtObjectContainer wrapped = wrapper.Wrap(container,
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.AreEqual(container, c);
			                                           		closeCalled = true;
			                                           	},
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.AreEqual(container, c);
			                                           		disposeCalled = true;
			                                           	});
			wrapped.Close();
			Assert.True(closeCalled);
			Assert.False(disposeCalled);
		}

		[Test]
		public void Calls_dispose_delegate_when_Dispose_is_called()
		{
			IExtObjectContainer container = MockRepository.GenerateMock<IExtObjectContainer>();
			IObjectContainerWrapper wrapper = new CastleObjectContainerWrapper();
			bool closeCalled = false, disposeCalled = false;
			IExtObjectContainer wrapped = wrapper.Wrap(container,
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.AreEqual(container, c);
			                                           		closeCalled = true;
			                                           	},
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.AreEqual(container, c);
			                                           		disposeCalled = true;
			                                           	});
			wrapped.Dispose();
			Assert.True(closeCalled);
			Assert.True(disposeCalled);
		}

		[Test]
		public void Can_unwrap_ObjectContainer()
		{
			var mock = MockRepository.GenerateMock<IExtObjectContainer>();
			var wrapped = wrapper.Wrap(mock, null, null);
			var unwrapped = wrapper.UnWrap(wrapped);
			Assert.AreEqual(mock, unwrapped);
		}

		[Test]
		public void Can_wrap_ObjectContainer()
		{
			var mock = MockRepository.GenerateMock<IExtObjectContainer>();
			var wrapped = wrapper.Wrap(mock, null, null);
			Assert.NotNull(wrapped);
			Assert.That(wrapped != null);
			Assert.That(wrapped as IObjectContainerProxy != null);
		}

		[Test]
		public void InvocationHandler_returns_the_interceptor()
		{
			var mock = MockRepository.GenerateMock<IExtObjectContainer>();
			var wrapped = (IObjectContainerProxy) wrapper.Wrap(mock, null, null);
			var interceptor = wrapped.InvocationHandler;
			Assert.NotNull(interceptor);
		}
	}
}