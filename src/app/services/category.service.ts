import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private baseUrl = 'https://localhost:7160/api/Categories';

  constructor(private http: HttpClient) {}

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl);
  }

  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.baseUrl}/${id}`);
  }

  addCategory(category: Category): Observable<any> {
    return this.http.post(this.baseUrl, category);
  }

  updateCategory(category: Category): Observable<any> {
    return this.http.put(`${this.baseUrl}/${category.id}`, category);
  }

  deleteCategory(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
