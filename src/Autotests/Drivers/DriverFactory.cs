using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Remote;

namespace Autotests.Drivers
{
    public static class DriverFactory
    {
        private static string _driverDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Drivers");
        private static string _remoteUrlForTestRun = "http://localhost:4444/wd/hub";
        
        public static IWebDriver Create()
        {
            String driverTypeConfigValue = ConfigurationManager.AppSettings["DriverType"];
            DriverType driverType = (DriverType)Enum.Parse(typeof(DriverType), driverTypeConfigValue);

            var isRemoteRunConfigValue = ConfigurationManager.AppSettings["IsRemoteRun"];
            var isRemoteRun = bool.Parse(isRemoteRunConfigValue);

            return isRemoteRun ? CreateForRemoteRun(driverType) : CreateForLocalRun(driverType);
        }

        private static IWebDriver CreateForLocalRun(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Opera:
                    OperaOptions optionsOpera = new OperaOptions();
                    optionsOpera.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";
                    return new OperaDriver(Path.Combine(TestContext.CurrentContext.TestDirectory, "Drivers"), optionsOpera);

                case DriverType.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(_driverDirectory, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    return new FirefoxDriver(service);

                default:
                    return new ChromeDriver(_driverDirectory);
            }
        }

        private static IWebDriver CreateForRemoteRun(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Opera:
                    return new RemoteWebDriver(new Uri(_remoteUrlForTestRun), new OperaOptions());

                case DriverType.Firefox:
                    return new RemoteWebDriver(new Uri(_remoteUrlForTestRun), new FirefoxOptions());

                default:
                    ChromeOptions options = new ChromeOptions();
                    options.AddAdditionalCapability("enableVNC", true, true);
                    options.AddAdditionalCapability("enableVideo", true, true);
                    return new RemoteWebDriver(new Uri(_remoteUrlForTestRun), options);
            }
        }
    }
}
