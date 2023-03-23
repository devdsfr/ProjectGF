import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { RouterModule, Routes } from '@angular/router';
import { CadastroatoliberacaoComponent } from './cadastroatoliberacao/cadastroatoliberacao.component';

const routes: Routes = [
  { path: '', redirectTo: '/employee-list', pathMatch: 'full' },
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'add-employee', component: AddEmployeeComponent },
  { path: 'cadastroatolibercacao', component: CadastroatoliberacaoComponent},
  { path: 'cadastroatolibercacao/:id', component: CadastroatoliberacaoComponent},
  { path: 'add-employee/:id', component: AddEmployeeComponent }
];

@NgModule({
  declarations: [
      AppComponent,
      EmployeeListComponent,
      AddEmployeeComponent,
      CadastroatoliberacaoComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
