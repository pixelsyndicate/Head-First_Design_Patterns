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
        void On();
        void Off();
    }

    public interface IUpDownDevice
    {
        void Up();
        void Down();
    }

    public interface IThreeLevelDevice
    {
        void On(int temperature);
        void High();
        void Medium();
        void Low();
        int GetLevel();
    }

    public interface INumericLevelDevice
    {
        void SetLevel(int i);
    }
}