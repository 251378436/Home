import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';

import { AuthService } from '../auth.service';

@Component({
  selector: 'app-call-api',
  templateUrl: './call-api.component.html',
  styleUrls: ['./call-api.component.css']
})
export class CallApiComponent implements OnInit {
  response: Object | null = null;
  singleOrder: Object | null = null;
  
  constructor(private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
  }

  getSalesOrders() {
    var request = this.http.get<any>("https://localhost:5001/SalesOrders");
                

    request.subscribe(
      response => this.response = JSON.stringify(response));
  }

  getSalesOrder(orderId: number) {
    var request = this.http.get<any>(`https://localhost:5001/SalesOrders/${orderId}`);
                

    request.subscribe(
      singleOrder => this.singleOrder = JSON.stringify(singleOrder));
  }
}
