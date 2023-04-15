using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository.Context;

namespace Fiap.Api.AspNet.Repository
{
    public class BoiaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public BoiaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<BoiaModel> Listar()
        {
            var lista = new List<BoiaModel>();
            lista = dataBaseContext.Boia.ToList<BoiaModel>();
            return lista;
        }

        public BoiaModel Consultar(int id)
        {
            var boia = dataBaseContext.Boia.Find(id);
            return boia;
        }

        public void Inserir(BoiaModel boia)
        {
            dataBaseContext.Boia.Add(boia);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(BoiaModel boia)
        {
            dataBaseContext.Boia.Update(boia);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var boia = new BoiaModel { FerramentaId = id };

            dataBaseContext.Boia.Remove(boia);
            dataBaseContext.SaveChanges();
        }
    }
}
