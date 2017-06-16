using System;

namespace Data.Gateway.Iltec
{
    /// <summary> Adapter for pages such as
    /// http://www.portaldalinguaportuguesa.org/index.php?action=lemma&lemma=123120 </summary>
    internal class IltecSingleTermPageAdapter : IIltecAdapter
    {
        public IltecResponse Adapt(string htmlResult)
        {
            throw new NotImplementedException();
        }
    }
}