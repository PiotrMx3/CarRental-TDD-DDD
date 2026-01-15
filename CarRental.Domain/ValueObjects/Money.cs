using CarRental.Domain.Exceptions;
namespace CarRental.Domain.ValueObjects;




// Records use value based equality. 
// Two instances are considered equal if ALL their properties match, 
// rather than checking if they point to the same memory address (Classes).

// "Structural Equality"
public record Money
{
    private decimal _amount;

    private Money(decimal amount)
    {
        this._amount = amount;
    }

    public decimal Amount
    {
        get { return this._amount; }
    }

    public static Money Of(decimal amount)
    {
        if (amount < 0) throw new InvalidMoneyAmountException(amount);

        return new Money(amount);
    }

    public static Money operator +(Money a, Money b)
    {
        return Money.Of(a.Amount + b.Amount);
    }
}
