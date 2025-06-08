import { Routes } from '@angular/router';
import { LoginComponent } from '../component/login/login.component';
import { LayoutsComponent } from '../component/layouts/layouts.component';
import { HomeComponent } from '../component/home/home.component';
import { NotFoundComponent } from '../component/not-found/not-found.component';
import { AuthService } from './service/auth.service';
import { inject } from '@angular/core';
import { DoctorsComponent } from '../component/doctors/doctors.component';

export const routes: Routes = [

    {
        path:"login",
        component: LoginComponent
    },
    {
        path: "",
        component:LayoutsComponent,
        canActivateChild: [()=> inject(AuthService).isAuthenticated(),],
        children: [
            {
                path: "",
                component:HomeComponent
            },
            {
                path:"doctors",
                component: DoctorsComponent
            }
        ]
    },
    {
        path: "**",
        component:NotFoundComponent
    }
];
