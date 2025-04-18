using System.ComponentModel;

namespace DAL.Constants
{
    public enum LoginType
    {
        [Description("Email and Password")]
        Password = 0,

        [Description("Google")]
        Google = 1
    }

    public enum PaymentStatus
    {
        Pending = 0,
        Paid = 1,
        Failed = 2,
        Cancelled = 3
    }

    public enum TypeSupply
    {
        Food = 0,
        Toy = 1,
        Medicine = 2,
        Accessory = 3
    }
}
