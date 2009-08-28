using System;
using System.Runtime.CompilerServices;
namespace Sirikata.Runtime {


public delegate bool FunctionReturnCallback(byte[] header,byte[] body);

public class HostedObject{
    
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    public static extern Guid GetUUID();

    
    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern bool iSendMessage(byte[]message);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern bool iCallFunction(byte[]message,FunctionReturnCallback callback);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern bool iCallFunctionWithTimeout(byte[]message,FunctionReturnCallback callback, System.DateTime t);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern void iTickPeriod(System.DateTime t);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern void iGetTime(Guid spaceid,  Sirikata.Runtime.TimeClass retval);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern void iGetTimeByteArray(byte[] spaceid,  Sirikata.Runtime.TimeClass retval);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern void iGetTimeString(string spaceid,  Sirikata.Runtime.TimeClass retval);

    [MethodImplAttribute(MethodImplOptions.InternalCall)]
    internal static extern void iGetLocalTime( Sirikata.Runtime.TimeClass retval);


    internal static long TimeTicks(Sirikata.Runtime.Time t) {
        return t.microseconds();
    }
    public static  void TickPeriod(System.DateTime t){
        iTickPeriod(t);
    }
    public static bool CallFunctionWithTimeout(byte[]message,FunctionReturnCallback callback, System.DateTime t) {
        if (message==null||callback==null||message.Length==0)
            return false;
        return iCallFunctionWithTimeout(message,callback,t);
    }
    public static bool CallFunction(byte[]message,FunctionReturnCallback callback) {
        if (message==null||callback==null||message.Length==0)
            return false;
        return iCallFunction(message,callback);
    }
    public static bool SendMessage(byte[]message) {
        if (message==null||message.Length==0)
            return false;
        return iSendMessage(message);
    }    
    public static Sirikata.Runtime.Time GetTime(Guid spaceid){
        Sirikata.Runtime.TimeClass retval=new Sirikata.Runtime.TimeClass();
        iGetTime(spaceid,retval);
        return new Sirikata.Runtime.Time(retval);        
    }
    public static Sirikata.Runtime.Time GetLocalTime() {
        Sirikata.Runtime.TimeClass retval=new Sirikata.Runtime.TimeClass();
        iGetLocalTime(retval);
        return new Sirikata.Runtime.Time(retval);
    }
    public static Sirikata.Runtime.Time GetTimeFromByteArraySpace(byte[] spaceid){
        if (spaceid==null) {
            return GetLocalTime();
        }
/*
        byte[] newArray=new byte[16];
        for (int i=0;i<16;++i) {
            newArray[i]=(System.Byte)spaceid[i];
        }
*/
        Sirikata.Runtime.TimeClass retval=new Sirikata.Runtime.TimeClass();
        iGetTimeByteArray(spaceid,retval);
        return new Sirikata.Runtime.Time(retval);
        //return GetLocalTime();
    }
    public static Sirikata.Runtime.Time GetTimeFromStringSpace(string spaceid){
        if (spaceid==null) {
            return GetLocalTime();
        }
        Sirikata.Runtime.TimeClass retval=new Sirikata.Runtime.TimeClass();
        iGetTimeString(spaceid,retval);
        return new Sirikata.Runtime.Time(retval);        
    }
}
}