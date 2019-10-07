using System;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Utils
{
    public class ToSMemory : Memory
    {
        private int _historyBaseAddress = 0;
        private int _historyStartAddress = 0;
        private int _lastByteRead;
        private int _blockCount = 1;

        public ToSMemory() : base("TownOfSalem")
        {
            _historyBaseAddress = GetHistoryBaseAddress();
            _historyStartAddress = GetHistoryStartAddress();
            _lastByteRead = GetLastBytesWritten();
        }

        public void ResetToStartOfLastGame()
        {
            _historyBaseAddress = GetHistoryBaseAddress();
            _historyStartAddress = GetHistoryStartAddress();
            int lastStartGameByteFound = 0;

            var bytes = ReadBytes(_historyStartAddress, GetLastBytesWritten());
            for (int i = 1; i < bytes.Length; i++)
            {
                byte startOfGameByte = Convert.ToByte(ServerMessageType.StartOfGame);

                if (bytes[i] == startOfGameByte && bytes[i - 1] == 0)
                {
                    lastStartGameByteFound = i;
                }
            }

            _lastByteRead = lastStartGameByteFound;
        }

        public byte[] GetNextBytes()
        {
            int lastOffsetWritten = GetLastBytesWritten();
            int amountOfBytesToRead = lastOffsetWritten - _lastByteRead;

            if (amountOfBytesToRead > 0)
            {
                var bytes = ReadBytes(_historyStartAddress + _lastByteRead, amountOfBytesToRead);
                _lastByteRead = lastOffsetWritten;
                return bytes;
            }

            return new byte[0];
        }

        public int GetHistoryBaseAddress() => GetAddressFromDll("Adobe AIR.dll", new int[] { 0x12CF3CC, 0x0, 0x0, 0x230 });
        public int GetHistoryStartAddress() => ReadInt(_historyBaseAddress + (_blockCount % 2 == 0 ? 0x1C : 0x20)) + 8;

        public int GetLastBytesWritten()
        { 
            var lastByteWritten = ReadInt(_historyBaseAddress + 0x2C); //only goes up until the 65528 bytes block is consumed

            if (lastByteWritten > 0 && lastByteWritten < _lastByteRead)
            {
                _blockCount++;
                _lastByteRead = 0;
                _historyStartAddress = GetHistoryStartAddress();
            }

            return lastByteWritten;
        }
    }
}
