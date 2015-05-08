using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SmartDeviceProject1
{
    
    public class SYSTEM_POWER_STATUS_EX2
    {
       
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public uint BatteryLifeTime;
        public uint BatteryFullLifeTime;
        public byte Reserved2;
        public byte BackupBatteryFlag;
        public byte BackupBatteryLifePercent;
        public byte Reserved3;
        public uint BackupBatteryLifeTime;
        public uint BackupBatteryFullLifeTime;
        public uint BatteryVoltage;
        public uint BatteryCurrent;
        public uint BatteryAverageCurrent;
        public uint BatteryAverageInterval;
        public uint BatterymAHourConsumed;
        public uint BatteryTemperature;
        public uint BackupBatteryVoltage;
        public byte BatteryChemistry;
    }
     
    public class SYSTEM_POWER_STATUS_EX
    {
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public uint BatteryLifeTime;
        public uint BatteryFullLifeTime;
        public uint Reserved2;
        public byte BackupBatteryFlag;
        public byte BackupBatteryLifePercent;
        public byte Reserved3;
        public uint BackupBatteryLifeTime;
        public uint BackupBatteryFullLifeTime;
        public uint BatteryVoltage;
        public uint BatteryCurrent;
        public uint BatteryAverageCurrent;
        public uint BatteryAverageInterval;
        public uint BatterymAHourConsumed;
        public uint BatteryTemperature;
        public uint BackupBatteryVoltage;
        public byte BatteryChemistry;
    }

    public enum ACLineStatus : byte
    {
        Offline = 0,
        Online = 1,
        BackUp = 2,
        Unknown = 255,
    }

    public enum BatteryFlag : byte
    {
        High = 0x01,
        Low = 0x02,
        Critical = 0x04,
        Charging = 0x08,
        NoBattery = 0x80,
        Unknown = 0xFF,
    }

    public enum BatteryChemistry : byte
    {
        Alkaline = 0x01,
        NICD = 0x02,
        NIMH = 0x03,
        LION = 0x04,
        LIPOLY = 0x05,
        ZINCAIR = 0x06,
        Unknown = 0xFF,
    }
}
