import { Component, OnInit } from '@angular/core';

import { AuthService } from '../auth.service';

@Component({
  selector: 'app-silent-callback',
  templateUrl: './silent-callback.component.html',
  styleUrls: ['./silent-callback.component.css']
})
export class SilentCallbackComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.silentSignInAuthentication();
  }

}
