import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  userForm: FormGroup;
  isLoading = false;
  error: string;

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private router: Router){
    this.userForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  onSubmit(value: { userName: string; password: string; }) {
    this.isLoading = true;
    this.error = undefined;
    this.authService.signIn(value.userName, value.password)
      .then(r => {
        this.router.navigate(['']);
      })
      .catch(e => this.error = e.error.detail)
      .finally(() => this.isLoading = false);
  }
}
