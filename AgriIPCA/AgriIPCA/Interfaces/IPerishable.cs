using System;

namespace AgriIPCA.Interfaces
{
    public interface IPerishable
    {
        DateTime BestBefore { get; }

        bool IsWentOff { get; set; }

        void GoOff();
    }
}
