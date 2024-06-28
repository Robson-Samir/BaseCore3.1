import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Pedido } from 'src/model/pedido';
import { PedidoService } from 'src/service/pedido.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//PROJETO PARA FINS DIDATICOS


export class AppComponent implements OnInit {
  title = 'front-teste';
  pedidoForm!: FormGroup;

  constructor(private pedidoService: PedidoService, private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.pedidoForm = this._formBuilder.group({
      Idcliente: ['', [Validators.required]],
      NumeroPedido: ['', [Validators.required, Validators.pattern(/^-?([0-9]\d*)?$/), Validators.maxLength(20)]],
      Descricao: ['', [Validators.required]],
      Valor: ['', [Validators.required, Validators.pattern(/^-?([0-9]\d*)?$/)]],
      Cep: ['', [Validators.required, Validators.minLength(4), Validators.pattern(/^-?([0-9]\d*)?$/), Validators.maxLength(10)]],
      Rua: ['', [Validators.required, Validators.minLength(3)]],
      Numero: ['', [Validators.required, Validators.pattern(/^-?([0-9]\d*)?$/), Validators.maxLength(20)]],
      Bairro: ['', [Validators.required, Validators.minLength(3)]],
      Cidade: ['', [Validators.required, Validators.minLength(3)]],
      Estado: ['', [Validators.required, Validators.minLength(3)]]
    });
  }

  gravarPedido() {
    let pedido = new Pedido();
    pedido.idUser = parseInt(this.pedidoForm.get("Idcliente")?.value);
    pedido.numeroPedido = parseInt(this.pedidoForm.get("NumeroPedido")?.value);
    pedido.descricao = this.pedidoForm.get("Descricao")?.value;
    pedido.valor = this.pedidoForm.get("Valor")?.value;
    pedido.cep = this.pedidoForm.get("Cep")?.value;
    pedido.rua = this.pedidoForm.get("Rua")?.value;
    pedido.numero = parseInt(this.pedidoForm.get("Numero")?.value);
    pedido.bairro = this.pedidoForm.get("Bairro")?.value;
    pedido.cidade = this.pedidoForm.get("Cidade")?.value;
    pedido.estado = this.pedidoForm.get("Estado")?.value;
    this.pedidoService.registraPedido(pedido)
    .subscribe(
      (insere: any) => {
        if (insere.resultado == true) {
          alert("Ação realizada com sucesso");
          return;
        }
      }
    );

  }
}
