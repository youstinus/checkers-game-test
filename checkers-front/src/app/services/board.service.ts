import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Square } from '../models/square';
import { Board } from '../models/board';

@Injectable({
  providedIn: 'root'
})
export class BoardService {
  private readonly boardsApi = `${environment.webApiUrl}/boards`;
  constructor(private http: HttpClient) { }
  private readonly httpOptions =
    {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        })
    };

  getBoard(id: number): Observable<Board> {
    return this.http.get<Board>(`${this.boardsApi}/${id}`);
  }

  createBoard(): Observable<Board> {
    return this.http.post<Board>(this.boardsApi, this.httpOptions);
  }
}
