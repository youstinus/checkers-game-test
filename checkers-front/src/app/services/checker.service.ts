import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class CheckerService {

  private readonly squaresApi = `${environment.webApiUrl}/checkers`;
  constructor(private http: HttpClient) { }

}
