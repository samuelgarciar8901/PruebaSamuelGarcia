import { Routes } from '@angular/router';
import { TicketComponent } from './components/ticket/ticket.component';

export const routes: Routes = [
  { path: '', redirectTo: '/tickets', pathMatch: 'full' },
  { path: 'tickets', component: TicketComponent },
  { path: '**', redirectTo: '/tickets' }
];