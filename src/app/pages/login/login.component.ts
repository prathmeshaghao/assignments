import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [CommonModule, FormsModule] // ✅ Import required modules
})
export class LoginComponent {
  credentials = { email: '', password: '' };

  constructor(private authService: AuthService) {}

  login(): void {
    this.authService.login(this.credentials).subscribe(response => {
      localStorage.setItem('token', response.token);
      alert('Login Successful!');
    });
  }
}
