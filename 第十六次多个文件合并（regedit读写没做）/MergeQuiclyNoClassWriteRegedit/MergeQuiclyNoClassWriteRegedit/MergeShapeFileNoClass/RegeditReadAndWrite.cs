using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace Regedit
{
    public class RegeditReadAndWrite
    {
        private int fileOrFolderTotallCount;
        public RegeditReadAndWrite(int count)
        {
            fileOrFolderTotallCount = count;
        }

        public void WriteRegedit(string regeditName, string regeditvalue)
        {
            RegistryKey rsg = null;
            Registry.CurrentUser.CreateSubKey("Software\\ShpMergerTest\\" + regeditName);
            rsg = Registry.CurrentUser.OpenSubKey("Software\\ShpMergerTest\\" + regeditName, true);
            if (rsg.GetValue(regeditName) == null)
            {
                rsg.SetValue(regeditName, 1);
                rsg.SetValue(regeditName + "0", regeditvalue);
                return;
            }
            else
            {
                int fileOrFolderCount = (int)(rsg.GetValue(regeditName));
                bool fileOrFolderExist = false;  // File or folder already in the regedit ?
                string[] folders = new string[fileOrFolderTotallCount];
                int location;
                for (location = 0; location < fileOrFolderTotallCount && location < fileOrFolderCount; location++)
                {
                    folders[location] = rsg.GetValue(regeditName + location).ToString();
                    if (folders[location] == regeditvalue)
                    {
                        fileOrFolderExist = true;
                        break;
                    }
                }
                if (fileOrFolderExist == false)
                {
                    if (fileOrFolderCount < fileOrFolderTotallCount - 1)
                    {
                        fileOrFolderCount++;
                        rsg.SetValue(regeditName, fileOrFolderCount);
                    }
                }
                if (location == fileOrFolderTotallCount)
                {
                    location = fileOrFolderTotallCount - 1;
                }
                for (int i = location; i > 0; i--)
                {
                    folders[i] = folders[i - 1];
                    rsg.SetValue(regeditName + i, folders[i]);
                }
                rsg.SetValue(regeditName + "0", regeditvalue);
            }
            rsg.Close();
        }

        public Collection<string> ReadRegedit(string regeditName)
        {
            Collection<string> returnString = new Collection<string>();
            RegistryKey rsg = null;
            Registry.CurrentUser.CreateSubKey("Software\\ShpMergerTest\\" + regeditName);
            rsg = Registry.CurrentUser.OpenSubKey("Software\\ShpMergerTest\\" + regeditName);
            if (rsg.GetValue(regeditName) == null)
            {
                rsg.Close();
                return null;
            }
            else
            {
                int fileOrFolderCount = (int)(rsg.GetValue(regeditName));
                for (int i = 0; i < fileOrFolderTotallCount && i < fileOrFolderCount; i++)
                {
                    returnString.Add(rsg.GetValue(regeditName + i).ToString());
                }
                rsg.Close();
                return returnString;
            }
        }
    }
}
