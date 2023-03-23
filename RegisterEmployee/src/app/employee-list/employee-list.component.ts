import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Atoliberacao } from '../Model/atoLiberacao';
import { AtoLiberacaoService } from '../cadastroatoliberacao/service/atoLiberacao.service';


@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  atoLiberacoes: Atoliberacao[] = [];

  constructor(private atoLiberacaoService: AtoLiberacaoService, private router: Router) { }

  ngOnInit(): void {
    this.getAtoLiberacao();

  }

  getAtoLiberacao() {
    this.atoLiberacaoService.getAtoLiberacao()
      .subscribe(data => {
        this.atoLiberacoes = data;
      }, err => {
        console.log(err);
        alert('Ocorreu um erro ao buscar os funcionários.');
      });
  }

  async onDeleteAtoLiberacao(id: string) {
    if (confirm('Tem certeza que deseja excluir este funcionário?')) {
      try {
        const res = await this.atoLiberacaoService.deleteAtoLiberacao(id);
        console.log(res);
        this.getAtoLiberacao();
      } catch (err) {
        console.log(err);
        alert('Ocorreu um erro ao excluir o funcionário.');
      }
    }
  }

  deleteAtoLiberacao(id: string) {
    if (confirm('Tem certeza que deseja excluir este funcionário?')) {
      this.atoLiberacaoService.deleteAtoLiberacao(id)
        .then(res => {
          console.log(res);
          this.getAtoLiberacao();
        }, err => {
          console.log(err);
          alert('Ocorreu um erro ao excluir o funcionário.');
        });
    }
  }

  editAtoLiberacao(id: string) {
    this.router.navigate(['/add-employee/', id]);
  }
}
