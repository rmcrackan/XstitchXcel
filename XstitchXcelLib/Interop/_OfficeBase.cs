using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace XstitchXcelLib.Interop
{
	public abstract class OfficeBase : IDisposable
	{
		protected string FileName { get; }

		private Stack<object> officeObjects { get; } = new Stack<object>();

		protected OfficeBase(string fileName)
		{
			FileName = fileName;
		}

		public T Push<T>(T obj)
		{
			if (!officeObjects.Contains(obj))
				officeObjects.Push(obj);
			return obj;
		}

		protected abstract void DisposeHook();

		#region IDispose
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool _disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				DisposeHook();

				foreach (var obj in officeObjects)
				{
					if (obj is null)
						continue;
					if (obj is IDisposable disposable)
						disposable?.Dispose();

					while (Marshal.ReleaseComObject(obj) > 0) { }
				}
			}

			_disposed = true;
		}
		#endregion
	}
}
