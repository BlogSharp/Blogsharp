namespace BlogSharp.Core.Impl.Services.FileSystem.Native
{
	using System.IO;

	public class NativeFileEnums
	{
		public static NativeMethods.FileMode TranslateFileMode(FileMode mode)
		{
			switch (mode)
			{
				case FileMode.Append:
					return NativeMethods.FileMode.OPEN_ALWAYS;
				case FileMode.Create:
					return NativeMethods.FileMode.CREATE_ALWAYS;
				case FileMode.CreateNew:
					return NativeMethods.FileMode.CREATE_NEW;
				case FileMode.Open:
					return NativeMethods.FileMode.OPEN_EXISTING;
				case FileMode.OpenOrCreate:
					return NativeMethods.FileMode.OPEN_ALWAYS;
				case FileMode.Truncate:
					return NativeMethods.FileMode.TRUNCATE_EXISTING;
			}

			return NativeMethods.FileMode.OPEN_EXISTING;
		}

		public static NativeMethods.FileAccess TranslateFileAccess(FileAccess access)
		{
			return access == FileAccess.Read ? NativeMethods.FileAccess.GENERIC_READ : NativeMethods.FileAccess.GENERIC_WRITE;
		}

		public static NativeMethods.FileShare TranslateFileShare(FileShare share)
		{
			// Complete 1:1 mapping
			return (NativeMethods.FileShare) (int) share;
		}
	}
}