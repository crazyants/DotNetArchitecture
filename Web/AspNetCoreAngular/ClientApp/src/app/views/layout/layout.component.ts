import { AuthenticationService } from "../../shared/services/authentication.service";
import { Component } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";
import 'rxjs/add/operator/filter';

@Component({ selector: "app-layout", templateUrl: "./layout.component.html" })
export class LayoutComponent
{
	isAuthenticated: boolean = false;

	constructor(
		private readonly authenticationService: AuthenticationService,
		private readonly router: Router)
	{
		this.SetIsAuthenticated();
	}

	private SetIsAuthenticated()
	{
		this.router.events
			.filter(event => event instanceof NavigationEnd)
			.subscribe((event: NavigationEnd) =>
			{
				this.isAuthenticated = this.authenticationService.isAuthenticated();
			});
	}
}