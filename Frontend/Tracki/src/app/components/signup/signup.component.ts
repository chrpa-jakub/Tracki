import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { UserInfo } from 'src/app/models/Userinfo';
import { UserService } from 'src/app/services/user/user.service'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  submitted: boolean = false;
  signupForm:FormGroup;

  constructor(private userService: UserService) { }

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
    const email = this.signupForm.get('email').value;
    const userName = this.signupForm.get('username').value;
    const password = this.signupForm.get('password').value;

    let signupInfo: UserInfo;

    console.log("Email: " + email);
    console.log("Username: " + userName);
    console.log("Password: " + password);

    signupInfo = { email: email, userName: userName, password: password}
    this.userService.signup(signupInfo).subscribe();
  }
}
