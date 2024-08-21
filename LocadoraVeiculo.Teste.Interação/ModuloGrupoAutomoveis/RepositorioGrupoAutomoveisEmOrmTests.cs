using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Infra.Orm.Compartinhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomovel;
using Microsoft.IdentityModel.Tokens;

namespace LocadoraVeiculo.Teste.Interação.ModuloAutomoveis
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioGrupoAutomoveisEmOrmTests
    {
        private LocadoraDbContext dbContext;
        private RepositorioGrupoAutomoveisEmOrm repositorio;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext = new LocadoraDbContext();

            dbContext.GruposAutomoveis.RemoveRange(dbContext.GruposAutomoveis);

            repositorio = new RepositorioGrupoAutomoveisEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorio.Inserir);
        }

        [TestMethod]
        public void Deve_Inserir_GrupoAutomovel()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew()
                .With(g =>g.Id = 0)
                .Persist();

            var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoSelecionado);
            Assert.AreEqual(grupo,grupoSelecionado);
        }
        [TestMethod]
        public void Deve_Editar_GrupoAutomovel()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            grupo.Nome = "Teste de edit";
            repositorio.Editar(grupo);

            var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);
            
            Assert.IsNotNull(grupoSelecionado);
            Assert.AreEqual(grupo, grupoSelecionado);
        }
        [TestMethod]
        public void Deve_Excluir_GrupoAutomovel()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            repositorio.Excluir(grupo);

            var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

            var grupos = repositorio.SelecionarTodos();
            Assert.IsNull(grupoSelecionado);
            Assert.AreEqual(0,grupos.Count);
        }
    }
}
