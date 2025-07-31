# Anti-Screenshot
Call the Windows API SetWindowDisplayAffinity to block the Snipping Tool

![License:MIT](https://img.shields.io/badge/License-MIT-blue.svg)

# 🔍 Overview
This project implements window-level screenshot protection by using the Windows API SetWindowDisplayAffinity to exclude a specific window from screen captures. When enabled:

The protected window appears blank in screenshots.

Lightweight, no admin rights required.

# ⚙️ How It Works
The core mechanism relies on the Windows 10+ API:
```sh
[DllImport("user32.dll")]
private static extern bool SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

// Enable protection (WDA_EXCLUDEFROMCAPTURE = 0x11)
SetWindowDisplayAffinity(targetWindowHandle, 0x11);

// Disable protection (WDA_NONE = 0x00)
SetWindowDisplayAffinity(targetWindowHandle, 0x00);

```

# 📊 References
https://cloud.tencent.com/developer/article/2543206

# 📜 License
MIT License. See LICENSE.
