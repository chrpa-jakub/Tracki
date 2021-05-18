import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  submitted: boolean = false;
  signupForm:FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      email: new FormControl('', Validators.required),
      username: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
  }
  
  get email() { return this.signupForm.get('email') }  
  get username() { return this.signupForm.get('username') }  
  get password() { return this.signupForm.get('password') }

  
  onSubmit(): void {
    this.submitted = true;
    console.log("Email: " + this.signupForm.get('email').value);
    console.log("Username: " + this.signupForm.get('username').value);
    console.log("Password: " + this.signupForm.get('password').value);
  }
}
