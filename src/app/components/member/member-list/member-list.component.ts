import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-member-list',
  standalone: true,
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
  imports: [CommonModule] // ✅ Add CommonModule
})
export class MemberListComponent {
  members = [
    { name: 'Alice', email: 'alice@example.com' },
    { name: 'Bob', email: 'bob@example.com' }
  ];
}
