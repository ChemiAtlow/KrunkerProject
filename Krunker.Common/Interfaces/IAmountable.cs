namespace Krunker.Common.Interfaces
{
    public interface IAmountable
    {
        int CurrentAmount { get; }
        void Add(int amount);
        bool Use(int amount);
    }
}
