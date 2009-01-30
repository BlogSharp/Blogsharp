using BlogSharp.Db4o.Impl;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Rhino.Mocks;
using Xunit;

namespace BlogSharp.Db4o.Tests.Impl
{
	public class CastleObjectContainerWrapperTests
	{
		private readonly CastleObjectContainerWrapper wrapper;

		public CastleObjectContainerWrapperTests()
		{
			wrapper = new CastleObjectContainerWrapper();
		}

		[Fact]
		public void Can_wrap_ObjectContainer()
		{
			var mock = MockRepository.GenerateMock<IExtObjectContainer>();
			var wrapped = wrapper.Wrap(mock, null, null);
			Assert.NotNull(wrapped);
			Assert.IsAssignableFrom(typeof (IObjectContainer), wrapped);
			Assert.IsAssignableFrom(typeof (IExtObjectContainer), wrapped);
			Assert.IsAssignableFrom(typeof (IObjectContainerProxy), wrapped);
		}

		[Fact]
		public void InvocationHandler_returns_the_interceptor()
		{
			var mock = MockRepository.GenerateMock<IExtObjectContainer>();
			var wrapped = (IObjectContainerProxy) wrapper.Wrap(mock, null, null);
			var interceptor = wrapped.InvocationHandler;
			Assert.NotNull(interceptor);
		}

		[Fact]
		public void Can_unwrap_ObjectContainer()
		{
			var mock = MockRepository.GenerateMock<IExtObjectContainer>();
			var wrapped = wrapper.Wrap(mock, null, null);
			var unwrapped = wrapper.UnWrap(wrapped);
			Assert.Equal(mock, unwrapped);
		}

		[Fact]
		public void Calls_close_delegate_when_Close_is_called()
		{
			IExtObjectContainer container = MockRepository.GenerateMock<IExtObjectContainer>();
			IObjectContainerWrapper wrapper = new CastleObjectContainerWrapper();
			bool closeCalled = false, disposeCalled = false;
			IExtObjectContainer wrapped = wrapper.Wrap(container,
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.Equal(container, c);
			                                           		closeCalled = true;
			                                           	},
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.Equal(container, c);
			                                           		disposeCalled = true;
			                                           	});
			wrapped.Close();
			Assert.True(closeCalled);
			Assert.False(disposeCalled);
		}

		[Fact]
		public void Calls_dispose_delegate_when_Dispose_is_called()
		{
			IExtObjectContainer container = MockRepository.GenerateMock<IExtObjectContainer>();
			IObjectContainerWrapper wrapper = new CastleObjectContainerWrapper();
			bool closeCalled = false, disposeCalled = false;
			IExtObjectContainer wrapped = wrapper.Wrap(container,
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.Equal(container, c);
			                                           		closeCalled = true;
			                                           	},
			                                           delegate(IObjectContainer c)
			                                           	{
			                                           		Assert.Equal(container, c);
			                                           		disposeCalled = true;
			                                           	});
			wrapped.Dispose();
			Assert.True(closeCalled);
			Assert.True(disposeCalled);
		}
	}
}