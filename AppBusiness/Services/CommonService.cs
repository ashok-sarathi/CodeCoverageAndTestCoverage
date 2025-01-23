using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppBusiness.Services
{
    public interface ICommonService<TModel, TReadModel>
    {
        public IEnumerable<TReadModel> Get();
        public TModel? GetById(int id);
        public void Add(TModel model);
        public void Update(TModel model);
        public void Delete(int id);
    }

    [ExcludeFromCodeCoverage]
    public abstract class CommonService<TEntity, TModel, TReadModel>
        where TEntity : class
        where TModel : class
        where TReadModel : class
    {
        protected readonly SchoolContext Context;
        protected readonly DbSet<TEntity> Table;
        protected readonly IMapper Mapper;
        public CommonService(SchoolContext context, IMapper mapper)
        {
            Context = context;
            Table = Context.Set<TEntity>();
            Mapper = mapper;
        }

        public abstract IEnumerable<TReadModel> Get();

        public TModel? GetById(int id)
        {
            return this.Mapper.Map<TModel>(Table.Find(id));
        }

        public void Add(TModel model)
        {
            Table.Add(this.Mapper.Map<TEntity>(model));
            Context.SaveChanges();
        }

        public void Update(TModel model)
        {
            Table.Update(this.Mapper.Map<TEntity>(model));
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = Table.Find(id);
            Table.Remove(data);
            Context.SaveChanges();
        }
    }
}
