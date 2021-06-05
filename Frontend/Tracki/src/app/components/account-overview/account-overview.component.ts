import { Component, OnInit } from '@angular/core';
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { AuthService } from 'src/app/services/auth-service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-overview',
  templateUrl: './account-overview.component.html',
  styleUrls: ['./account-overview.component.scss']
})
export class AccountOverviewComponent implements OnInit {

  userBasicInfo: UserBasicInfo = new UserBasicInfo();
  accountOverviewForm:FormGroup;
  inputChanged:boolean = false;
  passwordErr:boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    ) { }

  ngOnInit(): void {
    this.accountOverviewForm = new FormGroup({
      username: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl('')
    });

    this.authService.getUserProfile().subscribe(
      res => {
        this.userBasicInfo.userName = res.userName;
        this.userBasicInfo.email = res.email;
        this.accountOverviewForm.controls['username'].setValue(res.userName);
        this.accountOverviewForm.controls['email'].setValue(res.email);
      }
    )
  }

  onChange(): void {
    const formUsername = this.accountOverviewForm.get("username").value;
    const formEmail = this.accountOverviewForm.get("email").value;
    const formPassword = this.accountOverviewForm.get("password").value

    if((this.userBasicInfo.userName != formUsername && formPassword == "" || this.userBasicInfo.email != formEmail && formPassword == ""
      || (formPassword != "" && formPassword.length >= 6)) 
      && (formUsername != "" && formEmail != "")
    ) {
      this.inputChanged = true;
    }
    else { this.inputChanged = false }
  }

  onSaveChanges(): void {
    const formPassword = this.accountOverviewForm.get("password").value

    if((formPassword == "") 
    || (formPassword != "" && formPassword.length >= 6)) {
      console.log("success");
    }
    else {
      console.log("fucl");
      this.passwordErr = true;
    }
  }


}
