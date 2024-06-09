using System.ComponentModel;

namespace LifeTracker.Domain.Enums;

[Flags]
public enum ExpenseCategory
{
    [Description("None")]
    None = 0,
    [Description("Food")]
    Food = 1,
    [Description("Cleaning")]
    Cleaning = 2,
    [Description("Home")]
    Home = 4,
    [Description("Dogs")]
    Dogs = 8,
    [Description("Personal")]
    Personal = 16
}