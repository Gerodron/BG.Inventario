import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Component, inject, signal } from '@angular/core';
import { IAuthRequest } from '../../../core/interfaces/auth.interface';
import { AuthService } from '../../../core/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  _authservice = inject(AuthService);
  _router = inject(Router)

  loginForm = new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  })


  errorLogin = signal(false);
  buttonEnable = signal(false);

  onSubmit() {
    if (this.loginForm.valid) {
      this.errorLogin.set(false);
      this.buttonEnable.set(true);

      const form: IAuthRequest = {
        UserName: this.loginForm.value.username || '',
        Password: this.loginForm.value.password || ''
      };

      this._authservice.loginUser(form).subscribe({
        next: (res) => {
          if (res.data == null) {
            this.errorLogin.set(true);
          } else {
            this._authservice.saveAuthDetails(res.data);
            this._router.navigate(['/productos'])
            this.errorLogin.set(false);
          }
        },
        error: (err) => {
          this.errorLogin.set(true);
          this.buttonEnable.set(false);
        },
        complete: () => {
          this.buttonEnable.set(false);
        }
      });
    }
  }
}
