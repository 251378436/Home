import { Component } from '@angular/core';
import { environment } from '../environments/environment';
import * as process from 'process';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'oidc-client';
  apiUrl: any;

  constructor(){
    console.log(environment);
    this.apiUrl = environment.apiUrl;
    // var env = process.env;
    console.log(process);
    console.log(process.env['apiUrl']);
  }
}
