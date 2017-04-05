namespace AnimationTest
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    class KFileHelper
    {
        // Konwertuje ciąg tablice bajtów na strukture
        private static object GetStructure(byte[] Data, Type ObjType)
        {
            int Size = Marshal.SizeOf(ObjType);
            if (Size > Data.Length) return null;
            IntPtr Buffer = Marshal.AllocHGlobal(Size);
            Marshal.Copy(Data, 0, Buffer, Size);
            object retobj = Marshal.PtrToStructure(Buffer, ObjType);
            Marshal.FreeHGlobal(Buffer);
            return retobj;
        }
        public static byte[] StructToByte(object Structure)
        {
            byte[] buffer = new byte[Marshal.SizeOf(Structure)];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(Structure, handle.AddrOfPinnedObject(), false);
            handle.Free();
            return buffer;
        }
        // Pobiera z pliku dane typu T i tworzy z nich tablice typu T
        public static T[] GetData<T>(FileStream file)
        {
            VChunkHeader Chunk = GetChunk(file);
            T[] data = new T[Chunk.DataCount];
            byte[] buffer = new byte[Chunk.DataSize];
            for (int i = 0; i < Chunk.DataCount; i++)
            {
                file.Read(buffer, 0, Chunk.DataSize);
                data[i] = (T)GetStructure(buffer, typeof(T));
            }
            return data;
        }
        // Pobiera nagłówkek pliku [ 32 bajty ]
        public static VChunkHeader GetChunk(FileStream file)
        {
            byte[] ChunkBuffer = new byte[32];
            file.Read(ChunkBuffer, 0, 32);
            VChunkHeader chunk = (VChunkHeader)GetStructure(ChunkBuffer, typeof(VChunkHeader));
            return chunk;
        }
    }
}
