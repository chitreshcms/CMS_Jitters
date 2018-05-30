import { Component, OnInit} from '@angular/core';
import {Signup} from '../Config';
import { RouterModule, Routes,Router } from '@angular/router';
import { RegisterService } from '../register.service';
import { Http,RequestOptions, Headers, Response } from '@angular/http';;  
import {filter, switchMap, min } from 'rxjs/operators';
import { map } from 'rxjs/operators';
@Component({
  selector: '',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class ViewStatsComponent implements OnInit {

    MostTrendingHashtag:String
    TotalTweetsToday:Number
    MostTweetsBy:String
    MostLikedTweet:String



  constructor(private data: RegisterService,private router:Router, private http:Http) { }


  ngOnInit()
  {
  }    
  send()
  {
    
  }
}
