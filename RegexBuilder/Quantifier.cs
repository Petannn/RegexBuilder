using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexBuilder
{
    public class Quantifier : IQuantifier
    {
        protected readonly bool IsLazyQuantifier;
        protected string Pattern;
        
        public Quantifier(int min, int? max, bool isLazyQuantifier = false)
        {
            IsLazyQuantifier = isLazyQuantifier;
            BuildPattern(min, max);
        }

        public Quantifier(int? max, bool isLazyQuantifier)
        {
            IsLazyQuantifier = isLazyQuantifier;
            BuildPattern(0, max);
        }

        public Quantifier(int exact) 
        {
            IsLazyQuantifier = false;
            BuildPattern(exact, exact);
        }

        private void BuildPattern(int min, int? max)
        {
            if (min == 0 && max == 1)
            {
                Pattern = "?";
            }
            else if (min == 0 && max == null)
            {
                Pattern = "*";
            }
            else if (min == 1 && max == null)
            {
                Pattern = "+";
            }
            else if (min == max)
            {
                Pattern = string.Format(CultureInfo.InvariantCulture, "{{{0}}}", min);
            }
            else if (max == null)
            {
                Pattern = string.Format(CultureInfo.InvariantCulture, "{{{0},}}", min);
            }
            else
            {
                Pattern = string.Format(CultureInfo.InvariantCulture, "{{{0},{1}}}", min, max);
            }
        }

        public virtual string ToRegexPattern(string condition)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", condition, Pattern);
        }
    }

    public class ExpressionQuantifier : Quantifier
    {
        public ExpressionQuantifier(int min, int? max, bool isLazyQuantifier = false) : base(min, max, isLazyQuantifier) { }
        public ExpressionQuantifier(int? max, bool isLazyQuantifier) : base(max, isLazyQuantifier) { }
        public ExpressionQuantifier(int exact) : base(exact, exact) { }

        public override string ToRegexPattern(string condition)
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}){1}" + (IsLazyQuantifier ? "?" : ""), condition, Pattern);
        }
    }
}
