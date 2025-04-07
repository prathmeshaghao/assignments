import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-category-list',
  standalone: true,
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
  imports: [CommonModule] // ✅ Add CommonModule
})
export class CategoryListComponent {
  categories = [
    { name: 'Fiction' },
    { name: 'Science' },
    { name: 'History' }
  ];
}
