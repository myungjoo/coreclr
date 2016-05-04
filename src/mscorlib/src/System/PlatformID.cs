// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/*============================================================
**
**
**
** Purpose: Defines IDs for supported platforms
**
**
===========================================================*/
namespace System {

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)]
    public enum PlatformID
    {
        // 0xXX000000 : Platform Major-Class (e.g., Windows, UNIX, ...)
        // 0x00XXX000 : Platform Minor-Class (e.g., Linux, FreeBSD, SunOS, ...)
	//       if XXX == 0x000, minor-class is "unspecified"
        // 0x00000XXX : Platform Subclass (e.g., Linux-ubuntu, Linux-fedora, ...)
	//       if XXX == 0x000, subclass is "unspecified"
        Windows		= 0x1000000,
	    Win32S		= Windows | 0x1000,
	    Win32Windows	= Windows | 0x2000,
	    Win32NT		= Windows | 0x3000,
	    WinCE		= Windows | 0x4000,
	    Xbox		= Windows | 0x5000,

        Unix		= 0x2000000;
            MacOSX		= Unix | 0x1000,
            Linux		= Unix | 0x2000,
	        Debian			= Linux | 0x210,
	        Ubuntu			= Linux | 0x220,
	        Fedora			= Linux | 0x230,
	        Redhat			= Linux | 0x240,
	        Slackware		= Linux | 0x250,
            FreeBSD		= Unix | 0x3000,

	MajorClass	= 0xFF000000
	MinorClass	= 0x00FFF000
	SubClass	= 0x00000FFF
    }
    public static PlatformID getMinorClass(PlatformID p)
    {
        return p & 0xFFFFF000;
    }
    public static PlatformID getMajorClass(PlatformID p)
    {
        return p & 0xFF000000;
    }
    public static bool isValidPlatformID(PlatformID p)
    {
        switch (p & PlatformID.MajorClass)
        {
        case PlatformID.Windows:
            if (p > PlatformID.Xbox) // the max for windows
                return false;
            return true;
	case PlatformID.Unix:
	    if (p > PlatformID.FreeBSD) // the max for unix
	        return false;
	default:
	    return false;
	}
    }
}
