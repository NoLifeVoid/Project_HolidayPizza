export class Pizza{
    PizzaId?:number
    pizzaLabel!:string
    size!:Size
    doughLabel!:Dough
    sauceLabel!:Sauce
    cheeseLabel!:Cheese
    toppingLabel!:Topping[]
    status?:Status
    

    constructor(name:string,dough:Dough,sauce:Sauce,cheese:Cheese,toppings:Topping[]){
        this.pizzaLabel=name
        this.doughLabel=dough
        this.sauceLabel=sauce
        this.cheeseLabel=cheese
        this.toppingLabel=toppings
    }

    selectSize(size:Size){
        this.size=size
    }

    changeDough(dough:Dough){
        this.doughLabel=dough
    }

    changeSauce(sauce:Sauce){
        this.sauceLabel=sauce
    }

    addTopping(topping:Topping){
        this.toppingLabel.push(topping)
    }

    removeTopping(topping:Topping){
        if(this.toppingLabel.includes(topping)){
            this.toppingLabel=this.toppingLabel.filter(res=>res!==topping)
        }
    }
    assemble(){
        this.status=Status.toDo
        return this
    }
}

export class Status{
    static toDo="to do"
    static inProgress="in progress"
    static done="done"
}

export class Size{
    static small:string="small"
    static big:string="big"
    static family:string="family"
    static party:string="party"
}

export class Dough{
    static sourDough:string="sour-dough"
    static fullGrain:string="full-grain"
    static wheat:string="wheat"
    static corn:string="corn"
}

export class Sauce{
    static tomato:string="tomato"
    static chilli:string="chilli"
    static cherryTomato:string="cherry-tomato"
}

export class Cheese{
    static cheddar:string="cheddar"
    static mozzarella:string="mozzarella"
    static parmesan:string="parmesan"

}

export class Topping {
    public static funghi: string = "funghi";
    public static pepperoni: string = "pepperoni";
    public static ham: string = "ham";
    public static pineapple: string = "pineapple";
    public static bacon: string = "bacon";
    public static olives: string = "olives";
    public static mushrooms: string = "mushrooms";
    public static onions: string = "onions";
    public static peppers: string = "peppers";
    public static sausage: string = "sausage";
    public static tomatoes: string = "tomatoes";
    public static chicken: string = "chicken";
    public static beef: string = "beef";
    public static shrimp: string = "shrimp";
    public static anchovies: string = "anchovies";
    public static spinach: string = "spinach";
    public static jalapenos: string = "jalapenos";
    public static fetaCheese: string = "feta cheese";
    public static artichokes: string = "artichokes";
    public static garlic: string = "garlic";
    public static basil: string = "basil";
    public static corn: string = "corn";
    public static eggplant: string = "eggplant";
    public static chorizo: string = "chorizo";
    public static arugula: string = "arugula";
    public static capers: string = "capers";
    public static sunDriedTomatoes: string = "sun-dried tomatoes";
    public static pesto: string = "pesto";
    public static redOnion: string = "red onion";
    public static truffleOil: string = "truffle oil";
}


export interface PizzaInterface{

        id?:number
        pizzaLabel:string
        size:Size
        doughLabel:Dough
        sauceLabel:Sauce
        cheeseLabel:Cheese
        toppingLabel:Topping[]
        status?:Status

}

export const PizzaMock: Pizza[] = [
    new Pizza("Margherita", Dough.fullGrain, Sauce.tomato, Cheese.mozzarella, [Topping.funghi, Topping.pepperoni]),
    new Pizza("Pepperoni", Dough.fullGrain, Sauce.tomato, Cheese.mozzarella, [Topping.pepperoni]),
    new Pizza("Vegetarian", Dough.wheat, Sauce.tomato, Cheese.mozzarella, [Topping.funghi, Topping.pepperoni]),
    new Pizza("Hawaiian", Dough.corn, Sauce.cherryTomato, Cheese.cheddar, [Topping.ham]),
    new Pizza("BBQ Chicken", Dough.fullGrain, Sauce.tomato, Cheese.parmesan, [Topping.ham, Topping.pepperoni]),
    new Pizza("Meat Lover's", Dough.sourDough, Sauce.chilli, Cheese.mozzarella, [Topping.ham, Topping.pepperoni]),
    new Pizza("Supreme", Dough.fullGrain, Sauce.tomato, Cheese.mozzarella, [Topping.funghi, Topping.pepperoni]),
    new Pizza("Four Cheese", Dough.wheat, Sauce.tomato, Cheese.cheddar, [Topping.ham, Topping.pepperoni]),
    new Pizza("Buffalo Chicken", Dough.fullGrain, Sauce.cherryTomato, Cheese.mozzarella, [Topping.ham]),
    new Pizza("Spinach and Feta", Dough.corn, Sauce.tomato, Cheese.parmesan, [Topping.funghi, Topping.pepperoni])
];