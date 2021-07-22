using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("98d50818-ff7d-41f2-9239-7ca28a905a66"), new Jogo{Id = Guid.Parse("98d50818-ff7d-41f2-9239-7ca28a905a66"), Nome="Jogo 1", Produtora="Produtora 1", Preco=10.0} },
            {Guid.Parse("55995145-f002-41d6-969d-e41ec14b6494"), new Jogo{Id = Guid.Parse("55995145-f002-41d6-969d-e41ec14b6494"), Nome="Jogo 2", Produtora="Produtora 1", Preco=20.0} },
            {Guid.Parse("2d0b527b-c939-4a1e-bbb2-c7465ac715b9"), new Jogo{Id = Guid.Parse("2d0b527b-c939-4a1e-bbb2-c7465ac715b9"), Nome="Jogo 3", Produtora="Produtora 2", Preco=30.0} },
        };
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar conex com BD
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
    }
}
