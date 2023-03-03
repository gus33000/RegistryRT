using System;
using Windows.UI.Xaml.Controls;
using RegistryRT;

namespace UWPNetNativeSample
{
    public sealed partial class MainPage : Page
    {
        private static readonly Registry registry = new Registry();

        public MainPage()
        {
            this.InitializeComponent();

            uint CurrentMajorVersionNumber = 0;
            uint CurrentMinorVersionNumber = 0;
            string CurrentBuild = "";

            byte[] valueBuffer;
            RegistryType regType;

            bool result = registry.QueryValue(RegistryHive.HKEY_LOCAL_MACHINE,
                                              @"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                                              "CurrentBuild",
                                              out regType,
                                              out valueBuffer);

            if (result && regType == RegistryType.String)
            {
                CurrentBuild = System.Text.Encoding.ASCII.GetString(valueBuffer);
            }

            result = registry.QueryValue(RegistryHive.HKEY_LOCAL_MACHINE,
                                         @"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                                         "CurrentMajorVersionNumber",
                                         out regType,
                                         out valueBuffer);

            if (result && regType == RegistryType.Integer)
            {
                CurrentMajorVersionNumber = BitConverter.ToUInt32(valueBuffer, 0);
            }

            result = registry.QueryValue(RegistryHive.HKEY_LOCAL_MACHINE,
                                         @"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                                         "CurrentMinorVersionNumber",
                                         out regType,
                                         out valueBuffer);

            if (result && regType == RegistryType.Integer)
            {
                CurrentMinorVersionNumber = BitConverter.ToUInt32(valueBuffer, 0);
            }

            BuildNumberRun.Text = $"Microsoft (R) Windows (R) Version {CurrentMajorVersionNumber}.{CurrentMinorVersionNumber} (Build {CurrentBuild})";

            bool success = registry.QueryValue(RegistryHive.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "BuildLabEx", out RegistryType _, out byte[] rawData);
            if (success)
            {
                string buildStringLabEx = System.Text.Encoding.ASCII.GetString(rawData);
            }
        }
    }
}