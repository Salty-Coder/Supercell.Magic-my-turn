namespace Supercell.Magic.Servers.Core
{
    using Supercell.Magic.Titan.Json;
    using System;
    using System.Net;
    using Supercell.Magic.Servers.Core.Settings;

    public static class ServerHttpClient
    {
        private static WebClient CreateWebClient()
        {
            return new WebClient
            {
                Proxy = null
            };
        }

        public static byte[] DownloadBytes(string path)
        {
            try
            {
                using (WebClient client = ServerHttpClient.CreateWebClient())
                {
                    return client.DownloadData(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path));
                }
            }
            catch (Exception)
            {
                Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist (byte)", path));
            }

            return null;
        }

        public static string DownloadString(string path)
        {
            try
            {
                using (WebClient client = ServerHttpClient.CreateWebClient())
                {
                    return client.DownloadString(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path));
                }
            }
            catch (Exception)
            {
                Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist (string)", path));
            }

            return null;
        }

        public static LogicJSONObject DownloadJSON(string path)
        {
            try
            {
                using (WebClient client = ServerHttpClient.CreateWebClient())
                {
                    Logging.Warning(path);
                    return LogicJSONParser.ParseObject(client.DownloadString(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path)));
                    //return LogicJSONParser.ParseObject(client.DownloadString(path));
                }
            }
            catch (Exception)
            {
                Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist (json)", path));
            }

            return null;
        }

        public static byte[] DownloadAsset(string resourceSha, string path)
        {
            try
            {
                using (WebClient client = ServerHttpClient.CreateWebClient())
                {
                    Logging.Warning(resourceSha + path);
                    return client.DownloadData(string.Format("{0}/{1}/{2}", ResourceSettings.GetContentUrl(), resourceSha, path));
                }
            }
            catch (Exception)
            {
                Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist (asset)", path));
            }

            return null;
        }
    }
}