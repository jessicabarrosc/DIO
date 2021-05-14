using CursoMVC.Models;
using CursoAPI.;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CursoTeste
{
    public class CategoriaController
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriaController(Context @object)
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste Categoria" };
        }

        [Fact]

        public async Task Get_Categoria()
        {
            var service = new CategoriaController(_mockContext.Object);
            await service.GetCategoria(1);
            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
        }

    }
}
