import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loan-list',
  standalone: true,
  templateUrl: './loan-list.component.html',
  styleUrls: ['./loan-list.component.css'],
  imports: [CommonModule] // ✅ Add CommonModule
})
export class LoanListComponent {
  loans = [
    { bookId: 1, memberId: 101, dueDate: '2025-04-15' },
    { bookId: 2, memberId: 102, dueDate: '2025-05-01' }
  ];
}
