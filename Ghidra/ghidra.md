---
layout: default
title: Ghidra
nav_order: 4
---

# Ghidra

[Ghidra] is a free and open-source software for reverse engineering, allowing us to decompile the game client.

## Interesting Functions

- [140f4c480 : LoadAllScript](#140f4c480-loads-all-script-)
- [140157bd0 : ConfigClientOrLocalServerLoaderAndPortRetry](#140157bd0-configclientorlocalserverloaderandportretry-)
- [140181730 : Login](#140181730-login-)
- [14017ef10 : PotentialStartLogin](#14017ef10-potentialstartlogin-)
- [1401b8650 : StartAPIAndCheckService](#1401b8650-startapiandcheckservice-)

## Useful Findings

### Login Process

#### 140f4c480 Loads all script :
```Call -> a function that call -> ConfigClientOrLocalServerLoaderAndPortRetry```

#### 140157bd0 ConfigClientOrLocalServerLoaderAndPortRetry :

```
Load "json/r14/config/netconfig_client.json" or "json/r14/config/netconfig_localserver.json"
Conditional Call -> Login, use return content of login to call another function, then use what's this function return to call another one and finally a conditional call to StartAPIAndCheckService (I think that's where we should dig in)
Conditional Call -> PotentialStartLogin
Call -> StartAPIAndCheckService
```

#### 140181730 Login :
```Call wss://login.readyatdawn....```

#### 14017ef10 PotentialStartLogin :
```
Log Logging In
check HMD (function address 1400dd220)
Start OVR logging in (function address 14017e780)
TriggerGoingOnlineLog if condition is true (function address 14060c370) this function edit variable content with pointers and do indirect function call through pointers
```

#### 1401b8650 StartAPIAndCheckService :
```
Log netgame switching state
If not started, Start local API
In some case, Start OVR logging in
Display service/Matchmaker Unavailable (or not)
```

[Ghidra]: https://ghidra-sre.org/
