using System.ComponentModel;

namespace CameraCapture.Models.Types
{
    public enum AgeType : byte
    {
        [Description("Year(s)")]
        Year = 1,

        [Description("Month(s)")]
        Month = 2
    }
}
