namespace Lead.Utility.Extensions;

public static class LeadNoGenerator
{
    public static string NewLeadNo(DateTimeOffset now)
    {
        var ticks = now.UtcTicks;
        return $"LEAD-{now:yyyyMMdd}-{ticks.ToString().Substring(Math.Max(0, ticks.ToString().Length - 6))}";
    }
}
