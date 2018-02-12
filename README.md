# FLO C# SDK
**Author** : Abhijeet Das Gupta @ 366Pi

**Version** : 1.0.0.0

**.Net Framework Used** : 4.6.1

**External References Used** : Newtonsoft.Json

(URL : https://www.newtonsoft.com/json)


## Description

FLO C# SDK is a C# Class Library for connecting to local / remote FLO wallet and making wallet calls for creating FLO Blockchain enabled apps in C#.
Can be referenced into any C# Project to extend the RPC Call functionality to FLO wallet.

**Note:RPC methods "stop" and "backupwallet" have not been implemented. Other than that all other RPC calls of FLO have been implemented in this SDK**

## Repository Contains:

**1. FloSDK - Class Library Project**

**2. FloSdkTest - C# Sample Console Application implementing the FloSDK library**


## How To Use:

### 1. Download and Install FLO Wallet: 
URL (Windows) : http://flo.cash/static/assets/wallet/florincoin-0.10.4.6-qt-win64.zip

### 2. Sync FLO Blockchain

### 3. Configure florincoin.conf file

Default Location of file is : C:\Users\{Username}\AppData\Roaming\Florincoin

**Sample .conf file below:**

```
rpcserver=1
rpcuser=your_user_name
rpcpassword=your_password
rpcallowip=192.168.0.0/16
rpcallowip=127.0.0.1
rpcport=7313
port=7312
server=1
listen=1
addnode=188.166.6.99
addnode=176.9.59.110
addnode=193.70.122.58
addnode=nyc2.entertheblockchain.com
addnode=sf1.entertheblockchain.com
addnode=am2.entertheblockchain.com
addnode=sgp.entertheblockchain.com
addnode=ind.entertheblockchain.com
addnode=de.entertheblockchain.com
```

### 4. Build FloSDK Project

### 5. Add FloSDK DLL to your application as reference.

### 6. Configure .config file of your application to have the following:

Example app.config settings of sample console application:
```
  <appSettings>
    <add key="username" value="wallet_rpc_username" />
    <add key="password" value="wallet_rpc_password" />
    <add key="wallet_url" value="http://localhost" />
    <add key="wallet_port" value="7313" />
  </appSettings>
```

### 7. Declare variables for the above in your program:

```C#
            string username = ConfigurationManager.AppSettings.Get("username");
            string password = ConfigurationManager.AppSettings.Get("password");
            string wallet_url = ConfigurationManager.AppSettings.Get("wallet_url");
            string wallet_port = ConfigurationManager.AppSettings.Get("wallet_port");
```
         
### 8. Import the following packages of FloSDK in your program:

```C#
using FloSDK.Exceptions;
using FloSDK.Methods;
```

### 9. Create object of RpcMethods class:

```C#
RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
```

### 10. Call RPC methods of SDK using the RpcMethods object and cast response as JObject:

```C#
                try
                {
                    JObject obj = JObject.Parse(rpc.GetInfo());

                    if (string.IsNullOrEmpty(obj["error"].ToString()))
                    {
                        Console.WriteLine("Get Info : " + obj["result"]);
                    }
                    else
                    {
                        Console.WriteLine("Get Info Error : " + obj["error"]);
                    }
                }
                catch (RpcInternalServerErrorException exception)
                {
                    var errorCode = 0;
                    var errorMessage = string.Empty;

                    if (exception.RpcErrorCode.GetHashCode() != 0)
                    {
                        errorCode = exception.RpcErrorCode.GetHashCode();
                        errorMessage = exception.RpcErrorCode.ToString();
                    }

                    Console.WriteLine("[Failed] {0} {1} {2}", exception.Message, errorCode != 0 ? "Error code: " + errorCode : string.Empty, !string.IsNullOrWhiteSpace(errorMessage) ? errorMessage : string.Empty);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("[Failed]\n\nPlease check your configuration and make sure that the daemon is up and running and that it is synchronized. \n\nException: " + exception);
                }
                
```
Check the response JObject for "error" or "result".



## To Support Development of the FLO C# SDK :

**Donate FLO To :** FUvB6T8EtspmtsnhA9deE1uBkaWZTmWpUw

**Donate BTC TO :** 3Ki9uziXHF4csqheDifK1MRAWFJEMSKHkH


