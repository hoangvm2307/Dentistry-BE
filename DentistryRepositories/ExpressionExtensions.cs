using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DentistryRepositories
{
  public static class ExpressionExtensions
  {
    public static Expression<TDelegate> AndAlso<TDelegate>(this Expression<TDelegate> left, Expression<TDelegate> right)
    {
      return Expression.Lambda<TDelegate>(Expression.AndAlso(left, right), left.Parameters);
    }
  }
}