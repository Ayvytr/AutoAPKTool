﻿namespace AutoAPKTool
{
    public class Util
    {
        public static string GetBuildArg(string inputFolderName, string outputApk)
        {
            return $"-jar \"{Constants.JarApktool}\" b \"{inputFolderName}\" -o \"{outputApk}\"";
        }

        public static string ZipAlign(string apkNameOld, string apkNameNew)
        {
            return string.Format("/c " + Constants.Zipalign + " -f 4 " + apkNameOld + " " + apkNameNew);
        }

        public static string GetPackage(string apk)
        {
            return string.Format("/c " + Constants.Aapt + " dump badging " + apk);
        }

        public static string GetPackageNew(string apk)
        {
            return string.Format("-jar " + Constants.ApkFile + " " + apk);
        }


        public static string DecOdex(string inputOdex, string outputSmali)
        {
            return
                $"-jar \"{Constants.Baksmali}\" -c \"{Constants.OdexFramework}\"  \"{inputOdex}\" -o \"{outputSmali}\"";
        }


        public static string GetBuildDex(string inputFolderName, string outputDex)
        {
            return $"-jar \"{Constants.Smali}\" \"a\" \"{inputFolderName}\" -o \"{outputDex}\"";
        }


        public static string GetDecompilerArg(string inputApk, string outputFolderName)
        {
            return $"-jar \"{Constants.JarApktool}\" d \"{inputApk}\" -o \"{outputFolderName}\"";
        }


        public static string GetDecompilerArgWithoutRes(string inputApk, string outputFolderName)
        {
            return $"-jar \"{Constants.JarApktool}\" d -r \"{inputApk}\" -o \"{outputFolderName}\"";
        }


        public static string GetDecompilerDex(string inputDex, string outputFolderName)
        {
            return $"-jar \"{Constants.Baksmali}\" \"d\"  \"{inputDex}\" -o \"{outputFolderName}\"";
        }


        public static string GetDex2JarArg(string inputDex, string outputJar)
        {
            return $"/c \"\"{Constants.D2JDex2Jar}\" \"{inputDex}\" -o \"{outputJar}\"\"";
        }

        public static string GetJar2DexArg(string inputDex, string outputJar)
        {
            return $"/c \"\"{Constants.D2JJar2Dex}\" \"{inputDex}\" -o \"{outputJar}\"\"";
        }

        public static string GetApkinfo(string inputApk)
        {
            return $"/c \"\"{Constants.CheckProtect}\" l \"{inputApk}\"";
        }

        public static string GetSignJksArg(string apkName)
        {
            return string.Format("-jar " + Constants.ApkSigner + " sign --ks " + Constants.DefaultJks +
                                 "  --ks-pass pass:12345678 " + apkName);
        }

        public static string GetSignCustomJksArg(string apkName, string path, string password)
        {
            return string.Format("-jar " + Constants.ApkSigner + " sign --ks " + path + "  --ks-pass pass:" + password +
                                 " " + apkName);
        }

        public static string verify_jks(string path, string pass, string alis, string alis_pass)
        {
            return $"-jar \"{Constants.KEYVER}\"  \"{path}\"  \"{pass}\" \"{alis}\" \"{alis_pass}\"";
        }
    }
}