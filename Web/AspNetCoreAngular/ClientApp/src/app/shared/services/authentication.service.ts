import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { AuthenticationModel } from "../models/authentication.model";
import { HttpService } from "./http.service";
import { ModalService } from "./modal.service";

declare var UIkit: any;

@Injectable()
export class AuthenticationService
{
	constructor(
		private readonly httpService: HttpService,
		private readonly modalService: ModalService,
		private readonly router: Router) { }

	private token: string = "token";

	authenticate(authenticationModel: AuthenticationModel)
	{
		this.httpService.post("authenticationservice/authenticate", authenticationModel).subscribe(response =>
		{
			this.setToken(response);
			this.router.navigate(["/home"]);
		});
	}

	getAuthenticated()
	{
		this.httpService.get("authenticationservice/GetAuthenticatedUserId").subscribe(response =>
		{
			this.modalService.alert(`Authenticated UserId: ${response}`);
		});
	}

	logout()
	{
		this.setToken();
		this.router.navigate(["/login"]);
	}

	isAuthenticated()
	{
		return this.getToken() != undefined;
	}

	getToken()
	{
		return sessionStorage.getItem(this.token);
	}

	private setToken(token: string = undefined)
	{
		if (token)
		{
			sessionStorage.setItem(this.token, token);
		}
		else
		{
			sessionStorage.removeItem(this.token);
		}
	}
}
