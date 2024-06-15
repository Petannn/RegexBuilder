using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RegexBuilder.Conditions;

namespace RegexBuilder
{
    public class Pattern
    {
        private readonly string _condition;
        private readonly IQuantifier? _quantifier;

        public Pattern(string condition, IQuantifier? quantifier = null)
        {
            _condition = condition;
            _quantifier = quantifier;
        }

        public string Build()
        {
            return _quantifier == null ? _condition : _quantifier.ToRegexPattern(_condition);
        }
    }


    public class ConstrainBuilder<TCurrent, TInterface> : IConstrainBuilder<TCurrent, TInterface> 
        where TCurrent : ConstrainBuilder<TCurrent, TInterface>, TInterface
    {
        protected List<Pattern> _patterns = new();

        public virtual string ToRegexPattern()
        {
            return _patterns.Aggregate(String.Empty, (current, pattern) => current + pattern.Build());
        }

        public virtual TInterface AddCondition(ICondition condition)
        {
            return AddCondition(condition.ToRegexPattern());
        }

        public virtual TInterface AddCondition(ICondition condition, IQuantifier quantifier)
        {
           return AddCondition(condition.ToRegexPattern(), quantifier);
        }

        public virtual TInterface AddCondition(string condition)
        {
            _patterns.Add(new Pattern(condition));
            return (TCurrent)this;
        }

        public virtual  TInterface AddCondition(string condition, IQuantifier quantifier)
        {
            _patterns.Add(new Pattern(condition, quantifier));
            return (TCurrent)this;
        }
    }
}
