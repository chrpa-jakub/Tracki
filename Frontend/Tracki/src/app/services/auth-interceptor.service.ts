import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { Router } from "@angular/router";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (localStorage.getItem('jwt') != null) {
            const clonedReq = req.clone({
                headers: new HttpHeaders({
                    'Authorization': 'Bearer ' + localStorage.getItem('jwt')
                })
            });
            return next.handle(clonedReq).pipe(
                tap(
                    succ => { },
                    err => {
                        if (err.status == 401){
                            localStorage.removeItem('jwt');
                            this.router.navigateByUrl('/auth/login');
                        }
                    }
                )
            )
        }
        else
            return next.handle(req.clone());
    }
}