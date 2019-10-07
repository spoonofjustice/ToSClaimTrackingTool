using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ToSClaimTrackingTool.Utils
{
    public class Memory
    {
        private Process targetProcess;
        private IntPtr processHandle;
        private int processID;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint access, bool inherit, int pid);
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);
        [DllImport("ntdll.dll")]
        private static extern bool NtWow64ReadVirtualMemory64(IntPtr process, long address, byte[] buffer, ulong size, IntPtr numberOfBytesRead);
        [DllImport("ntdll.dll")]
        private static extern bool NtWow64WriteVirtualMemory64(IntPtr process, long address, byte[] buffer, ulong size, IntPtr numberOfBytesRead);

        public Memory(string p_processName)
        {
            if (!this.LoadProcess(p_processName))
                Console.WriteLine("Couldn't find process");
        }

        ~Memory()
        {
            if (this.processHandle == IntPtr.Zero)
                return;
            Memory.CloseHandle(this.processHandle);
        }

        public bool LoadProcess(string p_processName)
        {
            Process[] processesByName = Process.GetProcessesByName(p_processName);
            if (processesByName.Length <= 0)
                return false;

            this.targetProcess = processesByName[0];
            this.processID = targetProcess.Id;
            this.processHandle = Memory.OpenProcess(56U, false, this.processID);

            return this.processHandle != IntPtr.Zero;
        }

        public int ReadInt(int address)
        {
            byte[] buffer = new byte[4];
            NtWow64ReadVirtualMemory64(this.processHandle, address, buffer, 4UL, IntPtr.Zero);
            return BitConverter.ToInt32(buffer, 0);
        }
        //public int ReadInt(int address, int[] offsets)
        //{
        //    int addr = ReadInt(address);

        //    foreach (int offset in offsets)
        //    {
        //        addr = ReadInt(addr + offset);
        //    }
        //    return addr;
        //}
        //public int ReadInt(int[] offsets)
        //{
        //    int addr = 0;

        //    foreach (int offset in offsets)
        //    {
        //        addr = ReadInt(addr + offset);
        //    }
        //    return addr;
        //}

        //public byte[] ReadConsecutiveBytes(int address, int max = 128)
        //{
        //    byte[] bytes = ReadBytes(address, max);

        //    List<byte> consecutiveBytes = new List<byte>();

        //    for (int i = 0; i < bytes.Length; i++)
        //    {
        //        if (bytes[i] == 0) break;
        //        consecutiveBytes.Add(bytes[i]);
        //    }

        //    return consecutiveBytes.ToArray();
        //}

        public byte[] ReadBytes(int address, int amount)
        {
            byte[] bytes = new byte[amount];
            NtWow64ReadVirtualMemory64(this.processHandle, address, bytes, (ulong)amount, IntPtr.Zero);
            return bytes;
        }

        //public string ReadString(int address) => Encoding.Default.GetString(ReadConsecutiveBytes(address));
        //public string ReadString(int[] offsets) => ReadString(ReadInt(offsets));
        //public string ReadString(int address, int[] offsets) => ReadString(ReadInt(address, offsets));

        public int GetAddressFromDll(string dllName, int[] offsets = null)
        {
            if (targetProcess == null) return 0;

            int baseAddress = (int)GetModule(dllName)?.BaseAddress;
            if (offsets == null || !offsets.Any()) return baseAddress;

            int firstAddress = ReadInt(baseAddress + offsets.First());
            if (offsets.Length == 1) return firstAddress;

            int address = firstAddress;
            for (int i = 1; i < offsets.Length; i++)
            {
                address = ReadInt(address + offsets[i]);
            }

            return address;
        }
        private ProcessModule GetModule(string moduleName)
        {
            foreach (ProcessModule module in targetProcess?.Modules)
            {
                if (module.ModuleName.Equals(moduleName)) return module;
            }
            return null;
        }
    }
}
