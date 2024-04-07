import { Component, OnInit } from '@angular/core';
import { Pizza } from '../../classes/Pizza';
import { CartService } from '../../services/cart-service.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss'
})
export class CartComponent implements OnInit{

  order?:Pizza
  constructor(private cartService:CartService){}


ngOnInit(): void {
    
}




}
