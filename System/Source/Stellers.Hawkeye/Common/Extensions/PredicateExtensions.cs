using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Stellers.Hawkeye.Common.Extensions
{
	/// <summary>
	/// A predicate extensions.
	/// </summary>
	public static class PredicateExtensions
	{
		/// <summary>
		/// An Expression&lt;Func&lt;T,bool&gt;&gt; extension method that ands.
		/// </summary>
		/// <typeparam name="T">Generic type parameter.</typeparam>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>An Expression&lt;Func&lt;T,bool&gt;&gt;</returns>
		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
			Expression<Func<T, bool>> right)
		{
			return WithParametersOf(left, right, ExpressionType.AndAlso);
		}

		/// <summary>
		/// An Expression&lt;Func&lt;T,bool&gt;&gt; extension method that ors.
		/// </summary>
		/// <typeparam name="T">Generic type parameter.</typeparam>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>An Expression&lt;Func&lt;T,bool&gt;&gt;</returns>
		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
		{
			return WithParametersOf(left, right, ExpressionType.OrElse);
		}

		/// <summary>
		/// An Expression&lt;Func&lt;T,bool&gt;&gt; extension method that with parameters of.
		/// </summary>
		/// <typeparam name="T">Generic type parameter.</typeparam>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <param name="expressionType">Type of the expression.</param>
		/// <returns>An Expression&lt;Func&lt;T,bool&gt;&gt;</returns>
		private static Expression<Func<T, bool>> WithParametersOf<T>(this Expression<Func<T, bool>> left,
			Expression<Func<T, bool>> right, ExpressionType expressionType)
		{
			var visitor = new ReplaceParameterVisitor { SubstituteMapping = { [right.Parameters[0]] = left.Parameters[0] } };

			Expression body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body));
			return Expression.Lambda<Func<T, bool>>(body, left.Parameters[0]);
		}

		/// <summary>
		/// A replace parameter visitor.
		/// </summary>
		/// <seealso cref="T:System.Linq.Expressions.ExpressionVisitor"/>
		internal class ReplaceParameterVisitor : ExpressionVisitor
		{
			/// <summary>
			/// The substitute mapping.
			/// </summary>
			public Dictionary<Expression, Expression> SubstituteMapping = new Dictionary<Expression, Expression>();

			/// <summary>
			/// Visit parameter.
			/// </summary>
			/// <param name="node">The expression to visit.</param>
			/// <returns>An <see cref="Expression"/>.</returns>
			/// <seealso cref="M:System.Linq.Expressions.ExpressionVisitor.VisitParameter(ParameterExpression)"/>
			/// <exception cref="ArgumentNullException"><paramref name="node"/> is null.</exception>
			protected override Expression VisitParameter(ParameterExpression node)
			{
				Expression newValue;
				return SubstituteMapping.TryGetValue(node, out newValue) ? newValue : node;
			}
		}
	}
}
