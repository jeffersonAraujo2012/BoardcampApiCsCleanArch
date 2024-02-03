using Boardcamp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain.Rentals
{
    public class Rental : Entity
    {
        private Rental(long customerId, long gameId, DateOnly rentDate, int daysRented, DateOnly? returnDate, decimal originalPrice)
        {
            CustomerId = customerId;
            GameId = gameId;
            RentDate = rentDate;
            DaysRented = daysRented;
            ReturnDate = returnDate;
            OriginalPrice = originalPrice;
        }

        protected Rental() { }

        public long CustomerId { get; private set; }
        public long GameId { get; private set; }
        public DateOnly RentDate { get; private set; }
        public int DaysRented { get; private set; }
        public DateOnly? ReturnDate { get; private set; }
        public decimal OriginalPrice { get; private set; }
        public decimal DelayFee { get; private set; } = 0;

        public static Result<Rental> Criar(long customerId, long gameId, int daysRented, decimal originalPrice)
        {
            if (customerId <= 0) return Result.Failure<Rental>("O id do cliente deve ser maior que 0");
            if (gameId <= 0) return Result.Failure<Rental>("O id do game deve ser maior que 0");
            if (daysRented <= 0) return Result.Failure<Rental>("A quantidade de dias alugados não pode ser menor que 0");
            if (originalPrice <= 0) return Result.Failure<Rental>("O preço de locação não pode ser negativo");

            var rental = new Rental(
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
