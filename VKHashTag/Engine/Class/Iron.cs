using System;
using System.Net;
using System.Text;
using System.Windows;
using System.Management;
using System.Security.Cryptography;


namespace VKHashTag.Engine.Class
{
    class Iron
    {
        private static string KeyTMP = null;

        public static string get
        {
            get
            {
                if (KeyTMP != null)
                    return KeyTMP;

                StringBuilder result = new StringBuilder();

                try
                {
                    // Данные процессора
                    foreach (ManagementObject q in (new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor")).Get())
                    {
                        result.Append(q["ProcessorId"]);   // id 
                        result.Append(q["Name"]);          // Имя 
                        result.Append(q["Caption"]);       // Метка
                        result.Append(q["L2CacheSize"]);   // Кеш 2го уровня
                        result.Append(q["Manufacturer"]);  // Производитель
                        result.Append(q["Revision"]);      // Ревизия
                        break;
                    }
                }
                catch { }

                try
                {
                    // Данные материнской платы
                    foreach (ManagementObject q in (new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard")).Get())
                    {
                        result.Append(q["Product"]);
                        break;
                    }
                }
                catch { }

                try
                {
                    // Данные видеокарты
                    foreach (ManagementObject q in (new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController")).Get())
                    {
                        result.Append(q["AdapterRAM"]); // Имя оперативки в видеокарте
                        result.Append(q["Caption"]);    // Метка
                        break;
                    }
                }
                catch { }

                try
                {
                    // Данные дисков
                    result.Append(((new ManagementObject("win32_logicaldisk.deviceid=\"" + Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1) + ":\""))["VolumeSerialNumber"].ToString()));
                }
                catch { }


                return (KeyTMP = BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(new UTF8Encoding().GetBytes(result.ToString()))));
            }
        }
    }
}
