import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router'
import { ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from 'src/app/services/auth-guard.service'
import { StarRatingModule } from 'angular-star-rating';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SignupComponent } from './components/signup/signup.component';
import { HomeComponent } from './components/home/home.component';
import { AuthInterceptor } from "src/app/services/auth-interceptor.service";
import { AuthService } from './services/auth.service';
import { AccountService } from './services/account.service';
import { AccountOverviewComponent } from './components/account-overview/account-overview.component';
import { MusicPlayerComponent } from './components/music-player/music-player.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { IndividualSearchUserComponent } from './components/individual-search-user/individual-search-user.component';
import { IndividualSearchSongComponent } from './components/individual-search-song/individual-search-song.component';
import { SearchComponent } from './components/search/search.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'account/overview', component: AccountOverviewComponent },
  { path: 'search/:searchText', component: SearchComponent },
  { path: 'user/:userName', component: UserProfileComponent },
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
    MusicPlayerComponent,
    IndividualSearchUserComponent,
    UserProfileComponent,
    IndividualSearchSongComponent,
    SearchComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    StarRatingModule.forRoot(),
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
