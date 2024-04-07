import { Component, OnInit } from '@angular/core';
import { Pizza, PizzaMock } from '../../classes/Pizza';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.scss'] // Corrected property name
})
export class PurchaseComponent implements OnInit {

  menu: Pizza[] = []; // Define menu as an array of Pizza objects

  ngOnInit(): void {
    this.menu = PizzaMock; // Assign PizzaMock to the menu property
    console.log(this.menu);
  }
  
}
