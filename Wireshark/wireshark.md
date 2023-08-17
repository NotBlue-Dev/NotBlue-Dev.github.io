---
layout: default
title: Wireshark
nav_order: 3
#has_children: true
---

# Wireshark

[Wireshark] allow us to capture and analyze network traffic. 
Here you can find IP filters for the different WS of Echo Arena as well as some pcaps from before the shutdown.

## Pcaps

You can find pcaps and ssl keys for lobby/combat/arena here : [pcaps]

- Open those pcaps in Wireshark `File -> Open`
- To decrypt the traffic you need to add the ssl keys in `Edit -> Preferences -> Protocols -> SSL -> (Pre)-Master-Secret log filename`
- You can filter the packets with the IP filters below
- You can click on a packet and get the dataFrame in the bottom panel
- Those dataFrame can be used with the local websockets to simulate the servers

## IP Filters

- **Config Server**
    - `ip.addr == 52.34.19.207 || ip.addr == 52.25.203.99 || ip.addr == 35.162.57.252`
- **Login Server**
    - `ip.addr == 52.39.75.155 || ip.addr == 50.112.145.98 || ip.addr == 54.189.212.136`
- **Matchmaker-Social Server**
    - `ip.addr == 35.81.159.9 || ip.addr == 44.238.116.60 || ip.addr == 34.218.86.243`
- **Matchmaker-Arena Server**
    - `ip.addr == 34.210.19.254 || ip.addr == 54.70.167.1 || ip.addr == 52.38.182.192`
- **Matchmaker-Combat Server**
    - `ip.addr == 35.155.72.191 || ip.addr == 50.112.132.188 || ip.addr == 44.238.188.63`
- **Transaction Server**
    - `ip.addr == 52.88.116.4 || ip.addr == 52.34.202.62 || ip.addr == 34.211.159.73`
- **API Server**
    - `ip.addr == 54.230.31.93 || ip.addr == 54.230.31.12 || ip.addr == 54.230.31.5 || ip.addr == 54.230.31.73`
- **Graph.Oculus Server**
    - `ip.addr == 31.13.88.54`

## Useful findings

### Matchmaker

The dataframe sent before the endpoint dataframe can be modified to change the server the game connects to
Here is an example of what contains the dataframe

```
          13 239 17 183 (each byte as decimal)
          ^^ ^^  ^^ ^^
0acbcd4d  0d ef  11 b7  1a8d 0000
^         ^^ ^^  ^^ ^^   ^    ^
?              IP       port padding?
```

[pcaps]: https://drive.google.com/file/d/1IAu0ZZuZrNNiwc7CzOleWvMZtFdJ2uUk/view?usp=sharing
[Wireshark]: https://www.wireshark.org/