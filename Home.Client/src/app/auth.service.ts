import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User, WebStorageStateStore } from 'oidc-client';
import {CookieStorage} from 'cookie-storage';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private manager = new UserManager(getClientSettings());
  private user: User | null = null;

  constructor() {
    this.manager.getUser().then(user => {
      this.user = user;
    });
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user?.profile;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user?.token_type} ${this.user?.access_token}`;
  }

  startAuthentication(): Promise<void> {
    return this.manager.signinRedirect({
      extraQueryParams: { 
        audience: 'https://localhost:5001/'
      },
    });
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinRedirectCallback().then(user => {
      this.user = user;
    });
  }

  completeLogout() {
    this.user = null;
    return this.manager.signoutRedirectCallback();
  }

  silentSignInAuthentication() {
    return this.manager.signinSilentCallback();
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'http://dev-zjgs-longbo.au.auth0.com/',
    client_id: 'GSeMkqoUAT7h9dNOkO0jsPgF1AW39tEi',
    redirect_uri: 'http://localhost:4200/auth-callback',
    post_logout_redirect_uri: 'http://localhost:4200/',
    response_type: "id_token token",
    scope: "openid profile read:messages",
    filterProtocolClaims: true,
    loadUserInfo: true,
    automaticSilentRenew: true,
    silent_redirect_uri:'http://localhost:4200/silent-callback',
    // userStore: new WebStorageStateStore({ store: new CookieStorage() })
  };
}
