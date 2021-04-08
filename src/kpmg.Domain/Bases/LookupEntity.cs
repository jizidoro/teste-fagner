#region

using kpmg.Domain.Interfaces;

#endregion

namespace kpmg.Domain.Bases
{
    public class LookupEntity : ILookupEntity
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}