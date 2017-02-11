using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Finances.NET.OnlineUpdater.Interfaces
{
    public interface IFinancesNetUpdatable
    {
        string AplicationName { get; }
        string ApplicationVersion { get; }
        Assembly ApplicationAssembly { get; }
        Icon ApplicationIcon { get; }
        Uri UpdateLocation { get; }
        Form Context { get; }
    }
}
