import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { BookListComponent } from './components/book/book-list/book-list.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { LoanListComponent } from './components/loan/loan-list/loan-list.component';
import { MemberListComponent } from './components/member/member-list/member-list.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

export const routes: Routes = [
    { path: '', component: DashboardComponent },
    { path: 'books', component: BookListComponent },
    { path: 'categories', component: CategoryListComponent },
    { path: 'loans', component: LoanListComponent },
    { path: 'members', component: MemberListComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent }
  ];