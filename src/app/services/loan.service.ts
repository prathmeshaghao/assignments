import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Loan } from '../models/loan.model';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  private baseUrl = 'https://localhost:7160/api/Loans';

  constructor(private http: HttpClient) {}

  getAllLoans(): Observable<Loan[]> {
    return this.http.get<Loan[]>(this.baseUrl);
  }

  getLoanById(id: number): Observable<Loan> {
    return this.http.get<Loan>(`${this.baseUrl}/${id}`);
  }

  borrowBook(loan: Loan): Observable<any> {
    return this.http.post(this.baseUrl, loan);
  }

  returnBook(id: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, {});
  }

  deleteLoan(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
