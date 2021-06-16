import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router'
import { ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from 'src/app/services/auth-guard.service'

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SignupComponent } from './components/signup/signup.component';
import { HomeComponent } from './components/home/home.component';
import { AuthInterceptor } from "src/app/services/auth-interceptor.service";
import { AuthService } from './services/auth.service';
import { AccountService } from './services/account.service';
import { AccountOverviewComponent } from './components/account-overview/account-overview.component';
import { SearchUsersComponent } from './components/search-users/search-users.component';
import { MusicPlayerComponent } from './components/music-player/music-player.component';
import { IndividualSearchUserComponent } from './components/individual-search-user/individual-search-user.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'account/overview', component: AccountOverviewComponent },
  { path: 'user/search/:searchText', component: SearchUsersComponent },
]

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    AccountOverviewComponent,
    SearchUsersComponent,
    MusicPlayerComponent,
    SearchUsersComponent,
    IndividualSearchUserComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes, { enableTracing: false }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5001"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [AuthService, AccountService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule {}
