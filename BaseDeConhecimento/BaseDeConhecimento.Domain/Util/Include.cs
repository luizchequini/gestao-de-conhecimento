using System.Linq.Expressions;

namespace BaseDeConhecimento.Domain.Util;

public class Include<T> : List<Expression<Func<T, object>>> where T : class
{
    public Include(params Expression<Func<T, object>>[] includes)
    {
        this.AddRange(includes.ToList());
    }
}
