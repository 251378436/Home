import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProtectedComponent } from './protected/protected.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { CallApiComponent } from './call-api/call-api.component';
import { UploadComponent } from './upload/upload.component';

import { AuthGuardService } from './auth-guard.service';
import { AuthService } from './auth.service';

const routes: Routes = [
  {
    path: '',
    children: []
  },
  {
    path: 'protected',
    component: ProtectedComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'auth-callback',
    component: AuthCallbackComponent
  },
  {
    path: 'call-api',
    component: CallApiComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'upload',
    component: UploadComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthService, AuthGuardService]
})
export class AppRoutingModule { }
