import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SquareService {

  private readonly squaresApi = `${environment.webApiUrl}/squares`;
  constructor(private http: HttpClient) { }

}
