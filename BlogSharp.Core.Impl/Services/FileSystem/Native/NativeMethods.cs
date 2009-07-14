namespace BlogSharp.Core.Impl.Services.FileSystem.Native
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    public static class NativeMethods
    {
        private const string KERNEL32 = "kernel32.dll";

        // Error codes
        internal const int ERROR_SUCCESS = 0;
        internal const int ERROR_FILE_NOT_FOUND = 2;
        internal const int ERROR_NO_MORE_FILES = 18;
        internal const int ERROR_RECOVERY_NOT_NEEDED = 6821;

        // Create file flags
        internal const int FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;

        // Function control codes / masks
        private const int METHOD_BUFFERED = 0x00000000;
        private const int FILE_WRITE_DATA = 0x00000002;
        private const int FILE_DEVICE_FILE_SYSTEM = 0x00000009;

        private const int ROLLFORWARD_REDO_FUNCTION = 84;
        private const int ROLLFORWARD_UNDO_FUNCTION = 85;
        private const int START_RM_FUNCTION = 86;
        private const int SHUTDOWN_RM_FUNCTION = 87;
        private const int CREATE_SECONDARY_RM_FUNCTION = 90;

        // KTM IOCTLs
        internal const int FSCTL_TXFS_ROLLFORWARD_REDO =
            (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_WRITE_DATA << 14) | (ROLLFORWARD_REDO_FUNCTION << 2) | METHOD_BUFFERED;

        internal const int FSCTL_TXFS_ROLLFORWARD_UNDO =
            (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_WRITE_DATA << 14) | (ROLLFORWARD_UNDO_FUNCTION << 2) | METHOD_BUFFERED;

        internal const int FSCTL_TXFS_START_RM =
            (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_WRITE_DATA << 14) | (START_RM_FUNCTION << 2) | METHOD_BUFFERED;

        internal const int FSCTL_TXFS_SHUTDOWN_RM =
            (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_WRITE_DATA << 14) | (SHUTDOWN_RM_FUNCTION << 2) | METHOD_BUFFERED;

        internal const int FSCTL_TXFS_CREATE_SECONDARY_RM =
            (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_WRITE_DATA << 14) | (CREATE_SECONDARY_RM_FUNCTION << 2) | METHOD_BUFFERED;

        // KTM Start flags
        internal const int TXFS_START_RM_FLAG_LOG_CONTAINER_COUNT_MAX = 0x00000001;
        internal const int TXFS_START_RM_FLAG_LOG_CONTAINER_COUNT_MIN = 0x00000002;
        internal const int TXFS_START_RM_FLAG_LOG_CONTAINER_SIZE = 0x00000004;
        internal const int TXFS_START_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS = 0x00000008;
        internal const int TXFS_START_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT = 0x00000010;
        internal const int TXFS_START_RM_FLAG_LOG_AUTO_SHRINK_PERCENTAGE = 0x00000020;
        internal const int TXFS_START_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX = 0x00000040;
        internal const int TXFS_START_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN = 0x00000080;

        internal const int TXFS_START_RM_FLAG_RECOVER_BEST_EFFORT = 0x00000200;
        internal const int TXFS_START_RM_FLAG_LOGGING_MODE = 0x00000400;
        internal const int TXFS_START_RM_FLAG_PRESERVE_CHANGES = 0x00000800;

        // KTM Logging modes
        internal const int TXFS_LOGGING_MODE_SIMPLE = 0x0001;
        internal const int TXFS_LOGGING_MODE_FULL = 0x0002;

        public enum FileAccess
        {
            GENERIC_READ = unchecked((int)0x80000000),
            GENERIC_WRITE = 0x40000000
        }

        [Flags]
        public enum FileShare
        {
            FILE_SHARE_NONE = 0x00,
            FILE_SHARE_READ = 0x01,
            FILE_SHARE_WRITE = 0x02,
            FILE_SHARE_DELETE = 0x04
        }

        public enum FileMode
        {
            CREATE_NEW = 1,
            CREATE_ALWAYS = 2,
            OPEN_EXISTING = 3,
            OPEN_ALWAYS = 4,
            TRUNCATE_EXISTING = 5
        }

        [Flags]
        internal enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,
            COPY_FILE_COPY_SYMLINK = 0x00000800
        }

        [Flags]
        public enum MoveFileFlags : uint
        {
            MOVEFILE_REPLACE_EXISTING = 0x00000001,
            MOVEFILE_COPY_ALLOWED = 0x00000002,
            MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004,
            MOVEFILE_WRITE_THROUGH = 0x00000008,
            MOVEFILE_CREATE_HARDLINK = 0x00000010,
            MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
        }

        public enum FINDEX_INFO_LEVELS
        {
            FindExInfoStandard,
            FindExInfoMaxInfoLevel
        }

        public enum FINDEX_SEARCH_OPS
        {
            FindExSearchNameMatch,
            FindExSearchLimitToDirectories,
            FindExSearchLimitToDevices,
            FindExSearchMaxSearchOp
        }
