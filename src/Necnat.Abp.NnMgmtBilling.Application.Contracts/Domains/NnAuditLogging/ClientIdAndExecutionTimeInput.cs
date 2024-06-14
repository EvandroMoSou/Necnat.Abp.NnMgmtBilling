using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class ClientIdAndExecutionTimeInput
    {
        public string? ClientId { get; set; }
        public DateTime? ExecutionTimeStart { get; set; }
        public DateTime? ExecutionTimeEnd { get; set; }
    }
}
