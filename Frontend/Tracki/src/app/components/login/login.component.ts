import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { UserLoginInfo } from 'src/app/models/UserLoginInfo';
import { AuthService } from 'src/app/services/auth-service'
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  submitted: boolean = false;
  loginErr: boolean = false;
  loginForm: FormGroup;
  login: UserLoginInfo;

  constructor(
    private authService: AuthService,
    private router: Router,
    private jwtHelper: JwtHelperService
    ) { }
  ngOnInit(): void {

    // If the user is already logged in, navigate to home page
    if(!this.authService.isLoggedIn) {
      this.router.navigateByUrl("/");
    }

    this.loginForm = new FormGroup({
      emailOrUsername: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      rememberMe: new FormControl(false)
    });
  }

  // Getters for forms
  get emailOrUsername() { return this.loginForm.get('emailOrUsername') }   
  get password() { return this.loginForm.get('password') }
  get loginError() { return this.loginErr }

  onSubmit(): void {
    this.submitted = true;

    const emailOrUsername = this.emailOrUsername;
    const password = this.password;
    const rememberMe = this.loginForm.get('rememberMe');

    // If email, username, passwords arent null, send the login request
    if(!(emailOrUsername.errors?.required || password.errors?.required))
    {
      let login: UserLoginInfo;
    
      login = {email: emailOrUsername.value, userName: emailOrUsername.value, password: password.value }
  
      this.authService.login(login).subscribe(res => {
        const token = (<any>res).token;
        localStorage.setItem("jwt", token);
        this.loginErr = false;
        this.router.navigate(['/']);
      }, err => {
        if (err.status = 400)
        this.loginErr = true });
    }
  }

}
