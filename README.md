<h1>Killer For Explorer</h1>

This program is a simple way to disable and enable explorer.exe.

<h2>Who is it for?</h2>

If you have a need to disable the Windows interface (explorer.exe) for stable gaming or other tasks, and you're tired of manually disabling the process through the task manager every time, then you will like this program.

<h2>How does it work?</h2>

The program is very simple, with just two lines for the main functionality:

1. Disabling explorer.exe
```csharp
private void KillerExplorer()
        {
            Process.Start(@"C:\Windows\System32\taskkill.exe", @"/F /IM explorer.exe");
        }
```

2. Enabling explorer.exe
```csharp
private void StartExplorer()
        {
            Process.Start(@"C:\Windows\explorer");
        }
```
The rest of the code only includes the visual components of the application.

<h2>Program functionality</h2>

After launching the application, a small window will appear, and this is what it can do:

1. Disables and enables explorer.exe.
2. Minimizes the application to the system tray (gun icon).
3. Minimizes the application to the taskbar.
4. Closes the application (if you disabled explorer.exe and accidentally closed the application, explorer.exe will start automatically).
5. Pressing the [ctrl + A] key combination allows you to enable or disable explorer.exe.
6. In the future, settings will be added, allowing you to change the key combination, theme, and language of the application.
