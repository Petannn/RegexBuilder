using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegexBuilder.Conditions;

namespace RegexBuilder
{
    public interface IConstrainBuilder <out TCurrent, TInterface> : ICondition 
        where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
    {
        TInterface AddCondition(ICondition condition);
        TInterface AddCondition(ICondition condition, IQuantifier quantifier);
        TInterface AddCondition(string  condition);
        TInterface AddCondition(string condition, IQuantifier quantifier);
    }
}
