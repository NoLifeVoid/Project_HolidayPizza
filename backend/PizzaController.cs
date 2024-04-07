using HolidayPizza;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HolidayPizza
{
    [ApiController]
    // [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public PizzasController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("/pizzas")]
        public ActionResult<string> GetPizzas()
        {

            var pizzas = dbContext.Pizza.ToList();

            return Ok(pizzas);
        }

        [HttpGet("/pizza/{id}")]
        public ActionResult<string> GetPizzasById(int id)
        {


            var pizza = dbContext.Pizza.Find(id);
            return Ok(pizza);
        }

        [HttpPost("/pizzas")]
        public async Task<ActionResult<string>> PostPizzas([FromBody] FrontendPizza FrontendPizza)
        {

         Console.WriteLine(string.Join(", ", FrontendPizza.ToppingLabel));


            //save cheese entity if possible


            Cheese cheese = dbContext.Cheese.SingleOrDefault(c => c.cheeseLabel == FrontendPizza.CheeseLabel);
            if (cheese == null)
            {
                cheese = new Cheese { cheeseLabel = FrontendPizza.CheeseLabel };
                dbContext.Cheese.Add(cheese);
                dbContext.SaveChanges();


            }
            else
            {
                Console.WriteLine("found cheese in db");
            }



            //save sauce entity if possible

            Sauce sauce = dbContext.Sauce.SingleOrDefault(c => c.sauceLabel == FrontendPizza.SauceLabel);
            if (sauce == null)
            {
                sauce = new Sauce { sauceLabel = FrontendPizza.SauceLabel };
                dbContext.Sauce.Add(sauce);
                dbContext.SaveChanges();


            }
            else
            {
                Console.WriteLine("found sauce in db");
            }


            //save dough entity

            Dough dough = dbContext.Dough.SingleOrDefault(c => c.doughLabel == FrontendPizza.DoughLabel);
            if (dough == null)
            {
                dough = new Dough { doughLabel = FrontendPizza.DoughLabel };
                dbContext.Dough.Add(dough);
                dbContext.SaveChanges();


            }
            else
            {
                Console.WriteLine("found dough in db");
            }


            // save topping entities

            List<Topping> toppings = new List<Topping>();


     foreach (string topping in FrontendPizza.ToppingLabel)
    
{ Console.WriteLine("FrontendPizza.ToppingLabel:", topping);
    Topping tempTopping = dbContext.Topping.SingleOrDefault(c => c.toppingLabel == topping);

    Console.WriteLine("TEMP BEFORE ADDING TO TOPPINGS", tempTopping?.toppingLabel);

    if (tempTopping == null)
    {
        tempTopping = new Topping { toppingLabel = topping };
        dbContext.Topping.Add(tempTopping);
        Console.WriteLine("New topping added to the database.");
    }
    else
    {
        Console.WriteLine("Topping found in db");
    }

    toppings.Add(tempTopping); // Add tempTopping to toppings regardless of whether it's null or not
}

dbContext.SaveChanges(); // Save changes to the database
Console.WriteLine("ALLTOPPINGS FROM TOPPINGS:");
foreach(Topping bla in toppings){

    Console.WriteLine(bla.toppingLabel);

}


            string size = FrontendPizza.Size;
            string pizzaLabel = FrontendPizza.PizzaLabel;
            string status = FrontendPizza.Status;

            //gets








            Dough savedDough = await dbContext.Dough.SingleOrDefaultAsync(res => res.doughLabel == dough.doughLabel);
            long doughId = savedDough.doughId;

            Sauce savedSauce = await dbContext.Sauce.SingleOrDefaultAsync(res => res.sauceLabel == sauce.sauceLabel);
            long sauceId = savedSauce.sauceId;

            Cheese savedCheese = await dbContext.Cheese.SingleOrDefaultAsync(res => res.cheeseLabel == cheese.cheeseLabel);
            long cheeseId = savedCheese.cheeseId;


            List<long> toppingIds = new List<long>();
Console.WriteLine("ALLTOPPINGS FROM TOPPINGS II:");
foreach(Topping bla in toppings){

    Console.WriteLine(bla.toppingLabel);
    toppingIds.Add(bla.toppingId);

}

//           foreach (Topping topping in toppings)
// {
//     //Console.WriteLine("Topping Label:", toppingLabel.GetType().ToString());

//     // Check if the topping already exists in the database
//     Topping tempTopping = await dbContext.Topping.SingleOrDefaultAsync(c => c.toppingLabel == topping.toppingLabel);
// dbContext.SaveChanges();
//     if (tempTopping == null)
//     {
//         // If the topping does not exist, create a new Topping entity
//         // tempTopping = new Topping { toppingLabel = tempTopping.toppingLabel };
//         // Console.WriteLine("New topping created:", tempTopping.toppingLabel);

//         // Add the new topping to the list but don't save changes to the database yet
//         toppingIds.Add(tempTopping.toppingId);
//     }
//     else
//     {
//         Console.WriteLine("Topping found in db:", tempTopping.toppingLabel);
//     }
// }

// // After iterating over all topping labels, save changes to the database
// dbContext.SaveChanges();

            string dateString = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
           string randomString = Guid.NewGuid().ToString("N").Substring(0, 12);

            string refStausLabel = pizzaLabel+"__oOo__"+dateString+"__oOo__"+randomString;
            Console.WriteLine(refStausLabel);

            // save pizza

            Pizza pizza = new Pizza { doughId = doughId, sauceId = sauceId, cheeseId = cheeseId, size = size, pizzaLabel = refStausLabel.ToString(), status = status };
            Console.WriteLine(pizza);
            dbContext.Pizza.Add(pizza);
            dbContext.SaveChanges();
            Pizza savedPizza = await dbContext.Pizza.SingleOrDefaultAsync(res => res.pizzaLabel == refStausLabel.ToString());
            long pizzaId = savedPizza.pizzaId;


            foreach (long toppingId in toppingIds)
            {
                Console.WriteLine("IDs",toppingId);// Not ADDED.WHY? EMPTY?
                dbContext.PizzaTopping.Add(new PizzaTopping { pizzaId = pizzaId, toppingId = toppingId });
                
            }
dbContext.SaveChanges();
            //Pizza BackendPizza={}
            {
                // dbContext.Add(BackendPizza);
                return StatusCode(201, "Pizza entity successfully saved.");
            }
        }

        [HttpPut("/pizza/{id}")]
        public ActionResult<string> PutPizza(int id)
        {

            var existingPizza = dbContext.Pizza.Find(id);


            if (existingPizza == null) { return NotFound(); }
            else
            {


                switch (existingPizza.status.ToString())
                {
                    case Status.Done: { return Ok("Pizza Status not changed. Pizza Status: " + existingPizza.status); }
                    case Status.ToDo:
                        { existingPizza.status = Status.InProgress; }
                        break;
                    case Status.InProgress:
                        { existingPizza.status = Status.Done; }
                        break;
                }


                dbContext.Update(existingPizza);
                dbContext.SaveChanges();


                return Ok("Pizza Status has been updated to " + existingPizza.status);
            }
        }






        [HttpDelete("/pizza/{id}")]
        public ActionResult<string> DeletePizza(int id)
        {
            var existingPizza = dbContext.Pizza.Find(id);
            if (existingPizza == null)
            {
                return NotFound();
            }

            dbContext.Pizza.Remove(existingPizza);
            dbContext.SaveChanges();
            return "deleted";
        }



    }
}
