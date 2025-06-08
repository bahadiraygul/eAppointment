
import { Injectable } from "@angular/core";
import {  Router } from "@angular/router";    
import { TokenMoel } from "../models/token-model";
import { jwtDecode, JwtPayload } from "jwt-decode";

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    tokenDecode : TokenMoel = new TokenMoel();

    constructor(private router : Router) { }


     isAuthenticated(): boolean {
        // Check if the user is authenticated
        const token: string | null = localStorage.getItem('token');

        if(token){
            
        const decode : JwtPayload | any = jwtDecode(token);
        const exp = decode.exp;
        const now = new Date().getTime() / 1000; // Current time in seconds

        if(now > exp) {
            this.router.navigateByUrl('/login');
            localStorage.removeItem('token');
            return true;
        }


        this.tokenDecode.id = decode["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        this.tokenDecode.name = decode["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        this.tokenDecode.email = decode["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
        this.tokenDecode.userName = decode["userName"];
        return true;
        }

        

        this.router.navigateByUrl('/login');
        return false;
    }

}
