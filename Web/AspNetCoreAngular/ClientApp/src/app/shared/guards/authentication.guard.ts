import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

import { AuthenticationService } from "../services/authentication.service";

@Injectable()
export class AuthenticationGuard implements CanActivate
{
	constructor(
		private readonly authenticationService: AuthenticationService,
		private readonly router: Router) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean
	{
		if (this.authenticationService.getToken()) { return true; }
		this.router.navigate(["/login"]);
		return false;
	}
}