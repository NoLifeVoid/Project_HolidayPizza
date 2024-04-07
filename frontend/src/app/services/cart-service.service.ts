import { Injectable } from '@angular/core';
import { Pizza } from '../classes/Pizza';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  pizzas?:Pizza[]

  constructor(private http:HttpClient) { }

  addPizza(pizza:Pizza){
    this.pizzas?.push(pizza)
  }
  removePizza(pizza:Pizza){
    this.pizzas=this.pizzas?.filter(res=>res!==pizza)
  }
  discardPizzas(){
    this.pizzas=[]
  }

  async purchasePizzas(){
    if(this.pizzas){
    for (let pizza of this.pizzas){
      pizza.assemble()
      this.http.post('http://localhost:5000/pizzas',pizza)}
    
  }}
}
