using System;

namespace Stellers.Hawkeye.Common.Disposable
{
	/// <summary>
	/// Utility class to provide basic IDispose implementation for extension.
	/// </summary>
	/// <seealso cref="T:System.IDisposable"/>
	public class Disposable : IDisposable
	{
		/// <summary>
		/// true if this object is disposed.
		/// </summary>
		private bool _isDisposed;

		/// <summary>
		/// Finalizes an instance of the Deloitte.Radia.Common.Disposable class.
		/// </summary>
		~Disposable()
		{
			Dispose(false);
		}

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		/// <seealso cref="M:System.IDisposable.Dispose()"/>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose implementation.
		/// </summary>
		protected virtual void DisposeImplementation()
		{
		}

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		/// <param name="disposing">
		/// true to release both managed and unmanaged resources; false to release only unmanaged resources.
		/// </param>
		private void Dispose(bool disposing)
		{
			if (!_isDisposed && disposing)
			{
				DisposeImplementation();
			}

			_isDisposed = true;
		}
	}
}