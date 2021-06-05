import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { UserLoginInfo } from 'src/app/models/UserLoginInfo';
import { AuthService } from 'src/app/services/auth-service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  
  submitted: boolean = false;
  signupForm:FormGroup;

  constructor(
    private authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      email: new FormControl('', Validators.required),
      username: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
  }

  signupErr: boolean = false;
  
  get email() { return this.signupForm.get('email') }  
  get username() { return this.signupForm.get('username') }  
  get password() { return this.signupForm.get('password') }
  get signupError() { return this.signupErr }
  
  onSubmit(): void {
    this.submitted = true;
    const email = this.signupForm.get('email');
    const userName = this.signupForm.get('username');
    const password = this.signupForm.get('password');

    let signupInfo: UserLoginInfo;

    if(!(email.errors?.required || userName.errors?.required ||password.errors?.required))
    {
      signupInfo = { email: email.value, userName: userName.value, password: password.value}
      this.authService.signup(signupInfo).subscribe(res => {
        this.router.navigate(['/login']);
      });
    }
  }
}
