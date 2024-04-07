import { Component } from '@angular/core';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {
constructor(public appComponent:AppComponent){}



display(what:string){


this.appComponent.displayComponent=what


}

}
