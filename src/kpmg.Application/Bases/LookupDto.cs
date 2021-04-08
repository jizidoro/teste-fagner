#region

using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Bases
{
    public class LookupDto : EntityDto, ILookupDto
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}