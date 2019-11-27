import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/index";
import { ApiResponse } from "../model/api.response";

@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }
  // Url test
  baseUrl: string = 'http://localhost:52017/';

  getEmployees(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.baseUrl + 'api/employee');
  }

  getEmployee(id: number): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.baseUrl + 'api/employee/' + id);
  }
}
