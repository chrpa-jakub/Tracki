import { Component, OnInit, Input } from '@angular/core';
import { UserBasicInfo } from 'src/app/models/UserBasicInfo';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { AuthService } from 'src/app/services/auth.service'
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { UserLoginInfo } from 'src/app/models/UserLoginInfo';

@Component({
  selector: 'app-account-overview',
  templateUrl: './account-overview.component.html',
  styleUrls: ['./account-overview.component.scss']
})
export class AccountOverviewComponent implements OnInit {

  userBasicInfo: UserBasicInfo = new UserBasicInfo();
  accountOverviewForm: FormGroup;
  inputChanged: boolean = false;
  passwordErr :boolean = false;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.accountOverviewForm = new FormGroup({
      username: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl('')
    });

    this.accountService.getAccountOverview().subscribe(
      res => {
        this.userBasicInfo.userName = res.userName;
        this.userBasicInfo.email = res.email;
        this.image64 = res.photo;
        this.accountOverviewForm.controls['username'].setValue(res.userName);
        this.accountOverviewForm.controls['email'].setValue(res.email);
      }
    )
  }

  get formUsername() { return this.accountOverviewForm.get('username').value } 
  get formEmail() { return this.accountOverviewForm.get('email').value }   
  get formPassword() { return this.accountOverviewForm.get('password').value }

  ngOnChanges(): void {
    if((this.userBasicInfo.userName != this.formUsername && this.formPassword == ""
      || this.userBasicInfo.email != this.formEmail && this.formPassword == ""
      || this.imageSrc != null
      || (this.formPassword != "" && this.formPassword.length >= 6)) 
      && (this.formUsername != "" && this.formEmail != "")
    ) {
      this.inputChanged = true;
    }
    else { this.inputChanged = false }
  }

  onRevertChanges(): void {
    this.accountOverviewForm.controls['username'].setValue(this.userBasicInfo.userName);
    this.accountOverviewForm.controls['email'].setValue(this.userBasicInfo.email);
    this.accountOverviewForm.controls['password'].setValue("");
    this.image64 = "";
    this.imageSrc = "";
    this.inputChanged = false;
  }

  imageSrc: string;
  image64: string;
  onFileSelected(event: any): void {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); 

      reader.onload = (event) => { 
        this.inputChanged = true;
        this.imageSrc = <string>event.target.result;
        this.image64 = this.imageSrc;
        this.imageSrc = this.imageSrc.substring(this.imageSrc.indexOf(",") + 1);
      }
    }
  }

  onSaveChanges(): void {
    if(this.inputChanged) {
      let userInfo: UserLoginInfo;
      userInfo = {userName: this.formUsername, email: this.formEmail, 
        password: this.formPassword, photo: this.imageSrc } 
      this.accountService.editAccount(userInfo).subscribe(res => {
        const token = (<any>res).token;
        localStorage.setItem("jwt", token);
      });
    }
  }
}
