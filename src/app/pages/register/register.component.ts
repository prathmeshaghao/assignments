import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, FormsModule] // ✅ Import FormsModule
})
export class RegisterComponent {
  user = { name: '', email: '', password: '' };

  register() {
    console.log('User registered:', this.user);
  }
}
