import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Member } from '../models/member.model';
@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private baseUrl = 'https://localhost:7160/api/Members';

  constructor(private http: HttpClient) {}

  getAllMembers(): Observable<Member[]> {
    return this.http.get<Member[]>(this.baseUrl);
  }

  getMemberById(userId: number): Observable<Member> {
    return this.http.get<Member>(`${this.baseUrl}/${userId}`);
  }

  addMember(member: Member): Observable<any> {
    return this.http.post(this.baseUrl, member);
  }

  updateMember(member: Member): Observable<any> {
    return this.http.put(`${this.baseUrl}/${member.id}`, member);
  }

  deleteMember(userId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${userId}`);
  }
}
