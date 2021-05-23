import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { UserInfo } from 'src/app/models/Userinfo';
import { LoginService } from 'src/app/services/login/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  submitted: boolean = false;
  loginForm:FormGroup;
  login:UserInfo;

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      emailOrUsername: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      rememberMe: new FormControl(false)
    });
  }

  get emailOrUsername() { return this.loginForm.get('emailOrUsername') }   
  get password() { return this.loginForm.get('password') }

  onSubmit(): void {
    this.submitted = true;

    const emailOrUsername = this.loginForm.get('emailOrUsername').value;
    const password = this.loginForm.get('password').value;
    const rememberMe = this.loginForm.get('rememberMe').value;
    let login: UserInfo;
    
    let error: Boolean = false;
    login = {email: emailOrUsername, userName: emailOrUsername, password: password }

    console.log(this.loginService.login(login).subscribe((login: UserInfo) => this.login = login));
  }

}
