import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  submitted: boolean = false;
  loginForm:FormGroup;

  constructor() { }

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
    console.log("Email or username: " + this.loginForm.get('emailOrUsername').value);
    console.log("Password: " + this.loginForm.get('password').value);
    console.log("Remember me: " + this.loginForm.get('rememberMe').value);
  }

}
