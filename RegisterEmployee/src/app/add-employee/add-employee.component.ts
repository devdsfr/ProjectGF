import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../Model/employee';
import { EmployeeService } from '../service/employee.service';


@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  employee: Employee = new Employee();

  constructor(private route: ActivatedRoute, private employeeService: EmployeeService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      if (id) {
        // Buscar os dados do funcionário pelo ID e preencher o modelo
        this.employeeService.getEmployeeById(id).subscribe(data => {
          this.employee = data;
        }, err => {
          console.log(err);
          alert('Ocorreu um erro ao buscar os dados do funcionário.');
        });
      }
    });
  }

  onSubmit() {
    if (this.employee.EmployeeID) {
      // Atualizar os dados do funcionário existente
      this.employeeService.updateEmployee(this.employee.EmployeeID, this.employee).subscribe(res => {
        console.log(res);
        alert('Funcionário atualizado com sucesso!');
      }, err => {
        console.log(err);
        alert('Ocorreu um erro ao atualizar o funcionário.');
      });
    } else {
      // Adicionar um novo funcionário
      this.employeeService.createEmployee(this.employee).subscribe(res => {
        console.log(res);
        alert('Funcionário adicionado com sucesso!');
      }, err => {
        console.log(err);
        alert('Ocorreu um erro ao adicionar o funcionário.');
      });
    }

    this.employee = new Employee(); // Limpar o modelo do formulário
  }
}


