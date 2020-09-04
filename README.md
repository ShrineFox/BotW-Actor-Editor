# BotW Actor Editor
C# Program to automate swapping Actor Pack physics files using Python

![](https://i.imgur.com/NhhaDB7.png)

**BotW Actor Editor** makes it easy to get one Actor in BotW to use the physics of another.
# Usage
1. Drag your original .sbactorpack (the one you want to change the physics of)
2. Drag your replacement .sbactorpack (the one you want to use the physics from)
3. Hit rebuild and let it do all the work!
# Features
- Automatically check if you have installed [a compatible Python version (Requires >= 3.6.1 64-bit)](https://www.python.org/ftp/python/3.7.8/python-3.7.8-amd64.exe)
- Automatically install sarc and aamp scripts via pip if not found
- Unpacks SARCs, replaces files & updates data accordingly, then repacks for Wii U and Switch
- Leaves behind a copy of any edited YML files so you can review changes afterward
