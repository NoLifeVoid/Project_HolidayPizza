import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MenuComponent } from './components/menu/menu.component';
import { LandingComponent } from './components/landing/landing.component';
import { MyOrdersComponent } from './components/my-orders/my-orders.component';
import { AllOrdersComponent } from './components/all-orders/all-orders.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { UserLogComponent } from './components/user-log/user-log.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignOutComponent } from './components/sign-out/sign-out.component';
import { SignOffComponent } from './components/sign-off/sign-off.component';
import {MatButtonModule} from '@angular/material/button'
import {MatTabsModule} from '@angular/material/tabs';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import { CartComponent } from './components/cart/cart.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    LandingComponent,
    MyOrdersComponent,
    AllOrdersComponent,
    PurchaseComponent,
    UserLogComponent,
    SignUpComponent,
    SignInComponent,
    SignOutComponent,
    SignOffComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,MatButtonModule,MatTabsModule,MatCardModule,MatIconModule,HttpClientModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
