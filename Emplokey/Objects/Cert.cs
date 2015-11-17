﻿using System.Text;
using System.Security.Cryptography;
using System.Management;
using System.Linq;
using System;

namespace Emplokey
{
    public class Cert
    {
        public string path { get; set; }
        public string user { get; set; }
        public string userType { get; set; }
        public string pcName { get; set; }                
        public bool loaded { get; set; }

        public string deviceId
        {
            get
            {
                return getHashedString(GetDeviceId(path.Substring(0, 2)));                
            }
            set { }            
        }

        public string HashedAuthKey
        {
            get
            {
                return getHashedString(user + pcName);
            }

            set { }
        }        

        public static string getHashedString(string rawString)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(settingsHelper.sha1Salt + rawString + settingsHelper.sha1Salt));

            var hashedPassword = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                hashedPassword.Append(hashData[i].ToString());
            }

            return hashedPassword.ToString();
        }

        public static string GetDeviceId(string driveLetter)
        {
            string deviceId = "";            

            try
            {
                var index = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition").Get().Cast<ManagementObject>();
                var disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get().Cast<ManagementObject>();

                var drive = (from i in index
                             where i["Dependent"].ToString().Contains(driveLetter)
                             select i).FirstOrDefault();

                var key = drive["Antecedent"].ToString().Split('#')[1].Split(',')[0];

                var disk = (from d in disks
                            where
                                d["Name"].ToString() == "\\\\.\\PHYSICALDRIVE" + key
                            select d).FirstOrDefault();

                deviceId = disk["PNPDeviceID"].ToString().Split('\\').Last();
            }
            catch
            {
            }

            return deviceId;
        }
    }    
}