import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthenticationService} from "../../../../core/authentication/authentication.service";
import {Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  errorMessage: string = "";

  constructor(private fb: FormBuilder, private authService : AuthenticationService,
              private router: Router,
              private snackBar: MatSnackBar) {
    this.form = this.fb.group({
      username: ["", Validators.required],
      firstName: ["", Validators.required],
      lastName: ["", Validators.required],
      email: ["", [Validators.required, Validators.email]],
      password: ["", Validators.required],
    })
  }

  ngOnInit(): void {

  }

  register(): void {
    var value = this.form.value;

    if(this.form.valid) {
      this.authService.register(value)
        .subscribe((res) => {
          console.log(res);
          this.snackBar.open("Registered user " + res.userName, "OK")
          this.router.navigate(['auth/login'])
        }, error => {
          console.log(error)
          this.errorMessage = error.error.detail
          this.snackBar.open(error.error.detail, "OK")
        })
    }

  }

}
