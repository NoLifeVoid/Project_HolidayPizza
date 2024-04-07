use pizza;

create table if not exists Topping (
    toppingId serial primary key,
    toppingLabel varchar(255) unique
);

create table if not exists Dough (
    doughId serial primary key,
    doughLabel varchar(255) unique
);

create table if not exists Sauce (
    sauceId serial primary key,
    sauceLabel varchar(255) unique
);

create table if not exists Cheese (
    cheeseId serial primary key,
    cheeseLabel varchar(255) unique
);

create table if not exists Pizza (
    pizzaId serial primary key,
    pizzaLabel varchar(255) not null,
    doughId bigint UNSIGNED Not NULL,
    sauceId bigint UNSIGNED  Not NULL,
    cheeseId bigint UNSIGNED  Not NULL,
    status ENUM('done', 'in progress', 'to do') NOT NULL DEFAULT 'to do',
    size ENUM('small','big','familiy','party') NOT NULL,
    foreign key (doughId) references Dough(doughId),
    foreign key (sauceId) references Sauce(sauceId),
    foreign key (cheeseId) references Cheese(cheeseId)
);

create table if not exists PizzaTopping (
    PizzaToppingID serial primary key,
    pizzaId bigint UNSIGNED  Not NULL,
    toppingId bigint UNSIGNED Not NULL,
    foreign key (pizzaId) references Pizza(pizzaId),
    foreign key (toppingId) references Topping(toppingId)
);

