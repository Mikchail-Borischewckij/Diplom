using System;
using System.Configuration;

namespace HomeFinance.Core
{
	public static class AppSetting
	{
		private const string MissingConfig = "Invalid configuration. Required AppSettings section is missing";

		private const string InvalidConfigSetting = "Invalid configuration setting name: {0}";


		public static double AuthTokenExpiry
		{
			get { return Double.Parse(GetConfigSettingItem("AuthTokenExpiry")); }
		}

		private static string GetConfigSettingItem(string name)
		{
			string value = GetConfigSettingItemValue(name);
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ConfigurationErrorsException(SettingItemErrorMessage(name));
			}
			return value;
		}

		private static string GetConfigSettingItemValue(string name)
		{
			if (ConfigurationManager.AppSettings == null)
			{
				throw new ConfigurationErrorsException(MissingConfig);
			}

			string value = null;
			if (ConfigurationManager.AppSettings.Count != 0)
			{
				try
				{
					value = ConfigurationManager.AppSettings.Get(name);
				}
				catch (Exception exception)
				{
					throw new ConfigurationErrorsException(SettingItemErrorMessage(name));
				}
			}
			return value;
		}

		private static string SettingItemErrorMessage(string name)
		{
			return string.Format(InvalidConfigSetting, name);
		}
	}
}
