import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ticket } from '../models/ticket.model';
@Injectable({
  providedIn: 'root'
})


@Injectable({providedIn: 'root'})
export class TicketService {

  private apiUrl = 'http://localhost:5010/api/Tickets'; 

  constructor(private http:HttpClient) { }

  ObtenerListaTickets(): Observable<Ticket[]>{
    return this.http.get<Ticket[]>(this.apiUrl);
  }


  ObtenerTicketPorId(id:number): Observable<Ticket>{
     return this.http.get<Ticket>(`${this.apiUrl}/${id}`);
  }


 AgregarTicket(ticket: any): Observable<any> {
  return this.http.post(this.apiUrl + "/AgregarTicket", ticket);
}



  ActualizarTicket(id: number, formData: Ticket): Observable<any> {
  return this.http.put(`${this.apiUrl}/ActualizarTicket/${id}`, formData);
  }


  EliminarTicket(id:number): Observable<void>{
     return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}
