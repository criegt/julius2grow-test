import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.scss']
})
export class SignOutComponent implements OnInit {

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit(): void {
    this.authService.SignOut();
    this.router.navigate(['/users/sign-in']);
  }
}
