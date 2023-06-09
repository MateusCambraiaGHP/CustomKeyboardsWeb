import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatIconModule } from "@angular/material/icon";
import { MatToolbarModule } from "@angular/material/toolbar";
import { TemplateComponent } from "./components/template/template.component";
import { FooterComponent } from "./components/template/footer/footer.component";
import { NavbarComponent } from "./components/template/navbar/navbar.component";
import { SidebarComponent } from "./components/template/sidebar/sidebar.component";
import { FormComponent } from "./components/generics/form/form.component";
import { ButtonComponent } from "./components/generics/button/button.component";
import { CardComponent } from "./components/generics/card/card.component";
import { TableComponent } from "./components/generics/table/table.component";
import { InputComponent } from "./components/generics/form/input/input.component";
import { CustomerFormComponent } from "./components/customer/customer-form/customer-form.component";
import { CustomersDashboardComponent } from "./components/customer/customers-dashboard/customers-dashboard.component";
import { TableCustomersComponent } from "./components/customer/table-customers/table-customers.component";
import { ReactiveFormsModule } from "@angular/forms";
import { OverlayLoadingComponent } from './components/generics/overlay-loading/overlay-loading.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {MatTableModule} from '@angular/material/table';

@NgModule({
    declarations: [
        AppComponent,
        TemplateComponent,
        FooterComponent,
        NavbarComponent,
        SidebarComponent,
        FormComponent,
        ButtonComponent,
        CardComponent,
        TableComponent,
        InputComponent,
        CustomerFormComponent,
        CustomersDashboardComponent,
        TableCustomersComponent,
        OverlayLoadingComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatIconModule,
        MatToolbarModule,
        ReactiveFormsModule,
        MatProgressSpinnerModule,
        MatTableModule
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
