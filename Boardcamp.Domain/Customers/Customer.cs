using Boardcamp.Domain.Results;

namespace Boardcamp.Domain.Customers
{
    public class Customer
    {
        private Customer(long id, string name, string phone, string cpf, DateOnly birthday)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Cpf = cpf;
            Birthday = birthday;
        }

        protected Customer() { }

        public long Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string Cpf { get; private set; } = null!;
        public DateOnly Birthday { get; private set; }

        public static Result<Customer> Criar(long id, string name, string phone, string cpf, DateOnly birthday)
        {
            if (id <= 0) return Result.Failure<Customer>("O id deve ser maior que 0");
            if (string.IsNullOrEmpty(name)) return Result.Failure<Customer>("Você deve fornecer um nome para o usuário");
            if (string.IsNullOrEmpty(phone)) return Result.Failure<Customer>("Você deve fornececer um telefone para o usuário");
            if (string.IsNullOrEmpty(cpf)) return Result.Failure<Customer>("Você deve fornecer o cpf do usuário");
            if (birthday < DateOnly.FromDateTime(DateTime.Today)) return Result.Failure<Customer>("Data de nascimento inválida");

            return Result.Success(new Customer(id, name, phone, cpf, birthday));
        }

        public Result Atualizar(string name, string phone, string cpf, DateOnly birthday)
        {
            if (string.IsNullOrEmpty(name)) return Result.Failure("Você deve fornecer um nome para o usuário");
            if (string.IsNullOrEmpty(phone)) return Result.Failure("Você deve fornececer um telefone para o usuário");
            if (string.IsNullOrEmpty(cpf)) return Result.Failure("Você deve fornecer o cpf do usuário");
            if (birthday < DateOnly.FromDateTime(DateTime.Today)) return Result.Failure("Data de nascimento inválida");

            Name = name;
            Phone = phone;
            Cpf = cpf;
            Birthday = birthday;

            return Result.Success();
        }
    }
}
