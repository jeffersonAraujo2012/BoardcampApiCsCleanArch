using Boardcamp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain.Games
{
    public class Game
    {
        private Game(long id, string name, string image, int stock, decimal pricePerDay)
        {
            Id = id;
            Name = name;
            Image = image;
            Stock = stock;
            PricePerDay = pricePerDay;
        }

        protected Game() { }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Stock { get; set; }
        public decimal PricePerDay { get; set; }

        public static Result<Game> Criar(long id, string name, string image, int stock, decimal pricePerDay)
        {
            if (id <= 0) return Result.Failure<Game>("O id deve ser maior ou igual que 0");
            if (string.IsNullOrEmpty(name)) return Result.Failure<Game>("Você deve fornecer o nome do jogo");
            if (string.IsNullOrEmpty(image)) return Result.Failure<Game>("Você deve fornecer o endereço da imagem do jogo");
            if (stock < 0) return Result.Failure<Game>("Você não pode definir um estoque negativo");
            if (pricePerDay <= 0) return Result.Failure<Game>("Você não pode definir um preço negativo ou nulo");

            return Result.Success(new Game(id, name, image, stock, pricePerDay));
        }

        public Result Atualizar(string name, string image, int stock, decimal pricePerDay)
        {
            if (string.IsNullOrEmpty(name)) return Result.Failure("Você deve fornecer o nome do jogo");
            if (string.IsNullOrEmpty(image)) return Result.Failure("Você deve fornecer o endereço da imagem do jogo");
            if (stock < 0) return Result.Failure("Você não pode definir um estoque negativo");
            if (pricePerDay <= 0) return Result.Failure("Você não pode definir um preço negativo ou nulo");

            Name = name;
            Image = image;
            Stock = stock;
            PricePerDay = pricePerDay;

            return Result.Success();
        }
    }
}
