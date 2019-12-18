﻿using System.Configuration;

namespace Appreciation.Manager.Utils
{
    public class Settings
    {
        public static string CorsDomain => ConfigurationManager.AppSettings["CorsDomain"] ?? string.Empty;
        public static int TokenExpire => ConfigurationManager.AppSettings["TokenExpire"] != null ? int.Parse(ConfigurationManager.AppSettings["TokenExpire"]) : 0;
        public static string JwtSecretKey => ConfigurationManager.AppSettings["JwtSecretKey"] ?? string.Empty;
        public static string IV => ConfigurationManager.AppSettings["DefaultIV"] ?? string.Empty;
        public static string Key => ConfigurationManager.AppSettings["DefaultKey"] ?? string.Empty;
        public static string ValidIssuer => ConfigurationManager.AppSettings["ValidIssuer"] ?? string.Empty;
        public static string ValidAudience => ConfigurationManager.AppSettings["ValidAudience"] ?? string.Empty;
    }
}
