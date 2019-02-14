using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interchange.Entity
{
    public interface IMatch
    {
        List<IMatchInfo> MatchList { get; set; }
        MatchType ResultType { get; set; }
        string WarningMessage { get; set; }
    }
    public enum MatchType
    {
        SingleEntityMatch, MultiEntityMatch, ZeroEntityMatch
    }
}
