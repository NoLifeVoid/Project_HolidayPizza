using System.ComponentModel.DataAnnotations;

namespace HolidayPizza;
public class Pizza
{
    [Key]

    public long pizzaId { get; set; }

    [Required]
    public required string pizzaLabel { get; set; }

    public long? doughId { get; set; }
    public long? sauceId { get; set; }
    public long? cheeseId { get; set; }

    [Required]

    public required string status { get; set; }
    public required string size { get; set; }
}

public class PizzaTopping
{
    [Key]

    public long pizzaToppingId { get; set; }

    [Required]
    public long pizzaId { get; set; }

    [Required]
    public long toppingId { get; set; }
}

public class Topping
{
    [Key]

    public long toppingId { get; set; }

    [Required]
    public required string toppingLabel { get; set; }
}

public class Dough
{
    [Key]

    public long doughId { get; set; }

    [Required]
    public required string doughLabel { get; set; }
}

public class Sauce
{
    [Key]

    public long sauceId { get; set; }

    [Required]
    public required string sauceLabel { get; set; }
}

public class Cheese
{
    [Key]

    public long cheeseId { get; set; }

    [Required]
    public required string cheeseLabel { get; set; }
}



public static class Status
{
    public const string ToDo = "to do";
    public const string Done = "done";
    public const string InProgress ="in progress";
}


public class FrontendPizza
{
    public required  string PizzaLabel { get; set; }
    public required  string Size { get; set; }
    public required  string DoughLabel { get; set; }
    public required  string SauceLabel { get; set; }
    public required  string CheeseLabel { get; set; }
    public required  List<string> ToppingLabel { get; set; }
    public required  string Status { get; set; }
}