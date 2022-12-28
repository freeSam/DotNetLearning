using Ardalis.SmartEnum;

namespace SmartEnums;

public abstract class Subscriptions : SmartEnum<Subscriptions>
{
    public static readonly Subscriptions Free = new FreeTier();
    public static readonly Subscriptions Premium = new PremiumTier();
    public static readonly Subscriptions Vip = new VipTier();

    public abstract double Discount { get; }

    public Subscriptions(string name, int value) : base(name, value)
    {
    }

    private sealed class FreeTier : Subscriptions
    {
        public FreeTier() : base("Free", 1)
        {
        }

        public override double Discount => .0;
    }

    private sealed class PremiumTier : Subscriptions
    {
        public PremiumTier() : base("Premium", 2)
        {
        }

        public override double Discount => .25;
    }

    private sealed class VipTier : Subscriptions
    {
        public VipTier() : base("VIP", 3)
        {
        }

        public override double Discount => .5;
    }
}
