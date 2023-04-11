@echo off
wpeinit
powercfg /s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c

set PATH=%PATH%;X:\WIDT-GUI\
start /D "X:\WIDT-GUI\" "" "X:\WIDT-GUI\WIDT-GUI.exe"