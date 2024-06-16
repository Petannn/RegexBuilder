using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RegexBuilder.Conditions;
using RegexBuilder.Groups;

namespace RegexBuilder
{
    public static class Extensions
    {

        public static TInterface Any<TCurrent, TInterface>(this IConstrainBuilder<TCurrent, TInterface> builder, params ICondition[] conditions) where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
        {
            var group = new NoncapturingGroup();

            foreach (var condition in conditions)
            {
                group.AddCondition(condition);
            }

            builder.AddCondition(group);
            return (TCurrent)builder;
        }

        public static TInterface Any<TCurrent, TInterface>(this IConstrainBuilder<TCurrent, TInterface> builder, params Action<IRegexBuilder>[] conditions) where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
        {
            var group = new NoncapturingGroup();

            foreach (var condition in conditions)
            {
                IRegexBuilder subBuilder = new RegexBuilder();
                condition(subBuilder);
                group.AddCondition(subBuilder);
            }

            builder.AddCondition(group);
            return (TCurrent)builder;
        }

        public static TInterface AtomicAny<TCurrent, TInterface>(this IConstrainBuilder<TCurrent, TInterface> builder, params ICondition[] conditions) where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
        {
            var group = new AtomicGroup();

            foreach (var condition in conditions)
            {
                group.AddCondition(condition);
            }

            builder.AddCondition(group);
            return (TCurrent)builder;
        }

        public static TInterface If<TCurrent, TInterface>(this IConstrainBuilder<TCurrent, TInterface> builder, ICondition condition, ICondition @true, ICondition @false) where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
        {
            var match = new ConditionalMatch(condition, @true, @false);
            builder.AddCondition(match);
            return (TCurrent)builder;
        }

        public static TInterface If<TCurrent, TInterface>(this IConstrainBuilder<TCurrent, TInterface> builder, ICondition condition, ICondition @true) where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
        {
            var match = new ConditionalMatch(condition, @true);
            builder.AddCondition(match);
            return (TCurrent)builder;
        }

        public static TInterface SkipWhiteSpaces<TCurrent, TInterface>(this IConstrainBuilder<TCurrent, TInterface> builder) where TCurrent : IConstrainBuilder<TCurrent, TInterface>, TInterface
        {
           
            builder.AddCondition(MetaChars.WhiteSpace, new Quantifier(0, null));
            return (TCurrent)builder;
        }
    }
}
