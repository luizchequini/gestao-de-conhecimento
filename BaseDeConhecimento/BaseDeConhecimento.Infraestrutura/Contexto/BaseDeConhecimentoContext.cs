using BaseDeConhecimento.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimento.Infraestrutura.Contexto;

public class BaseDeConhecimentoContext : DbContext
{


    public BaseDeConhecimentoContext(DbContextOptions<BaseDeConhecimentoContext> options) : base(options)
    {
    }

    public DbSet<Conhecimento> Conhecimentos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

}
