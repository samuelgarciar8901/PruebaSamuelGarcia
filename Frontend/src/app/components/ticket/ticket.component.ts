import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import { TicketService } from '../../services/ticket.service';
import { Ticket } from '../../models/ticket.model';

@Component({
  selector: 'app-ticket',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './ticket.component.html',
  styleUrl: './ticket.component.css'
})
export class TicketComponent {

  tickets: Ticket[] = [];
  paginatedTickets: Ticket[] = [];

  ticket: Ticket = {
    id: 0,
    usuario: '',
    descripcion: '',
    fechaCreacion: '',
    fechaActualizacion: '',
    estatus: false
  };

  formVisible = false;
  editingId: number | null = null;

  paginaActual = 1;
  registrosPorPagina = 5;
  totalPaginas = 1;

  constructor(private ticketService: TicketService) {}

  ngOnInit() {
    this.loadTickets();
  }

  toggleForm() {
    this.formVisible = !this.formVisible;
  }

  loadTickets() {
    this.ticketService.ObtenerListaTickets().subscribe({
      next: (data) => {
        this.tickets = data;
        this.calcularPaginacion();
      },
      error: (err) => console.error('Error cargando tickets', err)
    });
  }

  calcularPaginacion() {
    this.totalPaginas = Math.ceil(this.tickets.length / this.registrosPorPagina);
    const inicio = (this.paginaActual - 1) * this.registrosPorPagina;
    const fin = inicio + this.registrosPorPagina;
    this.paginatedTickets = this.tickets.slice(inicio, fin);
  }

  addTicket() {
    const ticketEnviado = {
      id: this.editingId ?? 0,
      usuario: this.ticket.usuario,
      descripcion: this.ticket.descripcion,
      estatus: this.ticket.estatus
    };

    if (this.editingId) {
      // Actualizar ticket existente
      this.ticketService.ActualizarTicket(this.editingId,this.ticket).subscribe({
        next: () => {
          this.loadTickets();
          this.resetForm();
        },
        error: (err) => console.error('Error actualizando ticket', err)
      });
    } else {
      // Agregar nuevo ticket
      this.ticketService.AgregarTicket(ticketEnviado).subscribe({
        next: () => {
          this.loadTickets();
          this.resetForm();
        },
        error: (err) => console.error('Error agregando ticket', err)
      });
    }
  }

  editTicket(ticket: Ticket) {
    this.ticket = { ...ticket };
    this.editingId = ticket.id!;
    this.formVisible = true;
  }

  deleteTicket(id: number) {
    Swal.fire({
      title: '¿Eliminar Ticket?',
      text: 'Esta acción no se puede revertir.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      confirmButtonText: 'Eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.ticketService.EliminarTicket(id).subscribe(() => {
          this.loadTickets();
        });
      }
    });
  }

  resetForm() {
    this.ticket = {
      id: 0,
      usuario: '',
      descripcion: '',
      fechaCreacion: '',
      fechaActualizacion: '',
      estatus: false
    };
    this.editingId = null;
    this.formVisible = false;
  }

  setPagina(p: number) {
    if (p < 1 || p > this.totalPaginas) return;
    this.paginaActual = p;
    this.calcularPaginacion();
  }
}
