---
layout: default
title: Patches
nav_order: 7
#has_children: true
---

# Patches

This is a list of all the patches that have been made for the game client.

## Offline Echo

[Offline Echo] is a patch that allows you to play Echo VR by bypassing login and matchmaker service.
You can find instruction on how to use it on the website.

## Bypass Login
This patch allows us to bypass login service.
Using this patch the game still try to access the matchmaker WS allowing us to potentially use our own matchmaker.

- Download the [dbgcore.dll]
- Drop it in your EchoVR folder where your exe is located (usually `C:\Program Files\Oculus\Software\Software\ready-at-dawn-echo-arena\bin\win10`)
- Run the game

[dbgcore.dll]: https://github.com/NotBlue-Dev/NotBlue-Dev.github.io/blob/main/Files/Patches/BypassLogin/dbgcore.dll
[Offline Echo]: https://echo-foundation.pages.dev/offline_echo/