#pragma warning disable 0649
        public struct FILETIME
        {
            public uint DateTimeHigh;
            public uint DateTimeLow;
        }
#pragma warning restore 0649

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WIN32_FIND_DATA
        {
            public int dwFileAttributes;
            public NativeMethods.FILETIME ftCreationTime;
            public NativeMethods.FILETIME ftLastAccessTime;
            public NativeMethods.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TXFS_START_RM_INFORMATION
        {
            public UInt32 Flags;

            public UInt64 LogContainerSize;
            public UInt32 LogContainerCountMin;
            public UInt32 LogContainerCountMax;

            public UInt32 LogGrowthIncrement;
            public UInt32 LogAutoShrinkPercentage;

            public UInt32 TmLogPathOffset;
            public UInt16 TmLogPathLength;

            public UInt16 LoggingMode;
            public UInt16 LogPathLength;
            public UInt16 Reserved;

            public IntPtr LogPath;
        }

        //
        // Standard file operations
        //

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeFileHandle CreateFile(
            [In] string lpFileName,
            [In] NativeMethods.FileAccess dwDesiredAccess,
            [In] NativeMethods.FileShare dwShareMode,
            [In] IntPtr lpSecurityAttributes,
            [In] NativeMethods.FileMode dwCreationDisposition,
            [In] int dwFlagsAndAttributes,
            [In] IntPtr hTemplateFile);

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextFile(
            [In] SafeFileHandle hFindFile,
            [Out] out WIN32_FIND_DATA lpFindFileData);


        //
        // Transacted file operations
        //

        #region transactional operations

        [DllImport(KERNEL32, EntryPoint = "CreateFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeFileHandle CreateFileTransacted(
            [In] string lpFileName,
            [In] NativeMethods.FileAccess dwDesiredAccess,
            [In] NativeMethods.FileShare dwShareMode,
            [In] IntPtr lpSecurityAttributes,
            [In] NativeMethods.FileMode dwCreationDisposition,
            [In] int dwFlagsAndAttributes,
            [In] IntPtr hTemplateFile,
            [In] KtmTransactionHandle hTransaction,
            [In] IntPtr pusMiniVersion,
            [In] IntPtr pExtendedParameter);

        [DllImport(KERNEL32, EntryPoint = "CopyFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CopyFileTransacted(
            [In] string lpExistingFileName,
            [In] string lpNewFileName,
            [In] IntPtr lpProgressRoutine,
            [In] IntPtr lpData,
            [In] [MarshalAs(UnmanagedType.Bool)] ref bool pbCancel,
            [In] CopyFileFlags dwCopyFlags,
            [In] KtmTransactionHandle hTransaction);

        [DllImport(KERNEL32, EntryPoint = "DeleteFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteFileTransacted(
            [In] string lpFileName,
            [In] KtmTransactionHandle hTransaction);

        [DllImport(KERNEL32, EntryPoint = "FindFirstFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeFileHandle FindFirstFileTransacted(
            [In] string lpDirSpec,
            [In] FINDEX_INFO_LEVELS fInfoLevelId,
            [Out] out WIN32_FIND_DATA lpFindFileData,
            [In] FINDEX_SEARCH_OPS fSearchOp,
            [In] IntPtr lpSearchFilter,
            [In] int dwAdditionalFlags,
            [In] KtmTransactionHandle hTransaction);

        [DllImport(KERNEL32, EntryPoint = "MoveFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool MoveFileTransacted(
            [In] string lpExistingFileName,
            [In] string lpNewFileName,
            [In] IntPtr lpProgressRoutine,
            [In] IntPtr lpData,
            [In] MoveFileFlags dwFlags,
            [In] KtmTransactionHandle hTransaction);

        #endregion

        #region nontransactional operations

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DeleteFile(string path);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetFileSize(SafeFileHandle hFile, out int highSize);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern SafeFileHandle FindFirstFile(string fileName, [In, Out] WIN32_FIND_DATA data);

        [DllImport("kernel32.dll")]
        internal static extern int GetFileType(SafeFileHandle handle);

        #endregion

        [DllImport(KERNEL32, EntryPoint = "DeviceIoControl", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeviceIoControl(
            [In] SafeFileHandle hDevice,
            [In] int dwIoControlCode,
            [In] IntPtr lpInBuffer,
            [In] int nInBufferSize,
            [Out] IntPtr lpOutBuffer,
            [In] int nOutBufferSize,
            [Out] out int lpBytesReturned,
            [In] IntPtr lpOverlapped);

        //
        // Close handles
        //

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(
            [In] IntPtr handle);

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FindClose(
            [In] SafeFileHandle handle);

        internal static void HandleCOMError(int error)
        {
            throw new System.ComponentModel.Win32Exception(error);
        }
    }
}