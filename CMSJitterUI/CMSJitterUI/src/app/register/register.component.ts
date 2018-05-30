import { Component, OnInit} from '@angular/core';
import {Signup} from '../Config';
import { RouterModule, Routes,Router } from '@angular/router';
import { RegisterService } from '../register.service';
import { Http,RequestOptions, Headers, Response } from '@angular/http';;  
import {filter, switchMap, min } from 'rxjs/operators';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-signup',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  imageURL:string="/assets/img/image.png"
  fileToUpload :File= null;
signupObject:Signup=new Signup();
  signupIndicator:boolean;
  Email:string;
  Password:string;
  FName:string;
  LName:string;
  MobNumber:number;
  Country:string;
  Image :string
  constructor(private data: RegisterService,private router:Router, private http:Http) { }


  ngOnInit()
  {
  }    
  send()
  {
      this.signupObject.MobNumber=123;
      this.signupObject.FName=this.FName;
      this.signupObject.LName=this.LName;
      this.signupObject.Password=this.Password;
      this.signupObject.Email=this.Email;
      this.signupObject.Country='India';
      this.signupObject.Image='101';
      this.data.postData(this.signupObject)
          .subscribe((event:any)=>
{
  this.router.navigate(['/login']);
            console.log(event);
            if(event==true)
            {
              this.signupIndicator=event;
              if(this.signupIndicator==true)
  {
    this.router.navigate(['/login']);
  }
  else{
    window.alert("SignUp Failed")
  }
  this.router.navigate(['/login']);
}
})
  }
}
