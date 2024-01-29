using Boardcamp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain.Rentals
{
    public class Rental
    {
        private Rental(long id, long customerId, long gameId, DateOnly rentDate, int daysRented, DateOnly? returnDate, decimal originalPrice)
        {
            Id = id;
            CustomerId = customerId;
            GameId = gameId;
            RentDate = rentDate;
            DaysRented = daysRented;
            ReturnDate = returnDate;
            OriginalPrice = originalPrice;
        }

        protected Rental() { }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long GameId { get; set; }
        public DateOnly RentDate { get; set; }
        public int DaysRented { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DelayFee { get; set; } = 0;

        public static Result<Rental> Criar(long id, long customerId, long gameId, int daysRented, decimal originalPrice)
        {
            if (id <= 0) return Result.Failure<Rental>("O id deve ser maior que 0");
            if (customerId <= 0) return Result.Failure<Rental>("O id do cliente deve ser maior que 0");
            if (gameId <= 0) return Result.Failure<Rental>("O id do game deve ser maior que 0");
            if (daysRented <= 0) return Result.Failure<Rental>("A quantidade de dias alugados não pode ser menor que 0");
            if (originalPrice <= 0) return Result.Failure<Rental>("O preço de locação não pode ser negativo");

            var rental = new Rental(
                id,
                customerId,
                gameId,
                DateOnly.FromDateTime(DateTime.Today),
                daysRented,
                null,
                originalPrice
            );

            return Result.Success(rental);
        }

        public Result Return()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly predictedReturnDate = RentDate.AddDays(DaysRented);

            ReturnDate = today;

            if (today > predictedReturnDate)
            {
                int totalDelayDays = (int)(DateTime.Today - new DateTime(predictedReturnDate.Year, predictedReturnDate.Month, predictedReturnDate.Day)).TotalDays;
                DelayFee = totalDelayDays * (OriginalPrice / DaysRented);
            }

            return Result.Success();
        }
    }
}
