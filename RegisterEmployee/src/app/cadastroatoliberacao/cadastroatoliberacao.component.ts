import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Atoliberacao } from '../Model/atoLiberacao';
import { AtoLiberacaoService } from './service/atoLiberacao.service';

@Component({
  selector: 'app-cadastroatoliberacao',
  templateUrl: './cadastroatoliberacao.component.html',
  styleUrls: ['./cadastroatoliberacao.component.css']
})
export class CadastroatoliberacaoComponent implements OnInit {

  atoLiberacao: Atoliberacao = new Atoliberacao();

  constructor(private route: ActivatedRoute, private atoLiberacaoService: AtoLiberacaoService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      if (id) {
        // Buscar os dados do funcionário pelo ID e preencher o modelo
        this.atoLiberacaoService.getAtoLiberacaoById(id).subscribe(data => {
          this.atoLiberacao = data;
        }, err => {
          console.log(err);
          alert('Ocorreu um erro ao buscar os dados do funcionário.');
        });
      }
    });
  }

  onSubmit() {
    if (this.atoLiberacao.numero_ato_liberacao) {
      // Atualizar os dados do funcionário existente
      this.atoLiberacaoService.updateAtoLiberacao(this.atoLiberacao.numero_ato_liberacao, this.atoLiberacao).subscribe(res => {
        console.log(res);
        alert('Funcionário atualizado com sucesso!');
      }, err => {
        console.log(err);
        alert('Ocorreu um erro ao atualizar o funcionário.');
      });
    } else {
      // Adicionar um novo funcionário
      this.atoLiberacaoService.createAtoLiberacao(this.atoLiberacao).subscribe(res => {
        console.log(res);
        alert('Funcionário adicionado com sucesso!');
      }, err => {
        console.log(err);
        alert('Ocorreu um erro ao adicionar o funcionário.');
      });
    }

    this.atoLiberacao = new Atoliberacao(); // Limpar o modelo do formulário
  }

}
