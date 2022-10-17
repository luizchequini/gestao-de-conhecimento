using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimento.Infraestrutura.Util;

public class IncludeSai<T> : List<Expression<Func<T, object>>> where T : class
{
    public IncludeSai(params Expression<Func<T, object>>[] includes)
    {
        this.AddRange(includes.ToList());
    }
}
