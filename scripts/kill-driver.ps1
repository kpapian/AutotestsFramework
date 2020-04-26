    $chromeDrivers = Get-Process | Where-Object {$_.ProcessName.StartsWith("chromedriver_")}
    if($chromeDrivers)
    {
        Stop-Process $chromeDrivers
    }