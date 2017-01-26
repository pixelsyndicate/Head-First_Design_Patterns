namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public abstract class BaseThreeLevelDevice
    {
        internal const int HIGH = 3;
        internal const int MED = 2;
        internal const int LOW = 1;
        internal const int OFF = 0;
    }
    public interface IOnOffDevice
    {
        bool IsOn { get; set; }
        string On();
        string Off();
    }

    public interface IUpDownDevice
    {
        string Up();
        string Down();
    }

    public interface IThreeLevelDevice
    {
        string On(int temperature);
        string High();
        string Medium();
        string Low();
        int GetLevel();
    }

    public interface INumericLevelDevice
    {
        string SetLevel(int i);
    }
}