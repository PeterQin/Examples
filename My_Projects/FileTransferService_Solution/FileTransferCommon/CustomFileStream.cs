using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Quest.Tuning.FileTransferCommon
{
    public class CustomFileStream : FileStream
    {
         long _count;
        long _lastPosition;
        public CustomFileStream(IntPtr handle, FileAccess access)
            : base(handle, access)
        { }

        public CustomFileStream(string path, FileMode mode, FileAccess access, FileShare share)
            : base(path, mode, access) { }

        public CustomFileStream(string path, FileMode mode, FileAccess access, FileShare share, long offset, long count)
            : base(path, mode, access)
        {
            base.Position = offset;
            _count = count;
            _lastPosition = offset + count;
        }

        public CustomFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
            : base(path, mode, access, share, bufferSize)
        { }

        public override int Read(byte[] array, int offset, int count)
        {
            if (this._count > 0 && Position + count > this._lastPosition)
                return base.Read(array, offset, (int)(this._lastPosition - Position));
            else
                return base.Read(array, offset, count);
        }

        public override int ReadByte()
        {
            if (this._count > 0 && Position >= this._lastPosition)
                return -1;
            else
                return base.ReadByte();
        }
    }
}
