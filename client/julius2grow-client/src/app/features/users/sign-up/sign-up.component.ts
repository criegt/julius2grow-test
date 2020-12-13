import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  userForm: FormGroup;
  isLoading = false;
  error: string;

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private router: Router){
    this.userForm = this.formBuilder.group({
      email: ['', Validators.required],
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  onSubmit(value: { email: string; userName: string; password: string; }) {
    this.isLoading = true;
    this.error = undefined;
    this.authService.signUp(value.email, value.userName, value.password)
      .then(r => {
        this.router.navigate(['/users/sign-in']);
      })
      .catch(e => this.error = e.error.detail)
      .finally(() => this.isLoading = false);
  }
}
