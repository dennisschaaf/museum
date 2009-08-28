using System;
namespace Sirikata.Runtime {
public class TimeClass {
    uint mLowerWord;
    uint mUpperWord;
    
    public long microseconds() {
        ulong micro=mUpperWord;
        micro*=65536;
        micro*=65536;
        micro+=mLowerWord;
        return (long)micro;
    }
    public double seconds() {
        return (double)microseconds()/1000000.0;
    }
    public void setLower(uint lower){
        mLowerWord=lower;
    }
    public void setLowerUpper(uint lower,uint upper){
        mLowerWord=lower;
        mUpperWord=upper;
    }
    public void setUpper(uint upper){
        mUpperWord=upper;
    }
    public uint getLower(){
        return mLowerWord;
    }
    public uint getUpper(){
        return mUpperWord;
    }
    public void setMicroseconds(ulong microsecond) {
        uint lowerlowerhword=(uint)(microsecond%65536);
        ulong upperlowerhword=microsecond/65536;
        upperlowerhword%=65536;
        mLowerWord=(uint)(upperlowerhword)*65536+lowerlowerhword;
        microsecond/=65536;
        microsecond/=65536;
        mUpperWord=(uint)microsecond;

    }
    public TimeClass() {
        mUpperWord=0;
        mLowerWord=0;
    }
    public TimeClass(ulong microsecond) {
        mUpperWord=0;
        mLowerWord=0;
        setMicroseconds(microsecond);
    }
    public TimeClass(uint lower, uint upper) {
        mLowerWord=lower;
        mUpperWord=upper;
    }
}

public struct Time {
    uint mLowerWord;
    uint mUpperWord;
    
    public long microseconds() {
        ulong micro=mUpperWord;
        micro*=65536;
        micro*=65536;
        micro+=mLowerWord;
        return (long)micro;
    }
    public double seconds() {
        return (double)microseconds()/1000000.0;
    }
    public void setLower(uint lower){
        mLowerWord=lower;
    }
    public void setLowerUpper(uint lower,uint upper){
        mLowerWord=lower;
        mUpperWord=upper;
    }
    public void setUpper(uint upper){
        mUpperWord=upper;
    }
    public uint getLower(){
        return mLowerWord;
    }
    public uint getUpper(){
        return mUpperWord;
    }
    public void setMicroseconds(long signed_microsecond) {
        ulong microsecond=(ulong)signed_microsecond;
        uint lowerlowerhword=(uint)(microsecond%65536);
        ulong upperlowerhword=microsecond/65536;
        upperlowerhword%=65536;
        mLowerWord=(uint)(upperlowerhword)*65536+lowerlowerhword;
        microsecond/=65536;
        microsecond/=65536;
        mUpperWord=(uint)microsecond;

    }
    public Time(TimeClass otherclass) {
        mUpperWord=0;
        mLowerWord=0;
        setMicroseconds(otherclass.microseconds());
    }
    public Time(long microsecond) {
        mUpperWord=0;
        mLowerWord=0;
        setMicroseconds(microsecond);
    }
    public Time(uint lower, uint upper) {
        mLowerWord=lower;
        mUpperWord=upper;
    }
}

}