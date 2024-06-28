import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, retry } from 'rxjs';
import { Pedido } from 'src/model/pedido';


@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  constructor(private http: HttpClient) { }

  public registraPedido(pedido: Pedido) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + 'token'
      })
    };

    return this.http.post<boolean>(`https://localhost:44304/api/pedido/cadpedido`, pedido, httpOptions)
    .pipe(
      retry(2),
      catchError(err => err)
    );
  }
}
